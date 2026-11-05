using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form8 : Form
    {
        private string receivedUserName;
        private int receivedCarId;

        // Конструктор формы — принимает ФИО и ID автомобиля при открытии
        public Form8(string username, int carId)
        {
            InitializeComponent();
            this.receivedUserName = username;
            this.receivedCarId = carId;
        }

        // Событие загрузки формы (автоматическое заполнение полей при открытии)
        private void Form8_Load(object sender, EventArgs e)
        {
            // Устанавливаем текущую дату и время в dateTimePicker1
            dateTimePicker1.Value = DateTime.Now;

            // Разделяем переданное ФИО по пробелам на Фамилию, Имя и Отчество
            string[] fioParts = receivedUserName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Автоматически распределяем ФИО по текстовым полям, если они заполнены
            if (fioParts.Length > 0) textBox1.Text = fioParts[0]; // Фамилия
            if (fioParts.Length > 1) textBox2.Text = fioParts[1]; // Имя
            if (fioParts.Length > 2) textBox3.Text = fioParts[2]; // Отчество
        }

        // КНОПКА: Запись на тест-драйв
        private void button1_Click(object sender, EventArgs e)
        {
            int idCar = this.receivedCarId;

            // Проверяем, что текстовые поля ФИО не пустые
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Пожалуйста, заполните Фамилию, Имя и Отчество.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Получаем точную дату и время из элемента dateTimePicker1
            DateTime bookingDate = dateTimePicker1.Value;

            // ИСПРАВЛЕНО: Интервал между записями — полтора часа (90 минут)
            // Ищем конфликты за 90 минут до выбранного времени и через 90 минут после него
            DateTime startTime = bookingDate.AddMinutes(-90);
            DateTime endTime = bookingDate.AddMinutes(90);

            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\192.168.3.250\Veda\3 курс\ИСП 33\МДК 03.02\Васильев Елькин\Автосалон — копия\WindowsFormsApp1\WindowsFormsApp1\БД автосалон.accdb";

            // Запрос 1: Проверка существования записи в полуторачасовом интервале
            string checkQuery = "SELECT COUNT(*) FROM [Запись пользователя] WHERE [Дата] BETWEEN ? AND ?";

            // Запрос 2: Добавление новой записи, если время свободно
            string insertQuery = "INSERT INTO [Запись пользователя] ([ID_Автомобиля], [Фамилия], [Имя], [Отчество], [Дата]) VALUES (?, ?, ?, ?, ?)";

            try
            {
                using (OleDbConnection con = new OleDbConnection(connectionString))
                {
                    con.Open();

                    // ШАГ 1: ВЫПОЛНЯЕМ ПРОВЕРКУ ИНТЕРВАЛА В 1.5 ЧАСА
                    using (OleDbCommand checkCmd = new OleDbCommand(checkQuery, con))
                    {
                        checkCmd.Parameters.Add("@StartTime", OleDbType.Date).Value = startTime;
                        checkCmd.Parameters.Add("@EndTime", OleDbType.Date).Value = endTime;

                        int existingRecordsCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (existingRecordsCount > 0)
                        {
                            MessageBox.Show("Запись невозможна! Интервал между тест-драйвами должен составлять не менее 1.5 часов. Выберите другое время.",
                                            "Время занято", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            con.Close();
                            return; // Выходим, сохранение заблокировано
                        }
                    }

                    // ШАГ 2: ЕСЛИ СВОБОДНО, СОХРАНЯЕМ В БАЗУ ДАННЫХ
                    using (OleDbCommand cmd = new OleDbCommand(insertQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@ID_Автомобиля", idCar);
                        cmd.Parameters.AddWithValue("@Фамилия", textBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@Имя", textBox2.Text.Trim());
                        cmd.Parameters.AddWithValue("@Отчество", textBox3.Text.Trim());
                        cmd.Parameters.Add("@Дата", OleDbType.Date).Value = bookingDate;

                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }

                OleDbConnection.ReleaseObjectPool();

                MessageBox.Show("Запись пользователя успешно создана и сохранена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при работе с БД: {ex.Message}", "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
