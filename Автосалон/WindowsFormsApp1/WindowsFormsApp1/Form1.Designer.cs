namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDАвтомобиляDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.маркаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.модельDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.годВыпускаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ценаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.статусDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.количествоDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.автомобилиBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.бД_автосалонDataSet = new WindowsFormsApp1.БД_автосалонDataSet();
            this.автомобилиTableAdapter = new WindowsFormsApp1.БД_автосалонDataSetTableAdapters.АвтомобилиTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.покупателиBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.покупателиTableAdapter = new WindowsFormsApp1.БД_автосалонDataSetTableAdapters.ПокупателиTableAdapter();
            this.iDПокупателяDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.фамилияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.имяDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.отчествоDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.адресDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.телефонDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.продажиBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.продажиTableAdapter = new WindowsFormsApp1.БД_автосалонDataSetTableAdapters.ПродажиTableAdapter();
            this.iDПродажиDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDАвтомобиляDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDПокупателяDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDСотрудникаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.допПакетDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.трейдинDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.кредитDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.датаПродажиDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.общаяСтоимостьDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.сотрудникиBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.сотрудникиTableAdapter = new WindowsFormsApp1.БД_автосалонDataSetTableAdapters.СотрудникиTableAdapter();
            this.iDСотрудникаDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.фамилияDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.имяDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.отчествоDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.должностьDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            this.тестдрайвBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.тест_драйвTableAdapter = new WindowsFormsApp1.БД_автосалонDataSetTableAdapters.Тест_драйвTableAdapter();
            this.iDЗаписиDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDАвтомобиляDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDПокупателяDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDСотрудникаDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.датаПроведенияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.автомобилиBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.бД_автосалонDataSet)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.покупателиBindingSource)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.продажиBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.сотрудникиBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.тестдрайвBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDАвтомобиляDataGridViewTextBoxColumn,
            this.маркаDataGridViewTextBoxColumn,
            this.модельDataGridViewTextBoxColumn,
            this.годВыпускаDataGridViewTextBoxColumn,
            this.ценаDataGridViewTextBoxColumn,
            this.статусDataGridViewTextBoxColumn,
            this.количествоDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.автомобилиBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(792, 392);
            this.dataGridView1.TabIndex = 0;
            // 
            // iDАвтомобиляDataGridViewTextBoxColumn
            // 
            this.iDАвтомобиляDataGridViewTextBoxColumn.DataPropertyName = "ID_Автомобиля";
            this.iDАвтомобиляDataGridViewTextBoxColumn.HeaderText = "ID_Автомобиля";
            this.iDАвтомобиляDataGridViewTextBoxColumn.Name = "iDАвтомобиляDataGridViewTextBoxColumn";
            // 
            // маркаDataGridViewTextBoxColumn
            // 
            this.маркаDataGridViewTextBoxColumn.DataPropertyName = "Марка";
            this.маркаDataGridViewTextBoxColumn.HeaderText = "Марка";
            this.маркаDataGridViewTextBoxColumn.Name = "маркаDataGridViewTextBoxColumn";
            // 
            // модельDataGridViewTextBoxColumn
            // 
            this.модельDataGridViewTextBoxColumn.DataPropertyName = "Модель";
            this.модельDataGridViewTextBoxColumn.HeaderText = "Модель";
            this.модельDataGridViewTextBoxColumn.Name = "модельDataGridViewTextBoxColumn";
            // 
            // годВыпускаDataGridViewTextBoxColumn
            // 
            this.годВыпускаDataGridViewTextBoxColumn.DataPropertyName = "Год выпуска";
            this.годВыпускаDataGridViewTextBoxColumn.HeaderText = "Год выпуска";
            this.годВыпускаDataGridViewTextBoxColumn.Name = "годВыпускаDataGridViewTextBoxColumn";
            // 
            // ценаDataGridViewTextBoxColumn
            // 
            this.ценаDataGridViewTextBoxColumn.DataPropertyName = "Цена";
            this.ценаDataGridViewTextBoxColumn.HeaderText = "Цена";
            this.ценаDataGridViewTextBoxColumn.Name = "ценаDataGridViewTextBoxColumn";
            // 
            // статусDataGridViewTextBoxColumn
            // 
            this.статусDataGridViewTextBoxColumn.DataPropertyName = "Статус";
            this.статусDataGridViewTextBoxColumn.HeaderText = "Статус";
            this.статусDataGridViewTextBoxColumn.Name = "статусDataGridViewTextBoxColumn";
            // 
            // количествоDataGridViewTextBoxColumn
            // 
            this.количествоDataGridViewTextBoxColumn.DataPropertyName = "Количество";
            this.количествоDataGridViewTextBoxColumn.HeaderText = "Количество";
            this.количествоDataGridViewTextBoxColumn.Name = "количествоDataGridViewTextBoxColumn";
            // 
            // автомобилиBindingSource
            // 
            this.автомобилиBindingSource.DataMember = "Автомобили";
            this.автомобилиBindingSource.DataSource = this.бД_автосалонDataSet;
            // 
            // бД_автосалонDataSet
            // 
            this.бД_автосалонDataSet.DataSetName = "БД_автосалонDataSet";
            this.бД_автосалонDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // автомобилиTableAdapter
            // 
            this.автомобилиTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 398);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(84, 398);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Удалить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(165, 398);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Найти";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 450);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.Tag = "";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 424);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Автомобили";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button6);
            this.tabPage2.Controls.Add(this.button5);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 424);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Покупатели";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDПокупателяDataGridViewTextBoxColumn,
            this.фамилияDataGridViewTextBoxColumn,
            this.имяDataGridViewTextBoxColumn,
            this.отчествоDataGridViewTextBoxColumn,
            this.адресDataGridViewTextBoxColumn,
            this.телефонDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.покупателиBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(792, 394);
            this.dataGridView2.TabIndex = 0;
            // 
            // покупателиBindingSource
            // 
            this.покупателиBindingSource.DataMember = "Покупатели";
            this.покупателиBindingSource.DataSource = this.бД_автосалонDataSet;
            // 
            // покупателиTableAdapter
            // 
            this.покупателиTableAdapter.ClearBeforeFill = true;
            // 
            // iDПокупателяDataGridViewTextBoxColumn
            // 
            this.iDПокупателяDataGridViewTextBoxColumn.DataPropertyName = "ID_Покупателя";
            this.iDПокупателяDataGridViewTextBoxColumn.HeaderText = "ID_Покупателя";
            this.iDПокупателяDataGridViewTextBoxColumn.Name = "iDПокупателяDataGridViewTextBoxColumn";
            // 
            // фамилияDataGridViewTextBoxColumn
            // 
            this.фамилияDataGridViewTextBoxColumn.DataPropertyName = "Фамилия";
            this.фамилияDataGridViewTextBoxColumn.HeaderText = "Фамилия";
            this.фамилияDataGridViewTextBoxColumn.Name = "фамилияDataGridViewTextBoxColumn";
            // 
            // имяDataGridViewTextBoxColumn
            // 
            this.имяDataGridViewTextBoxColumn.DataPropertyName = "Имя";
            this.имяDataGridViewTextBoxColumn.HeaderText = "Имя";
            this.имяDataGridViewTextBoxColumn.Name = "имяDataGridViewTextBoxColumn";
            // 
            // отчествоDataGridViewTextBoxColumn
            // 
            this.отчествоDataGridViewTextBoxColumn.DataPropertyName = "Отчество";
            this.отчествоDataGridViewTextBoxColumn.HeaderText = "Отчество";
            this.отчествоDataGridViewTextBoxColumn.Name = "отчествоDataGridViewTextBoxColumn";
            // 
            // адресDataGridViewTextBoxColumn
            // 
            this.адресDataGridViewTextBoxColumn.DataPropertyName = "Адрес";
            this.адресDataGridViewTextBoxColumn.HeaderText = "Адрес";
            this.адресDataGridViewTextBoxColumn.Name = "адресDataGridViewTextBoxColumn";
            // 
            // телефонDataGridViewTextBoxColumn
            // 
            this.телефонDataGridViewTextBoxColumn.DataPropertyName = "Телефон";
            this.телефонDataGridViewTextBoxColumn.HeaderText = "Телефон";
            this.телефонDataGridViewTextBoxColumn.Name = "телефонDataGridViewTextBoxColumn";
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(3, 398);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 1;
            this.button4.Text = "Добавить";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(84, 398);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 2;
            this.button5.Text = "Удалить";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(165, 398);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 3;
            this.button6.Text = "Найти";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button9);
            this.tabPage3.Controls.Add(this.button8);
            this.tabPage3.Controls.Add(this.button7);
            this.tabPage3.Controls.Add(this.dataGridView3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(792, 424);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Продажи";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button12);
            this.tabPage4.Controls.Add(this.button11);
            this.tabPage4.Controls.Add(this.button10);
            this.tabPage4.Controls.Add(this.dataGridView4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(792, 424);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Сотрудники";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.button15);
            this.tabPage5.Controls.Add(this.button14);
            this.tabPage5.Controls.Add(this.button13);
            this.tabPage5.Controls.Add(this.dataGridView5);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(792, 424);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Тест-драйв";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AutoGenerateColumns = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDПродажиDataGridViewTextBoxColumn,
            this.iDАвтомобиляDataGridViewTextBoxColumn1,
            this.iDПокупателяDataGridViewTextBoxColumn1,
            this.iDСотрудникаDataGridViewTextBoxColumn,
            this.допПакетDataGridViewCheckBoxColumn,
            this.трейдинDataGridViewCheckBoxColumn,
            this.кредитDataGridViewCheckBoxColumn,
            this.датаПродажиDataGridViewTextBoxColumn,
            this.общаяСтоимостьDataGridViewTextBoxColumn});
            this.dataGridView3.DataSource = this.продажиBindingSource;
            this.dataGridView3.Location = new System.Drawing.Point(0, 0);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(792, 400);
            this.dataGridView3.TabIndex = 0;
            // 
            // продажиBindingSource
            // 
            this.продажиBindingSource.DataMember = "Продажи";
            this.продажиBindingSource.DataSource = this.бД_автосалонDataSet;
            // 
            // продажиTableAdapter
            // 
            this.продажиTableAdapter.ClearBeforeFill = true;
            // 
            // iDПродажиDataGridViewTextBoxColumn
            // 
            this.iDПродажиDataGridViewTextBoxColumn.DataPropertyName = "ID_Продажи";
            this.iDПродажиDataGridViewTextBoxColumn.HeaderText = "ID_Продажи";
            this.iDПродажиDataGridViewTextBoxColumn.Name = "iDПродажиDataGridViewTextBoxColumn";
            // 
            // iDАвтомобиляDataGridViewTextBoxColumn1
            // 
            this.iDАвтомобиляDataGridViewTextBoxColumn1.DataPropertyName = "ID_Автомобиля";
            this.iDАвтомобиляDataGridViewTextBoxColumn1.HeaderText = "ID_Автомобиля";
            this.iDАвтомобиляDataGridViewTextBoxColumn1.Name = "iDАвтомобиляDataGridViewTextBoxColumn1";
            // 
            // iDПокупателяDataGridViewTextBoxColumn1
            // 
            this.iDПокупателяDataGridViewTextBoxColumn1.DataPropertyName = "ID_Покупателя";
            this.iDПокупателяDataGridViewTextBoxColumn1.HeaderText = "ID_Покупателя";
            this.iDПокупателяDataGridViewTextBoxColumn1.Name = "iDПокупателяDataGridViewTextBoxColumn1";
            // 
            // iDСотрудникаDataGridViewTextBoxColumn
            // 
            this.iDСотрудникаDataGridViewTextBoxColumn.DataPropertyName = "ID_Сотрудника";
            this.iDСотрудникаDataGridViewTextBoxColumn.HeaderText = "ID_Сотрудника";
            this.iDСотрудникаDataGridViewTextBoxColumn.Name = "iDСотрудникаDataGridViewTextBoxColumn";
            // 
            // допПакетDataGridViewCheckBoxColumn
            // 
            this.допПакетDataGridViewCheckBoxColumn.DataPropertyName = "Доп пакет";
            this.допПакетDataGridViewCheckBoxColumn.HeaderText = "Доп пакет";
            this.допПакетDataGridViewCheckBoxColumn.Name = "допПакетDataGridViewCheckBoxColumn";
            // 
            // трейдинDataGridViewCheckBoxColumn
            // 
            this.трейдинDataGridViewCheckBoxColumn.DataPropertyName = "Трейд-ин";
            this.трейдинDataGridViewCheckBoxColumn.HeaderText = "Трейд-ин";
            this.трейдинDataGridViewCheckBoxColumn.Name = "трейдинDataGridViewCheckBoxColumn";
            // 
            // кредитDataGridViewCheckBoxColumn
            // 
            this.кредитDataGridViewCheckBoxColumn.DataPropertyName = "Кредит";
            this.кредитDataGridViewCheckBoxColumn.HeaderText = "Кредит";
            this.кредитDataGridViewCheckBoxColumn.Name = "кредитDataGridViewCheckBoxColumn";
            // 
            // датаПродажиDataGridViewTextBoxColumn
            // 
            this.датаПродажиDataGridViewTextBoxColumn.DataPropertyName = "Дата продажи";
            this.датаПродажиDataGridViewTextBoxColumn.HeaderText = "Дата продажи";
            this.датаПродажиDataGridViewTextBoxColumn.Name = "датаПродажиDataGridViewTextBoxColumn";
            // 
            // общаяСтоимостьDataGridViewTextBoxColumn
            // 
            this.общаяСтоимостьDataGridViewTextBoxColumn.DataPropertyName = "Общая стоимость";
            this.общаяСтоимостьDataGridViewTextBoxColumn.HeaderText = "Общая стоимость";
            this.общаяСтоимостьDataGridViewTextBoxColumn.Name = "общаяСтоимостьDataGridViewTextBoxColumn";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(3, 401);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 1;
            this.button7.Text = "Добавить";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(96, 401);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 2;
            this.button8.Text = "Удалить";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(186, 401);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 3;
            this.button9.Text = "Найти";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // dataGridView4
            // 
            this.dataGridView4.AutoGenerateColumns = false;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDСотрудникаDataGridViewTextBoxColumn1,
            this.фамилияDataGridViewTextBoxColumn1,
            this.имяDataGridViewTextBoxColumn1,
            this.отчествоDataGridViewTextBoxColumn1,
            this.должностьDataGridViewTextBoxColumn});
            this.dataGridView4.DataSource = this.сотрудникиBindingSource;
            this.dataGridView4.Location = new System.Drawing.Point(0, 0);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(792, 396);
            this.dataGridView4.TabIndex = 0;
            // 
            // сотрудникиBindingSource
            // 
            this.сотрудникиBindingSource.DataMember = "Сотрудники";
            this.сотрудникиBindingSource.DataSource = this.бД_автосалонDataSet;
            // 
            // сотрудникиTableAdapter
            // 
            this.сотрудникиTableAdapter.ClearBeforeFill = true;
            // 
            // iDСотрудникаDataGridViewTextBoxColumn1
            // 
            this.iDСотрудникаDataGridViewTextBoxColumn1.DataPropertyName = "ID_Сотрудника";
            this.iDСотрудникаDataGridViewTextBoxColumn1.HeaderText = "ID_Сотрудника";
            this.iDСотрудникаDataGridViewTextBoxColumn1.Name = "iDСотрудникаDataGridViewTextBoxColumn1";
            // 
            // фамилияDataGridViewTextBoxColumn1
            // 
            this.фамилияDataGridViewTextBoxColumn1.DataPropertyName = "Фамилия";
            this.фамилияDataGridViewTextBoxColumn1.HeaderText = "Фамилия";
            this.фамилияDataGridViewTextBoxColumn1.Name = "фамилияDataGridViewTextBoxColumn1";
            // 
            // имяDataGridViewTextBoxColumn1
            // 
            this.имяDataGridViewTextBoxColumn1.DataPropertyName = "Имя";
            this.имяDataGridViewTextBoxColumn1.HeaderText = "Имя";
            this.имяDataGridViewTextBoxColumn1.Name = "имяDataGridViewTextBoxColumn1";
            // 
            // отчествоDataGridViewTextBoxColumn1
            // 
            this.отчествоDataGridViewTextBoxColumn1.DataPropertyName = "Отчество";
            this.отчествоDataGridViewTextBoxColumn1.HeaderText = "Отчество";
            this.отчествоDataGridViewTextBoxColumn1.Name = "отчествоDataGridViewTextBoxColumn1";
            // 
            // должностьDataGridViewTextBoxColumn
            // 
            this.должностьDataGridViewTextBoxColumn.DataPropertyName = "Должность";
            this.должностьDataGridViewTextBoxColumn.HeaderText = "Должность";
            this.должностьDataGridViewTextBoxColumn.Name = "должностьDataGridViewTextBoxColumn";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(5, 402);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 1;
            this.button10.Text = "Добавить";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(86, 402);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 23);
            this.button11.TabIndex = 2;
            this.button11.Text = "Удалить";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(167, 402);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 23);
            this.button12.TabIndex = 3;
            this.button12.Text = "Найти";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // dataGridView5
            // 
            this.dataGridView5.AutoGenerateColumns = false;
            this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView5.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDЗаписиDataGridViewTextBoxColumn,
            this.iDАвтомобиляDataGridViewTextBoxColumn2,
            this.iDПокупателяDataGridViewTextBoxColumn2,
            this.iDСотрудникаDataGridViewTextBoxColumn2,
            this.датаПроведенияDataGridViewTextBoxColumn});
            this.dataGridView5.DataSource = this.тестдрайвBindingSource;
            this.dataGridView5.Location = new System.Drawing.Point(0, 0);
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.Size = new System.Drawing.Size(784, 397);
            this.dataGridView5.TabIndex = 0;
            // 
            // тестдрайвBindingSource
            // 
            this.тестдрайвBindingSource.DataMember = "Тест-драйв";
            this.тестдрайвBindingSource.DataSource = this.бД_автосалонDataSet;
            // 
            // тест_драйвTableAdapter
            // 
            this.тест_драйвTableAdapter.ClearBeforeFill = true;
            // 
            // iDЗаписиDataGridViewTextBoxColumn
            // 
            this.iDЗаписиDataGridViewTextBoxColumn.DataPropertyName = "ID_Записи";
            this.iDЗаписиDataGridViewTextBoxColumn.HeaderText = "ID_Записи";
            this.iDЗаписиDataGridViewTextBoxColumn.Name = "iDЗаписиDataGridViewTextBoxColumn";
            // 
            // iDАвтомобиляDataGridViewTextBoxColumn2
            // 
            this.iDАвтомобиляDataGridViewTextBoxColumn2.DataPropertyName = "ID_Автомобиля";
            this.iDАвтомобиляDataGridViewTextBoxColumn2.HeaderText = "ID_Автомобиля";
            this.iDАвтомобиляDataGridViewTextBoxColumn2.Name = "iDАвтомобиляDataGridViewTextBoxColumn2";
            // 
            // iDПокупателяDataGridViewTextBoxColumn2
            // 
            this.iDПокупателяDataGridViewTextBoxColumn2.DataPropertyName = "ID_Покупателя";
            this.iDПокупателяDataGridViewTextBoxColumn2.HeaderText = "ID_Покупателя";
            this.iDПокупателяDataGridViewTextBoxColumn2.Name = "iDПокупателяDataGridViewTextBoxColumn2";
            // 
            // iDСотрудникаDataGridViewTextBoxColumn2
            // 
            this.iDСотрудникаDataGridViewTextBoxColumn2.DataPropertyName = "ID_Сотрудника";
            this.iDСотрудникаDataGridViewTextBoxColumn2.HeaderText = "ID_Сотрудника";
            this.iDСотрудникаDataGridViewTextBoxColumn2.Name = "iDСотрудникаDataGridViewTextBoxColumn2";
            // 
            // датаПроведенияDataGridViewTextBoxColumn
            // 
            this.датаПроведенияDataGridViewTextBoxColumn.DataPropertyName = "Дата проведения";
            this.датаПроведенияDataGridViewTextBoxColumn.HeaderText = "Дата проведения";
            this.датаПроведенияDataGridViewTextBoxColumn.Name = "датаПроведенияDataGridViewTextBoxColumn";
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(6, 402);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(75, 23);
            this.button13.TabIndex = 1;
            this.button13.Text = "Добавить";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(113, 402);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(75, 23);
            this.button14.TabIndex = 2;
            this.button14.Text = "Удалить";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(217, 401);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(75, 23);
            this.button15.TabIndex = 3;
            this.button15.Text = "Найти";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.автомобилиBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.бД_автосалонDataSet)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.покупателиBindingSource)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.продажиBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.сотрудникиBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.тестдрайвBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private БД_автосалонDataSet бД_автосалонDataSet;
        private System.Windows.Forms.BindingSource автомобилиBindingSource;
        private БД_автосалонDataSetTableAdapters.АвтомобилиTableAdapter автомобилиTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDАвтомобиляDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn маркаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn модельDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn годВыпускаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ценаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn статусDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn количествоDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.BindingSource покупателиBindingSource;
        private БД_автосалонDataSetTableAdapters.ПокупателиTableAdapter покупателиTableAdapter;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDПокупателяDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn фамилияDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn имяDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn отчествоDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn адресDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn телефонDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.BindingSource продажиBindingSource;
        private БД_автосалонDataSetTableAdapters.ПродажиTableAdapter продажиTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDПродажиDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDАвтомобиляDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDПокупателяDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDСотрудникаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn допПакетDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn трейдинDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn кредитDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn датаПродажиDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn общаяСтоимостьDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.BindingSource сотрудникиBindingSource;
        private БД_автосалонDataSetTableAdapters.СотрудникиTableAdapter сотрудникиTableAdapter;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDСотрудникаDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn фамилияDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn имяDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn отчествоDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn должностьDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dataGridView5;
        private System.Windows.Forms.BindingSource тестдрайвBindingSource;
        private БД_автосалонDataSetTableAdapters.Тест_драйвTableAdapter тест_драйвTableAdapter;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDЗаписиDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDАвтомобиляDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDПокупателяDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDСотрудникаDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn датаПроведенияDataGridViewTextBoxColumn;
        //  private System.Windows.Forms.ToolStripMenuItem автомобилиToolStripMenuItem;
    }
}

