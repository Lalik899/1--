using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Пожалуйста, обязательно заполните Фамилию и Имя.");
                return;
            }

            // SQL-запрос (экранируем все поля квадратными скобками во избежание конфликтов синтаксиса)
            string query = "INSERT INTO Покупатели ([Фамилия], [Имя], [Отчество], [Адрес], [Телефон], [Email]) " +
                           "VALUES (?, ?, ?, ?, ?, ?)";

            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\БД автосалон.accdb";

            try
            {
                using (OleDbConnection con = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Фамилия", textBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@Имя", textBox2.Text.Trim());
                        cmd.Parameters.AddWithValue("@Отчество", textBox3.Text.Trim());
                        cmd.Parameters.AddWithValue("@Адрес", textBox4.Text.Trim());
                        cmd.Parameters.AddWithValue("@Телефон", textBox5.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", textBox6.Text.Trim());

                        con.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Покупатель успешно добавлен!");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}");
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