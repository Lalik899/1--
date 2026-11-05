using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form10 : Form
    {
        private string connectionString;

        public Form10(string connString)
        {
            InitializeComponent();
            this.connectionString = connString;
            this.Text = "Новая запись на тест-драйв";
        }

        // КНОПКА 1: Подтвердить запись (Добавить)
        private void button1_Click_1(object sender, EventArgs e)
        {
            // Проверяем заполнение обязательных текстовых полей
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Пожалуйста, заполните ID Автомобиля, Фамилию и Имя клиента!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Безопасно парсим ID автомобиля
            if (!int.TryParse(textBox1.Text.Trim(), out int carId))
            {
                MessageBox.Show("ID Автомобиля должен быть числом!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Получаем выбранную пользователем дату напрямую из календаря
            DateTime testDriveDate = dateTimePicker1.Value.Date;

            // Точное системное имя таблицы из вашей базы данных Access
            string query = "INSERT INTO [Запись_пользователя] ([ID_Автомобиля], [Фамилия], [Имя], [Отчество], [Дата]) VALUES (?, ?, ?, ?, ?);";

            try
            {
                using (OleDbConnection con = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        // В Access параметры строго привязываются к порядку знаков "?" в запросе
                        cmd.Parameters.AddWithValue("@ID_Автомобиля", carId);
                        cmd.Parameters.AddWithValue("@LastName", textBox2.Text.Trim());   // Фамилия
                        cmd.Parameters.AddWithValue("@FirstName", textBox3.Text.Trim());  // Имя
                        cmd.Parameters.AddWithValue("@Patronymic", textBox4.Text.Trim()); // Отчество
                        cmd.Parameters.Add("@Date", OleDbType.Date).Value = testDriveDate; // Передаем дату из календаря

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                // Устанавливаем результат OK только при успешной записи в БД
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении записи на тест-драйв:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // КНОПКА 2: Закрыть (Отмена)
        private void button2_Click_1(object sender, EventArgs e)
        {
            // Если пользователь просто закрывает форму, передаем Cancel
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
