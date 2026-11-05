using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form9 : Form
    {
        private string connectionString;

        // Свойство для передачи ID созданного покупателя в Form7
        public int CreatedCustomerId { get; private set; }

        // Новые свойства для передачи выбранного способа оплаты обратно в Form7
        public bool IsCredit { get; private set; }
        public bool IsTradeIn { get; private set; }

        // Конструктор принимает строку подключения, имя машины и стоимость
        public Form9(string connString, string carName, int cost)
        {
            InitializeComponent();
            this.connectionString = connString;
            this.Text = $"Оформление покупки: {carName}";
        }

        // КНОПКА: Закрыть (Отмена)
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // КНОПКА: Подтвердить покупку
        private void button1_Click(object sender, EventArgs e)
        {
            // Проверяем заполнение обязательных полей (textBox1 - Фамилия, textBox2 - Имя)
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Пожалуйста, заполните Фамилию (поле 1) и Имя (поле 2) покупателя!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ПРОВЕРКА СПОСОБА ОПЛАТЫ: Запоминаем состояние RadioButton перед закрытием формы
            IsCredit = radioButton1.Checked;  // Будет true, если выбран "В кредит"
            IsTradeIn = radioButton2.Checked; // Будет true, если выбран "Трейд-ин"
            // Если выбран radioButton3 ("По карте"), то оба свойства IsCredit и IsTradeIn останутся false

            // Запросы для вставки в таблицу Покупатели и получения нового ID
            string customerQuery = "INSERT INTO [Покупатели] ([Фамилия], [Имя], [Отчество], [Адрес], [Телефон], [Email]) VALUES (?, ?, ?, ?, ?, ?);";
            string idQuery = "SELECT @@IDENTITY;"; // Функция Access для получения последнего сгенерированного ID (счетчика)

            try
            {
                using (OleDbConnection con = new OleDbConnection(connectionString))
                {
                    con.Open();

                    // 1. Сохраняем личные данные пользователя из стандартных TextBox'ов по порядку
                    using (OleDbCommand cmd = new OleDbCommand(customerQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@LastName", textBox1.Text.Trim());   // Фамилия
                        cmd.Parameters.AddWithValue("@FirstName", textBox2.Text.Trim());  // Имя
                        cmd.Parameters.AddWithValue("@Patronymic", textBox3.Text.Trim()); // Отчество
                        cmd.Parameters.AddWithValue("@Address", textBox4.Text.Trim());    // Адрес
                        cmd.Parameters.AddWithValue("@Phone", textBox5.Text.Trim());      // Телефон
                        cmd.Parameters.AddWithValue("@Email", textBox6.Text.Trim());      // Email

                        cmd.ExecuteNonQuery();
                    }

                    // 2. Извлекаем созданный ID_Покупателя
                    using (OleDbCommand cmdId = new OleDbCommand(idQuery, con))
                    {
                        CreatedCustomerId = Convert.ToInt32(cmdId.ExecuteScalar());
                    }
                }

                // Закрываем форму с результатом OK, чтобы Form7 знала, что можно регистрировать Продажу
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных покупателя:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
