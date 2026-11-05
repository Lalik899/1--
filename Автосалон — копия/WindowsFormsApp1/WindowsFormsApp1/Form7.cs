using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form7 : Form
    {
        private string currentUserName = "Иван Иванов";

        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            // Наполнение таблицы автомобилей при загрузке формы
            this.автомобилиTableAdapter.Fill(this.бД_автосалонDataSet.Автомобили);
        }

        // КНОПКА 1: Запись на тест-драйв
        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Cells[0].Value != null)
            {
                int.TryParse(dataGridView1.CurrentRow.Cells[0].Value.ToString(), out int carId);
                Form8 bookingForm = new Form8(this.currentUserName, carId);
                if (bookingForm.ShowDialog() == DialogResult.OK)
                {
                    this.автомобилиTableAdapter.Fill(this.бД_автосалонDataSet.Автомобили);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите автомобиль в таблице перед записью!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // КНОПКА 2: Купить автомобиль
        private void button2_Click(object sender, EventArgs e)
        {
            // 1. Проверяем, выбрана ли строка в таблице
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.Cells[0].Value == null)
            {
                MessageBox.Show("Пожалуйста, выберите автомобиль в таблице для совершения покупки!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var currentRow = dataGridView1.CurrentRow;

            // 2. БЕЗОПАСНАЯ ПРОВЕРКА КОЛИЧЕСТВА (Индекс 6 — это 7-й столбец «Количество»)
            int availableCount = 0;
            if (currentRow.Cells.Count > 6 && currentRow.Cells[6].Value != null)
            {
                int.TryParse(currentRow.Cells[6].Value.ToString(), out availableCount);
            }

            // БЛОКИРОВКА ЕСЛИ КОЛИЧЕСТВО = 0
            if (availableCount <= 0)
            {
                MessageBox.Show("Данного автомобиля нет в наличии! Оформление покупки невозможно.",
                                "Автомобиль отсутствует", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Получаем ID автомобиля (Индекс 0)
            int.TryParse(currentRow.Cells[0].Value.ToString(), out int carId);

            // Собираем Марку (Индекс 1) и Модель (Индекс 2) для передачи на форму 9
            string carBrand = currentRow.Cells[1].Value?.ToString() ?? "";
            string carModel = currentRow.Cells[2].Value?.ToString() ?? "";
            string carName = $"{carBrand} {carModel}".Trim();
            if (string.IsNullOrEmpty(carName)) carName = "выбранный автомобиль";

            // 4. БЕЗОПАСНОЕ ПОЛУЧЕНИЕ И ПАРСИНГ СТОИМОСТИ (Индекс 4 — это 5-й столбец «Цена»)
            int totalCost = 0;
            if (currentRow.Cells.Count > 4 && currentRow.Cells[4].Value != null)
            {
                string priceRawText = currentRow.Cells[4].Value.ToString();

                // Очищаем от пробелов, скрытых символов Access (\u00A0) и текста валюты
                string priceCleaned = priceRawText.Replace(" ", "")
                                                  .Replace("\u00A0", "")
                                                  .Replace("руб", "")
                                                  .Replace("$", "");
                int.TryParse(priceCleaned, out totalCost);
            }

            // Если парсинг цены не удался (ячейка пустая или текст)
            if (totalCost == 0)
            {
                MessageBox.Show("Не удалось определить стоимость автомобиля из ячейки 'Цена'.", "Ошибка данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Строка подключения к вашей базе данных Access
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\192.168.3.250\Veda\3 курс\ИСП 33\МДК 03.02\Васильев Елькин\Автосалон — копия\WindowsFormsApp1\WindowsFormsApp1\БД автосалон.accdb";

            // 5. ОТКРЫВАЕМ ФОРМУ 9 (передаем подключение, название машины и её точную очищенную цену)
            Form9 customerForm = new Form9(connectionString, carName, totalCost);

            if (customerForm.ShowDialog() == DialogResult.OK)
            {
                // Забираем из Form9 ID нового покупателя и флаги способов оплаты
                int newCustomerId = customerForm.CreatedCustomerId;
                bool creditValue = customerForm.IsCredit;
                bool tradeInValue = customerForm.IsTradeIn;

                // Запрос записи сделки в таблицу [Продажи] (Поле [Общая стоимость] на последнем месте)
                string query = "INSERT INTO [Продажи] ([ID_Автомобиля], [ID_Покупателя], [ID_Сотрудника], [Доп пакет], [Трейд-ин], [Кредит], [Дата продажи], [Общая стоимость]) " +
                               "VALUES (?, ?, ?, ?, ?, ?, ?, ?)";

                try
                {
                    using (OleDbConnection con = new OleDbConnection(connectionString))
                    {
                        using (OleDbCommand cmd = new OleDbCommand(query, con))
                        {
                            // Добавляем параметры строго по порядку знаков "?" в SQL-запросе для Access
                            cmd.Parameters.AddWithValue("@ID_Автомобиля", carId);
                            cmd.Parameters.AddWithValue("@ID_Покупателя", newCustomerId);
                            cmd.Parameters.AddWithValue("@ID_Сотрудника", 1); // Заглушка сотрудника

                            cmd.Parameters.AddWithValue("@Доп_пакет", false);
                            cmd.Parameters.AddWithValue("@Трейд_ин", tradeInValue);
                            cmd.Parameters.AddWithValue("@Кредит", creditValue);

                            cmd.Parameters.Add("@Дата_продажи", OleDbType.Date).Value = DateTime.Now.Date;

                            // ЗДЕСЬ ЦЕНА ВНОСИТСЯ В ТАБЛИЦУ ПРОДАЖИ
                            cmd.Parameters.AddWithValue("@Общая_стоимость", totalCost);

                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }

                    OleDbConnection.ReleaseObjectPool();

                    MessageBox.Show($"Автомобиль {carName} успешно оформлен!\nСделка на сумму {totalCost} руб. сохранена в таблицу продаж.",
                                    "Успешная покупка", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Перезагружаем таблицу на главной форме, чтобы увидеть изменения количества
                    this.автомобилиTableAdapter.Fill(this.бД_автосалонDataSet.Автомобили);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при оформлении продажи в БД:\n{ex.Message}", "Ошибка базы данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Покупка отменена. Данные покупателя и сделка не были сохранены.", "Отмена операции", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    } // Скобка, закрывающая class Form7
} // Скобка, закрывающая namespace
