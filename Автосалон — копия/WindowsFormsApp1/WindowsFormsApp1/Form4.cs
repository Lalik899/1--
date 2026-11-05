using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int idCar = 0, idBuyer = 0, idEmployee = 0;
            decimal totalCost = 0;
            DateTime saleDate;

            if (!int.TryParse(textBox1.Text, out idCar) ||
                !int.TryParse(textBox2.Text, out idBuyer) ||
                !int.TryParse(textBox3.Text, out idEmployee) ||
                !decimal.TryParse(textBox5.Text, out totalCost))
            {
                MessageBox.Show("Пожалуйста, проверьте числовые поля (ID, Общая стоимость должен содержать числа).");
                return;
            }

            // Безопасно парсим дату
            if (!DateTime.TryParse(textBox4.Text, out saleDate))
            {
                MessageBox.Show("Пожалуйста, введите корректную дату продажи (например, 25.09.2026).");
                return;
            }

            // 2. Формируем SQL-запрос (экранируем скобками зарезервированные имена полей Access)
            string query = "INSERT INTO Продажи ([ID_Автомобиля], [ID_Покупателя], [ID_Сотрудника], [Дата продажи], [Доп пакет], [Трейд-ин], [Кредит], [Общая стоимость]) " +
                           "VALUES (?, ?, ?, ?, ?, ?, ?, ?)";

            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\БД автосалон.accdb";

            try
            {
                using (OleDbConnection con = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        // Передаем параметры строго по порядку знаков '?' в запросе
                        cmd.Parameters.AddWithValue("@ID_Автомобиля", idCar);
                        cmd.Parameters.AddWithValue("@ID_Покупателя", idBuyer);
                        cmd.Parameters.AddWithValue("@ID_Сотрудника", idEmployee);
                        cmd.Parameters.AddWithValue("@Дата_продажи", saleDate);
                        cmd.Parameters.AddWithValue("@Доп_пакет", checkBox1.Checked);
                        cmd.Parameters.AddWithValue("@Трейд_ин", checkBox2.Checked);
                        cmd.Parameters.AddWithValue("@Кредит", checkBox3.Checked);
                        cmd.Parameters.AddWithValue("@Общая_стоимость", totalCost);

                        con.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Запись о продаже успешно добавлена!");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении сделки: {ex.Message}");
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
