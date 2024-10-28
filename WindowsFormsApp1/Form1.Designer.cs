namespace WindowsFormsApp1
{
    partial class MainForm
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
            this.results = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonSearchRepairs = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.Masters = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonSearchMasters = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.ShowRequests = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonSearchRepairreq = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.addRequest = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxModels = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxClients = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxMasters = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxRepairParts = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxProblemDesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerRequestDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.RoleLabel = new System.Windows.Forms.Label();
            this.FullnameLabel = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.results.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.Masters.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.ShowRequests.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.addRequest.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // results
            // 
            this.results.Controls.Add(this.button13);
            this.results.Controls.Add(this.panel3);
            this.results.Controls.Add(this.dataGridView3);
            this.results.Location = new System.Drawing.Point(4, 30);
            this.results.Name = "results";
            this.results.Padding = new System.Windows.Forms.Padding(3);
            this.results.Size = new System.Drawing.Size(1213, 477);
            this.results.TabIndex = 3;
            this.results.Text = "Отчёты";
            this.results.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonSearchRepairs);
            this.panel3.Controls.Add(this.button7);
            this.panel3.Controls.Add(this.button9);
            this.panel3.Controls.Add(this.button8);
            this.panel3.Location = new System.Drawing.Point(6, 414);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(565, 57);
            this.panel3.TabIndex = 7;
            // 
            // buttonSearchRepairs
            // 
            this.buttonSearchRepairs.Location = new System.Drawing.Point(420, 3);
            this.buttonSearchRepairs.Name = "buttonSearchRepairs";
            this.buttonSearchRepairs.Size = new System.Drawing.Size(133, 40);
            this.buttonSearchRepairs.TabIndex = 7;
            this.buttonSearchRepairs.Text = "Найти";
            this.buttonSearchRepairs.UseVisualStyleBackColor = true;
            this.buttonSearchRepairs.Click += new System.EventHandler(this.buttonSearchRepairs_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(281, 3);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(133, 40);
            this.button7.TabIndex = 6;
            this.button7.Text = "Удалить";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(3, 3);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(133, 40);
            this.button9.TabIndex = 4;
            this.button9.Text = "Добавить";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(142, 3);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(133, 40);
            this.button8.TabIndex = 5;
            this.button8.Text = "Редактировать";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(3, 6);
            this.dataGridView3.MultiSelect = false;
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView3.Size = new System.Drawing.Size(1204, 405);
            this.dataGridView3.TabIndex = 1;
            this.dataGridView3.SelectionChanged += new System.EventHandler(this.dataGridView3_SelectionChanged);
            // 
            // Masters
            // 
            this.Masters.Controls.Add(this.button12);
            this.Masters.Controls.Add(this.panel2);
            this.Masters.Controls.Add(this.dataGridView2);
            this.Masters.Location = new System.Drawing.Point(4, 30);
            this.Masters.Name = "Masters";
            this.Masters.Padding = new System.Windows.Forms.Padding(3);
            this.Masters.Size = new System.Drawing.Size(1213, 477);
            this.Masters.TabIndex = 2;
            this.Masters.Text = "Управление персоналом";
            this.Masters.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonSearchMasters);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Location = new System.Drawing.Point(12, 417);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(555, 54);
            this.panel2.TabIndex = 4;
            // 
            // buttonSearchMasters
            // 
            this.buttonSearchMasters.Location = new System.Drawing.Point(417, 3);
            this.buttonSearchMasters.Name = "buttonSearchMasters";
            this.buttonSearchMasters.Size = new System.Drawing.Size(133, 40);
            this.buttonSearchMasters.TabIndex = 9;
            this.buttonSearchMasters.Text = "Найти";
            this.buttonSearchMasters.UseVisualStyleBackColor = true;
            this.buttonSearchMasters.Click += new System.EventHandler(this.buttonSearchMasters_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(281, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(130, 40);
            this.button4.TabIndex = 3;
            this.button4.Text = "Удалить";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 40);
            this.button2.TabIndex = 1;
            this.button2.Text = "Добавить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(142, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(133, 40);
            this.button3.TabIndex = 2;
            this.button3.Text = "Редактировать";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(-4, 9);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(1195, 405);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.SelectionChanged += new System.EventHandler(this.dataGridView2_SelectionChanged);
            // 
            // ShowRequests
            // 
            this.ShowRequests.Controls.Add(this.button11);
            this.ShowRequests.Controls.Add(this.panel1);
            this.ShowRequests.Controls.Add(this.dataGridView1);
            this.ShowRequests.Location = new System.Drawing.Point(4, 30);
            this.ShowRequests.Name = "ShowRequests";
            this.ShowRequests.Padding = new System.Windows.Forms.Padding(3);
            this.ShowRequests.Size = new System.Drawing.Size(1213, 477);
            this.ShowRequests.TabIndex = 1;
            this.ShowRequests.Text = "Просмотр заявок";
            this.ShowRequests.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonSearchRepairreq);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Location = new System.Drawing.Point(6, 417);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 51);
            this.panel1.TabIndex = 8;
            // 
            // buttonSearchRepairreq
            // 
            this.buttonSearchRepairreq.Location = new System.Drawing.Point(281, 5);
            this.buttonSearchRepairreq.Name = "buttonSearchRepairreq";
            this.buttonSearchRepairreq.Size = new System.Drawing.Size(133, 40);
            this.buttonSearchRepairreq.TabIndex = 8;
            this.buttonSearchRepairreq.Text = "Найти";
            this.buttonSearchRepairreq.UseVisualStyleBackColor = true;
            this.buttonSearchRepairreq.Click += new System.EventHandler(this.buttonSearchRepairreq_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(142, 6);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(133, 40);
            this.button5.TabIndex = 7;
            this.button5.Text = "Удалить";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(3, 6);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(133, 40);
            this.button6.TabIndex = 6;
            this.button6.Text = "Редактировать";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(-4, 6);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1211, 405);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // addRequest
            // 
            this.addRequest.Controls.Add(this.button1);
            this.addRequest.Controls.Add(this.comboBoxModels);
            this.addRequest.Controls.Add(this.label6);
            this.addRequest.Controls.Add(this.comboBoxClients);
            this.addRequest.Controls.Add(this.label5);
            this.addRequest.Controls.Add(this.comboBoxMasters);
            this.addRequest.Controls.Add(this.label4);
            this.addRequest.Controls.Add(this.textBoxRepairParts);
            this.addRequest.Controls.Add(this.label3);
            this.addRequest.Controls.Add(this.textBoxProblemDesc);
            this.addRequest.Controls.Add(this.label2);
            this.addRequest.Controls.Add(this.dateTimePickerRequestDate);
            this.addRequest.Controls.Add(this.label1);
            this.addRequest.Location = new System.Drawing.Point(4, 30);
            this.addRequest.Name = "addRequest";
            this.addRequest.Padding = new System.Windows.Forms.Padding(3);
            this.addRequest.Size = new System.Drawing.Size(1213, 477);
            this.addRequest.TabIndex = 0;
            this.addRequest.Text = "Добавить заяку";
            this.addRequest.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button1.Location = new System.Drawing.Point(24, 422);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 36);
            this.button1.TabIndex = 13;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxModels
            // 
            this.comboBoxModels.FormattingEnabled = true;
            this.comboBoxModels.Location = new System.Drawing.Point(24, 375);
            this.comboBoxModels.Name = "comboBoxModels";
            this.comboBoxModels.Size = new System.Drawing.Size(239, 29);
            this.comboBoxModels.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(20, 350);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 21);
            this.label6.TabIndex = 11;
            this.label6.Text = "Модель";
            // 
            // comboBoxClients
            // 
            this.comboBoxClients.FormattingEnabled = true;
            this.comboBoxClients.Location = new System.Drawing.Point(24, 302);
            this.comboBoxClients.Name = "comboBoxClients";
            this.comboBoxClients.Size = new System.Drawing.Size(239, 29);
            this.comboBoxClients.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(20, 277);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 21);
            this.label5.TabIndex = 9;
            this.label5.Text = "Клиент";
            // 
            // comboBoxMasters
            // 
            this.comboBoxMasters.FormattingEnabled = true;
            this.comboBoxMasters.Location = new System.Drawing.Point(24, 234);
            this.comboBoxMasters.Name = "comboBoxMasters";
            this.comboBoxMasters.Size = new System.Drawing.Size(239, 29);
            this.comboBoxMasters.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(20, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "Мастер";
            // 
            // textBoxRepairParts
            // 
            this.textBoxRepairParts.Location = new System.Drawing.Point(24, 168);
            this.textBoxRepairParts.Name = "textBoxRepairParts";
            this.textBoxRepairParts.Size = new System.Drawing.Size(239, 26);
            this.textBoxRepairParts.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(20, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Необходимые запчасти";
            // 
            // textBoxProblemDesc
            // 
            this.textBoxProblemDesc.Location = new System.Drawing.Point(24, 96);
            this.textBoxProblemDesc.Name = "textBoxProblemDesc";
            this.textBoxProblemDesc.Size = new System.Drawing.Size(239, 26);
            this.textBoxProblemDesc.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(20, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Описание проблемы";
            // 
            // dateTimePickerRequestDate
            // 
            this.dateTimePickerRequestDate.Location = new System.Drawing.Point(24, 32);
            this.dateTimePickerRequestDate.Name = "dateTimePickerRequestDate";
            this.dateTimePickerRequestDate.Size = new System.Drawing.Size(200, 26);
            this.dateTimePickerRequestDate.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(20, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Дата обращения:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.addRequest);
            this.tabControl1.Controls.Add(this.ShowRequests);
            this.tabControl1.Controls.Add(this.Masters);
            this.tabControl1.Controls.Add(this.results);
            this.tabControl1.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1221, 511);
            this.tabControl1.TabIndex = 0;
            // 
            // RoleLabel
            // 
            this.RoleLabel.AutoSize = true;
            this.RoleLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RoleLabel.Location = new System.Drawing.Point(12, 625);
            this.RoleLabel.Name = "RoleLabel";
            this.RoleLabel.Size = new System.Drawing.Size(47, 21);
            this.RoleLabel.TabIndex = 14;
            this.RoleLabel.Text = "Роль:";
            // 
            // FullnameLabel
            // 
            this.FullnameLabel.AutoSize = true;
            this.FullnameLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FullnameLabel.Location = new System.Drawing.Point(12, 604);
            this.FullnameLabel.Name = "FullnameLabel";
            this.FullnameLabel.Size = new System.Drawing.Size(47, 21);
            this.FullnameLabel.TabIndex = 15;
            this.FullnameLabel.Text = "ФИО:";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(1161, 516);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(65, 25);
            this.button10.TabIndex = 7;
            this.button10.Text = "Назад";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApp1.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(16, 516);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(88, 85);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // button11
            // 
            this.button11.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.update;
            this.button11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button11.Location = new System.Drawing.Point(1145, 417);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(62, 51);
            this.button11.TabIndex = 14;
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.update;
            this.button12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button12.Location = new System.Drawing.Point(1145, 415);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(62, 51);
            this.button12.TabIndex = 15;
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button13
            // 
            this.button13.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.update;
            this.button13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button13.Location = new System.Drawing.Point(1145, 417);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(62, 51);
            this.button13.TabIndex = 16;
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 655);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.FullnameLabel);
            this.Controls.Add(this.RoleLabel);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.results.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.Masters.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ShowRequests.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.addRequest.ResumeLayout(false);
            this.addRequest.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage results;
        private System.Windows.Forms.TabPage Masters;
        private System.Windows.Forms.TabPage ShowRequests;
        private System.Windows.Forms.TabPage addRequest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.DateTimePicker dateTimePickerRequestDate;
        private System.Windows.Forms.TextBox textBoxProblemDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxRepairParts;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBoxModels;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxClients;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxMasters;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.DataGridView dataGridView3;
        public System.Windows.Forms.Label FullnameLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label RoleLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button buttonSearchRepairreq;
        private System.Windows.Forms.Button buttonSearchMasters;
        private System.Windows.Forms.Button buttonSearchRepairs;
    }
}

