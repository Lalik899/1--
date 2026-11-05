using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int idCar = 0, idBuyer = 0, idEmployee = 0;
            DateTime testDate;

            if (!int.TryParse(textBox1.Text, out idCar) ||
                !int.TryParse(textBox2.Text, out idBuyer) ||
                !int.TryParse(textBox3.Text, out idEmployee))
            {
                MessageBox.Show("Пожалуйста, проверьте числовые поля (ID должны быть целыми числами).");
                return;
            }

            // Безопасно парсим дату проведения
            if (!DateTime.TryParse(textBox4.Text, out testDate))
            {
                MessageBox.Show("Пожалуйста, введите корректную дату проведения (например, 25.09.2026).");
                return;
            }

            // 2. Формируем SQL-запрос (экранируем скобками зарезервированные имена полей MS Access)
            string query = "INSERT INTO [Тест-драйв] ([ID_Автомобиля], [ID_Покупателя], [ID_Сотрудника], [Дата проведения]) " +
                           "VALUES (?, ?, ?, ?)";

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
                        cmd.Parameters.AddWithValue("@Дата_проведения", testDate);

                        con.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Запись на тест-драйв успешно создана!");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении записи: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
