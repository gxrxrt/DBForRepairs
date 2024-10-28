namespace WindowsFormsApp1
{
    partial class AddRepairForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSaveMaster = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxRepairReport = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxTotalCost = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxMasters = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxRequests = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxLaborHours = new System.Windows.Forms.TextBox();
            this.dateTimePickerRepairDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSaveMaster
            // 
            this.btnSaveMaster.ForeColor = System.Drawing.Color.Black;
            this.btnSaveMaster.Location = new System.Drawing.Point(106, 378);
            this.btnSaveMaster.Name = "btnSaveMaster";
            this.btnSaveMaster.Size = new System.Drawing.Size(107, 36);
            this.btnSaveMaster.TabIndex = 56;
            this.btnSaveMaster.Text = "Добавить";
            this.btnSaveMaster.UseVisualStyleBackColor = true;
            this.btnSaveMaster.Click += new System.EventHandler(this.btnSaveMaster_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(136, 307);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 21);
            this.label6.TabIndex = 55;
            this.label6.Text = "Отчёт";
            // 
            // textBoxRepairReport
            // 
            this.textBoxRepairReport.Location = new System.Drawing.Point(44, 331);
            this.textBoxRepairReport.Name = "textBoxRepairReport";
            this.textBoxRepairReport.Size = new System.Drawing.Size(239, 20);
            this.textBoxRepairReport.TabIndex = 54;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(136, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 21);
            this.label5.TabIndex = 53;
            this.label5.Text = "Цена";
            // 
            // textBoxTotalCost
            // 
            this.textBoxTotalCost.Location = new System.Drawing.Point(44, 284);
            this.textBoxTotalCost.Name = "textBoxTotalCost";
            this.textBoxTotalCost.Size = new System.Drawing.Size(239, 20);
            this.textBoxTotalCost.TabIndex = 52;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(105, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 21);
            this.label4.TabIndex = 51;
            this.label4.Text = "Часы работы";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(102, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 21);
            this.label3.TabIndex = 50;
            this.label3.Text = "Дата ремонта";
            // 
            // comboBoxMasters
            // 
            this.comboBoxMasters.FormattingEnabled = true;
            this.comboBoxMasters.Location = new System.Drawing.Point(44, 103);
            this.comboBoxMasters.Name = "comboBoxMasters";
            this.comboBoxMasters.Size = new System.Drawing.Size(239, 21);
            this.comboBoxMasters.TabIndex = 49;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(92, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 21);
            this.label2.TabIndex = 48;
            this.label2.Text = "Номер мастера";
            // 
            // comboBoxRequests
            // 
            this.comboBoxRequests.FormattingEnabled = true;
            this.comboBoxRequests.Location = new System.Drawing.Point(44, 45);
            this.comboBoxRequests.Name = "comboBoxRequests";
            this.comboBoxRequests.Size = new System.Drawing.Size(239, 21);
            this.comboBoxRequests.TabIndex = 47;
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(240, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(76, 28);
            this.button2.TabIndex = 46;
            this.button2.Text = "Назад";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxLaborHours
            // 
            this.textBoxLaborHours.Location = new System.Drawing.Point(44, 228);
            this.textBoxLaborHours.Name = "textBoxLaborHours";
            this.textBoxLaborHours.Size = new System.Drawing.Size(239, 20);
            this.textBoxLaborHours.TabIndex = 45;
            // 
            // dateTimePickerRepairDate
            // 
            this.dateTimePickerRepairDate.Location = new System.Drawing.Point(44, 162);
            this.dateTimePickerRepairDate.Name = "dateTimePickerRepairDate";
            this.dateTimePickerRepairDate.Size = new System.Drawing.Size(239, 20);
            this.dateTimePickerRepairDate.TabIndex = 44;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(92, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 21);
            this.label1.TabIndex = 43;
            this.label1.Text = "Номер заявки";
            // 
            // AddRepairForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 450);
            this.Controls.Add(this.btnSaveMaster);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxRepairReport);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxTotalCost);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxMasters);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxRequests);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBoxLaborHours);
            this.Controls.Add(this.dateTimePickerRepairDate);
            this.Controls.Add(this.label1);
            this.Name = "AddRepairForm";
            this.Text = "AddRepairForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaveMaster;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxRepairReport;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxTotalCost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxMasters;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxRequests;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxLaborHours;
        private System.Windows.Forms.DateTimePicker dateTimePickerRepairDate;
        private System.Windows.Forms.Label label1;
    }
}