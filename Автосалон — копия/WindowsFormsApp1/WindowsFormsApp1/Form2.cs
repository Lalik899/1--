using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Пожалуйста, заполните Марку и Модель автомобиля.");
                return;
            }

            // 2. Безопасно переводим числа из текста в числовые типы данных
            int year = 0;
            int price = 0;
            int quantity = 0;

            if (!int.TryParse(textBox3.Text, out year) ||
                !int.TryParse(textBox4.Text, out price) ||
                !int.TryParse(textBox6.Text, out quantity))
            {
                MessageBox.Show("Пожалуйста, проверьте числовые поля:\nГод (textBox3), Цена (textBox4) и Количество (textBox6) должны быть числами!");
                return;
            }

            // 3. SQL-запрос на добавление
            string query = "INSERT INTO Автомобили ([Марка], [Модель], [Год выпуска], [Цена], [Статус], [Количество]) " +
                           "VALUES (?, ?, ?, ?, ?, ?)";

            // Строка подключения (используем имя вашей базы данных БД_автосалон)
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\БД автосалон.accdb";

            try
            {
                using (OleDbConnection con = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        // Заполняем параметры строго по порядку из полей textBox1-6
                        cmd.Parameters.AddWithValue("@Марка", textBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@Модель", textBox2.Text.Trim());
                        cmd.Parameters.AddWithValue("@Год выпуска", year);
                        cmd.Parameters.AddWithValue("@Цена", price);
                        cmd.Parameters.AddWithValue("@Статус", textBox5.Text.Trim());
                        cmd.Parameters.AddWithValue("@Количество", quantity);

                        con.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Автомобиль успешно добавлен!");

                        // Сообщаем первой форме, что всё прошло успешно, и закрываем окно
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения в базу данных: {ex.Message}");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            // Закрываем текущую форму (Form2), после чего фокус автоматически вернется на Form1
            this.Close();
        }
    }
}
