using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Открываем вторую форму
            Form2 form2 = new Form2();

            // Если на второй форме успешно нажали «Сохранить» (вернулся DialogResult.OK)
            if (form2.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Обновляем таблицу на экране, используя точное имя вашего датасета из прошлых шагов
                    this.автомобилиTableAdapter.Fill(this.бД_автосалонDataSet.Автомобили);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Данные сохранены, но не удалось обновить таблицу на экране: {ex.Message}");
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            // 1. Проверяем, выбрана ли строка
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Пожалуйста, выберите существующую строку для удаления.");
                return;
            }

            // Подтверждение удаления, чтобы пользователь не удалил данные случайно
            DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите удалить выбранную запись?",
                "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                var row = dataGridView1.CurrentRow;

                // Получаем ID автомобиля из первой колонки (Cells[0])
                // Убедитесь, что ID_Автомобиля находится именно в первой ячейке (индекс 0)
                if (row.Cells[0].Value == null || string.IsNullOrEmpty(row.Cells[0].Value.ToString()))
                {
                    MessageBox.Show("Не удалось получить ID выбранной записи.");
                    return;
                }

                int idАвтомобиля = Convert.ToInt32(row.Cells[0].Value);

                // SQL-запрос на удаление по ID
                string query = "DELETE FROM Автомобили WHERE [ID_Автомобиля] = ?";

                // Строка подключения (используйте точно такую же, как в кнопке Добавить)
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\БД автосалон.accdb";

                try
                {
                    using (OleDbConnection con = new OleDbConnection(connectionString))
                    {
                        using (OleDbCommand cmd = new OleDbCommand(query, con))
                        {
                            // Передаем параметр ID
                            cmd.Parameters.AddWithValue("@ID_Автомобиля", idАвтомобиля);

                            con.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Данные успешно удалены!");

                                // --- ОБНОВЛЕНИЕ ТАБЛИЦЫ НА ЭКРАНЕ ---
                                // Вариант А: Если вы использовали встроенный мастер Visual Studio:
                                this.автомобилиTableAdapter.Fill(this.бД_автосалонDataSet.Автомобили);

                                // Вариант Б: Если у вас свой метод загрузки, раскомментируйте его:
                                // LoadDataFromDatabase();
                            }
                            else
                            {
                                MessageBox.Show("Запись с таким ID не найдена в базе данных.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении: {ex.Message}");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Button searchBtn = (Button)sender;

            // Если поиск уже активен — сбрасываем фильтр и возвращаем исходный текст кнопки
            if (searchBtn.Text == "Сбросить поиск")
            {
                if (dataGridView1.DataSource is BindingSource bs) bs.RemoveFilter();
                else if (dataGridView1.DataSource is DataTable dt) dt.DefaultView.RowFilter = "";

                searchBtn.Text = "Найти";
                return;
            }

            // Создаем диалоговое окно ввода марки автомобиля программно
            Form prompt = new Form()
            {
                Width = 350,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Поиск автомобиля",
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label textLabel = new Label() { Left = 20, Top = 20, Text = "Введите марку автомобиля для поиска:", Width = 300 };
            TextBox textBox = new TextBox() { Left = 20, Top = 45, Width = 290 };
            Button confirmation = new Button() { Text = "ОК", Left = 210, Width = 100, Top = 80, DialogResult = DialogResult.OK };

            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            // Если пользователь ввёл текст и нажал ОК
            if (prompt.ShowDialog() == DialogResult.OK)
            {
                string searchKeyword = textBox.Text.Trim();

                // Если ничего не ввели — просто выходим
                if (string.IsNullOrEmpty(searchKeyword)) return;

                // Фильтруем данные по столбцу "Марка" (для dataGridView1)
                if (dataGridView1.DataSource is BindingSource bindingSource)
                {
                    bindingSource.Filter = $"Марка LIKE '%{searchKeyword}%'";
                    searchBtn.Text = "Сбросить поиск";
                }
                else if (dataGridView1.DataSource is DataTable dataTable)
                {
                    dataTable.DefaultView.RowFilter = $"Марка LIKE '%{searchKeyword}%'";
                    searchBtn.Text = "Сбросить поиск";
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "бД_автосалонDataSet._Тест_драйв". При необходимости она может быть перемещена или удалена.
            this.тест_драйвTableAdapter.Fill(this.бД_автосалонDataSet._Тест_драйв);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "бД_автосалонDataSet.Сотрудники". При необходимости она может быть перемещена или удалена.
            this.сотрудникиTableAdapter.Fill(this.бД_автосалонDataSet.Сотрудники);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "бД_автосалонDataSet.Продажи". При необходимости она может быть перемещена или удалена.
            this.продажиTableAdapter.Fill(this.бД_автосалонDataSet.Продажи);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "бД_автосалонDataSet.Покупатели". При необходимости она может быть перемещена или удалена.
            this.покупателиTableAdapter.Fill(this.бД_автосалонDataSet.Покупатели);
            try
            {
                // Загружаем данные из базы в таблицу при старте программы
                this.автомобилиTableAdapter.Fill(this.бД_автосалонDataSet.Автомобили);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при начальной загрузке данных: {ex.Message}");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            if (form3.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Обновляем таблицу покупателей на экране (замените dataGridView2 на имя вашей сетки для покупателей)
                    this.покупателиTableAdapter.Fill(this.бД_автосалонDataSet.Покупатели);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Данные сохранены, но не удалось обновить таблицу: {ex.Message}");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Замените dataGridView2 на реальное имя таблицы покупателей на форме
            if (dataGridView2.CurrentRow == null || dataGridView2.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Пожалуйста, выберите строку с покупателем для удаления.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите удалить выбранного покупателя?",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                var row = dataGridView2.CurrentRow;

                if (row.Cells[0].Value == null || string.IsNullOrEmpty(row.Cells[0].Value.ToString()))
                {
                    MessageBox.Show("Не удалось получить ID покупателя.");
                    return;
                }

                int idПокупателя = Convert.ToInt32(row.Cells[0].Value);
                string query = "DELETE FROM Покупатели WHERE [ID_Покупателя] = ?";
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\БД автосалон.accdb";

                try
                {
                    using (OleDbConnection con = new OleDbConnection(connectionString))
                    {
                        using (OleDbCommand cmd = new OleDbCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@ID_Покупателя", idПокупателя);

                            con.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Покупатель успешно удален!");
                                this.покупателиTableAdapter.Fill(this.бД_автосалонDataSet.Покупатели);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении: {ex.Message}");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Button searchBtn = (Button)sender;

            // Если поиск уже активен — сбрасываем фильтр
            if (searchBtn.Text == "Сбросить поиск")
            {
                if (dataGridView2.DataSource is BindingSource bs) bs.RemoveFilter();
                else if (dataGridView2.DataSource is DataTable dt) dt.DefaultView.RowFilter = "";

                searchBtn.Text = "Найти";
                return;
            }

            // Создаем диалоговое окно ввода фамилии программно
            Form prompt = new Form()
            {
                Width = 350,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Поиск покупателя",
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label textLabel = new Label() { Left = 20, Top = 20, Text = "Введите фамилию для поиска:", Width = 300 };
            TextBox textBox = new TextBox() { Left = 20, Top = 45, Width = 290 };
            Button confirmation = new Button() { Text = "ОК", Left = 210, Width = 100, Top = 80, DialogResult = DialogResult.OK };

            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            if (prompt.ShowDialog() == DialogResult.OK)
            {
                string searchKeyword = textBox.Text.Trim();

                if (string.IsNullOrEmpty(searchKeyword)) return;

                // Фильтруем данные по столбцу "Фамилия"
                if (dataGridView2.DataSource is BindingSource bindingSource)
                {
                    bindingSource.Filter = $"Фамилия LIKE '%{searchKeyword}%'";
                    searchBtn.Text = "Сбросить поиск";
                }
                else if (dataGridView2.DataSource is DataTable dataTable)
                {
                    dataTable.DefaultView.RowFilter = $"Фамилия LIKE '%{searchKeyword}%'";
                    searchBtn.Text = "Сбросить поиск";
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            if (form4.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Замените dataGridView3 на имя вашей таблицы продаж на экране Form1
                    this.продажиTableAdapter.Fill(this.бД_автосалонDataSet.Продажи);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Сделка сохранена, но не удалось обновить таблицу: {ex.Message}");
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (dataGridView3.CurrentRow == null || dataGridView3.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Пожалуйста, выберите существующую запись продажи для удаления.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите безвозвратно удалить запись об этой сделке?",
                "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                var row = dataGridView3.CurrentRow;

                if (row.Cells[0].Value == null || string.IsNullOrEmpty(row.Cells[0].Value.ToString()))
                {
                    MessageBox.Show("Не удалось считать ID продажи.");
                    return;
                }

                int idПродажи = Convert.ToInt32(row.Cells[0].Value);
                string query = "DELETE FROM Продажи WHERE [ID_Продажи] = ?";
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\БД автосалон.accdb";

                try
                {
                    using (OleDbConnection con = new OleDbConnection(connectionString))
                    {
                        using (OleDbCommand cmd = new OleDbCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@ID_Продажи", idПродажи);

                            con.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Запись успешно удалена!");
                                this.продажиTableAdapter.Fill(this.бД_автосалонDataSet.Продажи);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка удаления записи: {ex.Message}");
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Button searchBtn = (Button)sender;

            // Сброс активного поиска
            if (searchBtn.Text == "Сбросить поиск")
            {
                if (dataGridView3.DataSource is BindingSource bs) bs.RemoveFilter();
                else if (dataGridView3.DataSource is DataTable dt) dt.DefaultView.RowFilter = "";

                searchBtn.Text = "Найти";
                return;
            }

            // Окно запроса ID автомобиля
            Form prompt = new Form()
            {
                Width = 350,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Поиск продажи",
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label textLabel = new Label() { Left = 20, Top = 20, Text = "Введите ID Автомобиля:", Width = 300 };
            TextBox textBox = new TextBox() { Left = 20, Top = 45, Width = 290 };
            Button confirmation = new Button() { Text = "ОК", Left = 210, Width = 100, Top = 80, DialogResult = DialogResult.OK };

            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            if (prompt.ShowDialog() == DialogResult.OK)
            {
                string searchKeyword = textBox.Text.Trim();

                if (string.IsNullOrEmpty(searchKeyword)) return;

                // Фильтруем целочисленное поле ID_Автомобиля (без использования оператора LIKE, так как это число)
                if (dataGridView3.DataSource is BindingSource bindingSource)
                {
                    bindingSource.Filter = $"ID_Автомобиля = {searchKeyword}";
                    searchBtn.Text = "Сбросить поиск";
                }
                else if (dataGridView3.DataSource is DataTable dataTable)
                {
                    dataTable.DefaultView.RowFilter = $"ID_Автомобиля = {searchKeyword}";
                    searchBtn.Text = "Сбросить поиск";
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            if (form5.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Обновляем отображение сотрудников на экране Form1
                    // Замените dataGridView4 на реальное имя таблицы сотрудников на вашей форме
                    this.сотрудникиTableAdapter.Fill(this.бД_автосалонDataSet.Сотрудники);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Данные сохранены, но не удалось обновить таблицу: {ex.Message}");
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (dataGridView4.CurrentRow == null || dataGridView4.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Пожалуйста, выберите существующую строку с сотрудником для удаления.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить выбранного сотрудника?",
                "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                var row = dataGridView4.CurrentRow;

                if (row.Cells[0].Value == null || string.IsNullOrEmpty(row.Cells[0].Value.ToString()))
                {
                    MessageBox.Show("Не удалось считать ID сотрудника.");
                    return;
                }

                int idСотрудника = Convert.ToInt32(row.Cells[0].Value);
                string query = "DELETE FROM Сотрудники WHERE [ID_Сотрудника] = ?";
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\БД автосалон.accdb";

                try
                {
                    using (OleDbConnection con = new OleDbConnection(connectionString))
                    {
                        using (OleDbCommand cmd = new OleDbCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@ID_Сотрудника", idСотрудника);

                            con.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Сотрудник успешно удален!");
                                this.сотрудникиTableAdapter.Fill(this.бД_автосалонDataSet.Сотрудники);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении: {ex.Message}");
                }
            }       
            }

        private void button12_Click(object sender, EventArgs e)
        {
            Button searchBtn = (Button)sender;

            // Сброс активного фильтра
            if (searchBtn.Text == "Сбросить поиск")
            {
                if (dataGridView4.DataSource is BindingSource bs) bs.RemoveFilter();
                else if (dataGridView4.DataSource is DataTable dt) dt.DefaultView.RowFilter = "";

                searchBtn.Text = "Найти";
                return;
            }

            // Создаем диалоговое окно ввода программно
            Form prompt = new Form()
            {
                Width = 350,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Поиск сотрудника",
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label textLabel = new Label() { Left = 20, Top = 20, Text = "Введите фамилию сотрудника:", Width = 300 };
            TextBox textBox = new TextBox() { Left = 20, Top = 45, Width = 290 };
            Button confirmation = new Button() { Text = "ОК", Left = 210, Width = 100, Top = 80, DialogResult = DialogResult.OK };

            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            if (prompt.ShowDialog() == DialogResult.OK)
            {
                string searchKeyword = textBox.Text.Trim();

                if (string.IsNullOrEmpty(searchKeyword)) return;

                // Фильтруем данные по колонке "Фамилия" для таблицы сотрудников
                if (dataGridView4.DataSource is BindingSource bindingSource)
                {
                    bindingSource.Filter = $"Фамилия LIKE '%{searchKeyword}%'";
                    searchBtn.Text = "Сбросить поиск";
                }
                else if (dataGridView4.DataSource is DataTable dataTable)
                {
                    dataTable.DefaultView.RowFilter = $"Фамилия LIKE '%{searchKeyword}%'";
                    searchBtn.Text = "Сбросить поиск";
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            if (form6.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Обновляем таблицу тест-драйвов на экране Form1
                    // Замените dataGridView5 на реальное имя таблицы тест-драйвов на вашей форме
                    this.тест_драйвTableAdapter.Fill(this.бД_автосалонDataSet._Тест_драйв);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Данные сохранены, но не удалось обновить таблицу: {ex.Message}");
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Button searchBtn = (Button)sender;

            // Сброс активного поиска
            if (searchBtn.Text == "Сбросить поиск")
            {
                if (dataGridView5.DataSource is BindingSource bs) bs.RemoveFilter();
                else if (dataGridView5.DataSource is DataTable dt) dt.DefaultView.RowFilter = "";

                searchBtn.Text = "Найти";
                return;
            }

            // Окно запроса ID покупателя
            Form prompt = new Form()
            {
                Width = 350,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Поиск тест-драйва",
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label textLabel = new Label() { Left = 20, Top = 20, Text = "Введите ID Покупателя:", Width = 300 };
            TextBox textBox = new TextBox() { Left = 20, Top = 45, Width = 290 };
            Button confirmation = new Button() { Text = "ОК", Left = 210, Width = 100, Top = 80, DialogResult = DialogResult.OK };

            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            if (prompt.ShowDialog() == DialogResult.OK)
            {
                string searchKeyword = textBox.Text.Trim();

                if (string.IsNullOrEmpty(searchKeyword)) return;

                // Фильтруем целочисленное поле ID_Покупателя (без LIKE, так как это число)
                if (dataGridView5.DataSource is BindingSource bindingSource)
                {
                    bindingSource.Filter = $"ID_Покупателя = {searchKeyword}";
                    searchBtn.Text = "Сбросить поиск";
                }
                else if (dataGridView5.DataSource is DataTable dataTable)
                {
                    dataTable.DefaultView.RowFilter = $"ID_Покупателя = {searchKeyword}";
                    searchBtn.Text = "Сбросить поиск";
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (dataGridView5.CurrentRow == null || dataGridView5.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Пожалуйста, выберите существующую запись тест-драйва для удаления.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите отменить и удалить эту запись тест-драйва?",
                "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                var row = dataGridView5.CurrentRow;

                if (row.Cells[0].Value == null || string.IsNullOrEmpty(row.Cells[0].Value.ToString()))
                {
                    MessageBox.Show("Не удалось считать ID записи.");
                    return;
                }

                int idЗаписи = Convert.ToInt32(row.Cells[0].Value);
                string query = "DELETE FROM [Тест-драйв] WHERE [ID_Записи] = ?";
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\БД автосалон.accdb";

                try
                {
                    using (OleDbConnection con = new OleDbConnection(connectionString))
                    {
                        using (OleDbCommand cmd = new OleDbCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@ID_Записи", idЗаписи);

                            con.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Запись успешно удалена!");
                                this.тест_драйвTableAdapter.Fill(this.бД_автосалонDataSet._Тест_драйв);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка удаления записи: {ex.Message}");
                }
            }
        }
    }
}
