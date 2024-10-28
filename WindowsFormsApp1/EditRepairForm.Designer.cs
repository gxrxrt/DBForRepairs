namespace WindowsFormsApp1
{
    partial class EditRepairForm
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
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxLaborHours = new System.Windows.Forms.TextBox();
            this.dateTimePickerRepairDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxRequests = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxMasters = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxTotalCost = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxRepairReport = new System.Windows.Forms.TextBox();
            this.btnSaveMaster = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(267, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(76, 28);
            this.button2.TabIndex = 32;
            this.button2.Text = "Назад";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxLaborHours
            // 
            this.textBoxLaborHours.Location = new System.Drawing.Point(50, 221);
            this.textBoxLaborHours.Name = "textBoxLaborHours";
            this.textBoxLaborHours.Size = new System.Drawing.Size(239, 20);
            this.textBoxLaborHours.TabIndex = 30;
            // 
            // dateTimePickerRepairDate
            // 
            this.dateTimePickerRepairDate.Location = new System.Drawing.Point(50, 155);
            this.dateTimePickerRepairDate.Name = "dateTimePickerRepairDate";
            this.dateTimePickerRepairDate.Size = new System.Drawing.Size(239, 20);
            this.dateTimePickerRepairDate.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(98, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 21);
            this.label1.TabIndex = 28;
            this.label1.Text = "Номер заявки";
            // 
            // comboBoxRequests
            // 
            this.comboBoxRequests.FormattingEnabled = true;
            this.comboBoxRequests.Location = new System.Drawing.Point(50, 38);
            this.comboBoxRequests.Name = "comboBoxRequests";
            this.comboBoxRequests.Size = new System.Drawing.Size(239, 21);
            this.comboBoxRequests.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(98, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 21);
            this.label2.TabIndex = 34;
            this.label2.Text = "Номер мастера";
            // 
            // comboBoxMasters
            // 
            this.comboBoxMasters.FormattingEnabled = true;
            this.comboBoxMasters.Location = new System.Drawing.Point(50, 96);
            this.comboBoxMasters.Name = "comboBoxMasters";
            this.comboBoxMasters.Size = new System.Drawing.Size(239, 21);
            this.comboBoxMasters.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(108, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 21);
            this.label3.TabIndex = 36;
            this.label3.Text = "Дата ремонта";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(111, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 21);
            this.label4.TabIndex = 37;
            this.label4.Text = "Часы работы";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(142, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 21);
            this.label5.TabIndex = 39;
            this.label5.Text = "Цена";
            // 
            // textBoxTotalCost
            // 
            this.textBoxTotalCost.Location = new System.Drawing.Point(50, 277);
            this.textBoxTotalCost.Name = "textBoxTotalCost";
            this.textBoxTotalCost.Size = new System.Drawing.Size(239, 20);
            this.textBoxTotalCost.TabIndex = 38;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(142, 300);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 21);
            this.label6.TabIndex = 41;
            this.label6.Text = "Отчёт";
            // 
            // textBoxRepairReport
            // 
            this.textBoxRepairReport.Location = new System.Drawing.Point(50, 324);
            this.textBoxRepairReport.Name = "textBoxRepairReport";
            this.textBoxRepairReport.Size = new System.Drawing.Size(239, 20);
            this.textBoxRepairReport.TabIndex = 40;
            // 
            // btnSaveMaster
            // 
            this.btnSaveMaster.ForeColor = System.Drawing.Color.Black;
            this.btnSaveMaster.Location = new System.Drawing.Point(112, 350);
            this.btnSaveMaster.Name = "btnSaveMaster";
            this.btnSaveMaster.Size = new System.Drawing.Size(107, 36);
            this.btnSaveMaster.TabIndex = 42;
            this.btnSaveMaster.Text = "Сохранить";
            this.btnSaveMaster.UseVisualStyleBackColor = true;
            this.btnSaveMaster.Click += new System.EventHandler(this.btnSaveMaster_Click);
            // 
            // EditRepairForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 404);
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
            this.Name = "EditRepairForm";
            this.Text = "EditRepairForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxLaborHours;
        private System.Windows.Forms.DateTimePicker dateTimePickerRepairDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxRequests;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxMasters;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxTotalCost;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxRepairReport;
        private System.Windows.Forms.Button btnSaveMaster;
    }
}