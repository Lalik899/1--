using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Пожалуйста, заполните поля: Фамилия, Имя и Должность.");
                return;
            }

            // SQL-запрос добавления записи
            string query = "INSERT INTO Сотрудники ([Фамилия], [Имя], [Отчество], [Должность]) VALUES (?, ?, ?, ?)";
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
                        cmd.Parameters.AddWithValue("@Должность", textBox4.Text.Trim());

                        con.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Сотрудник успешно добавлен в базу данных!");
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            // Закрываем текущую форму (Form2), после чего фокус автоматически вернется на Form1
            this.Close();
        }
    }
}
