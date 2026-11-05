using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form0 : Form
    {
        // Временная база данных в памяти (Логин -> Пароль)
        private static Dictionary<string, string> users = new Dictionary<string, string>()
        {
            { "admin", "1234" } // Дефолтный пользователь для теста
        };

        // Сетевой путь к вашей базе данных
        private readonly string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\192.168.3.250\Veda\3 курс\ИСП 33\МДК 03.02\Васильев Елькин\Автосалон — копия\WindowsFormsApp1\WindowsFormsApp1\БД автосалон.accdb";

        public Form0()
        {
            InitializeComponent();
        }

        // Кнопка "Войти" на вкладке авторизации
        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, заполните логин и пароль.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. ВСТРОЕННАЯ ПРОВЕРКА ДЛЯ АДМИНИСТРАТОРА (Открывает Form1)
            if (username == "admin" && password == "1234")
            {
                MessageBox.Show("Авторизация успешна (Встроенный Administrator)!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ОткрытьГлавнуюФорму(isAdmin: true);
                return;
            }

            // 2. БЕЗОПАСНАЯ ПРОВЕРКА ОСТАЛЬНЫХ ПОЛЬЗОВАТЕЛЕЙ (Открывает Form7)
            try
            {
                using (OleDbConnection con = new OleDbConnection(connectionString))
                {
                    con.Open();

                    string loginQuery = "SELECT COUNT(*) FROM [Пользователи] WHERE [Логин] = ? AND [Пароль] = ?";

                    using (OleDbCommand cmd = new OleDbCommand(loginQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@Логин", username);
                        cmd.Parameters.AddWithValue("@Пароль", password);

                        // Безопасное извлечение значения без вылета ошибки формата
                        object result = cmd.ExecuteScalar();
                        int userExists = 0;

                        if (result != null && result != DBNull.Value)
                        {
                            int.TryParse(result.ToString(), out userExists);
                        }

                        if (userExists > 0)
                        {
                            MessageBox.Show("Авторизация успешна!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            con.Close();
                            ОткрытьГлавнуюФорму(isAdmin: false);
                        }
                        else
                        {
                            MessageBox.Show("Неверный логин или пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при авторизации:\n{ex.Message}", "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Кнопка "Зарегистрироваться" на вкладке регистрации
        private void button2_Click(object sender, EventArgs e)
        {
            string username = textBox3.Text.Trim();
            string password = textBox4.Text;
            string confirmPassword = textBox5.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Поля не могут быть пустыми.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Пароли не совпадают.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (username == "admin")
            {
                MessageBox.Show("Логин 'admin' зарезервирован системой.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (OleDbConnection con = new OleDbConnection(connectionString))
                {
                    con.Open();

                    string createTableQuery = "CREATE TABLE [Пользователи] (" +
                                              "[Логин] TEXT(50) PRIMARY KEY, " +
                                              "[Пароль] TEXT(50))";

                    var schemaTable = con.GetSchema("Tables", new string[] { null, null, "Пользователи", "TABLE" });
                    if (schemaTable.Rows.Count == 0)
                    {
                        using (OleDbCommand cmdCreate = new OleDbCommand(createTableQuery, con))
                        {
                            cmdCreate.ExecuteNonQuery();
                        }
                    }

                    string checkUserQuery = "SELECT COUNT(*) FROM [Пользователи] WHERE [Логин] = ?";
                    using (OleDbCommand cmdCheck = new OleDbCommand(checkUserQuery, con))
                    {
                        cmdCheck.Parameters.AddWithValue("@Логин", username);

                        object checkResult = cmdCheck.ExecuteScalar();
                        int userCount = 0;
                        if (checkResult != null && checkResult != DBNull.Value)
                        {
                            int.TryParse(checkResult.ToString(), out userCount);
                        }

                        if (userCount > 0)
                        {
                            MessageBox.Show("Пользователь с таким логином уже существует в базе.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    string insertQuery = "INSERT INTO [Пользователи] ([Логин], [Пароль]) VALUES (?, ?)";
                    using (OleDbCommand cmdInsert = new OleDbCommand(insertQuery, con))
                    {
                        cmdInsert.Parameters.AddWithValue("@Логин", username);
                        cmdInsert.Parameters.AddWithValue("@Пароль", password);

                        cmdInsert.ExecuteNonQuery();
                    }

                    con.Close();
                }

                OleDbConnection.ReleaseObjectPool();

                MessageBox.Show("Регистрация завершена! Данные сохранены в базу.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();

                tabControl1.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при работе с базой данных: {ex.Message}", "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ОткрытьГлавнуюФорму(bool isAdmin)
        {
            this.Hide();

            if (isAdmin)
            {
                Form1 adminForm = new Form1();
                adminForm.ShowDialog();
            }
            else
            {
                Form7 userForm = new Form7();
                userForm.ShowDialog();
            }

            this.Close();
        }
    }
}
