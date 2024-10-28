using DataBaseLib;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class SearchRepairs : Form
    {
        static DB db = new DB();
        static private MySqlConnection connection = db.GetConnection();

        public SearchRepairs()
        {
            InitializeComponent();
            InitializeComponents();
            LoadMasters();
        }

        private void InitializeComponents()
        {
            // Создание элементов управления
            this.comboBoxMasters = new System.Windows.Forms.ComboBox();
            this.dateTimePickerRepairDate = new System.Windows.Forms.DateTimePicker();
            this.checkBoxUseDate = new System.Windows.Forms.CheckBox();
            this.textBoxLaborHours = new System.Windows.Forms.TextBox();
            this.textBoxTotalCost = new System.Windows.Forms.TextBox();
            this.textBoxRepairReport = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.dataGridViewResults = new System.Windows.Forms.DataGridView();
            this.labelCount = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();

            // Настройка элементов управления
            this.comboBoxMasters.Location = new System.Drawing.Point(12, 12);
            this.comboBoxMasters.Size = new System.Drawing.Size(200, 21);

            this.dateTimePickerRepairDate.Location = new System.Drawing.Point(12, 38);
            this.dateTimePickerRepairDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerRepairDate.CustomFormat = " ";
            this.dateTimePickerRepairDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerRepairDate.ShowCheckBox = true;

            this.checkBoxUseDate.Location = new System.Drawing.Point(12, 64);
            this.checkBoxUseDate.Text = "Использовать дату ремонта";
            this.checkBoxUseDate.CheckedChanged += (sender, e) =>
            {
                dateTimePickerRepairDate.Enabled = checkBoxUseDate.Checked;
                if (!checkBoxUseDate.Checked)
                {
                    dateTimePickerRepairDate.Value = DateTime.Now;
                }
            };

            this.textBoxLaborHours.Location = new System.Drawing.Point(12, 91);
            this.textBoxLaborHours.Size = new System.Drawing.Size(200, 20);
            this.textBoxLaborHours.Text = "Часы работы";

            this.textBoxTotalCost.Location = new System.Drawing.Point(12, 117);
            this.textBoxTotalCost.Size = new System.Drawing.Size(200, 20);
            this.textBoxTotalCost.Text = "Стоимость";

            this.textBoxRepairReport.Location = new System.Drawing.Point(12, 143);
            this.textBoxRepairReport.Size = new System.Drawing.Size(200, 20);
            this.textBoxRepairReport.Text = "Отчёт о ремонте";

            this.buttonSearch.Location = new System.Drawing.Point(12, 172);
            this.buttonSearch.Text = "Поиск";
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);

            this.dataGridViewResults.Location = new System.Drawing.Point(220, 12);
            this.dataGridViewResults.Size = new System.Drawing.Size(600, 400);

            this.labelCount.Location = new System.Drawing.Point(220, 420);
            this.labelCount.Size = new System.Drawing.Size(100, 20);

            this.buttonClose.Location = new System.Drawing.Point(12, 205);
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);

            // Добавление элементов управления на форму
            this.Controls.Add(this.comboBoxMasters);
            this.Controls.Add(this.dateTimePickerRepairDate);
            this.Controls.Add(this.checkBoxUseDate);
            this.Controls.Add(this.textBoxLaborHours);
            this.Controls.Add(this.textBoxTotalCost);
            this.Controls.Add(this.textBoxRepairReport);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.dataGridViewResults);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.buttonClose);

            // Настройка формы
            this.ClientSize = new System.Drawing.Size(850, 450);
            this.Text = "Поиск ремонтов";
        }

        private void LoadMasters()
        {
            string query = "SELECT full_name FROM masters";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
            DataTable mastersTable = new DataTable();
            adapter.Fill(mastersTable);

            foreach (DataRow row in mastersTable.Rows)
            {
                comboBoxMasters.Items.Add(row["full_name"].ToString());
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string master = comboBoxMasters.SelectedItem?.ToString();
            DateTime? selectedDate = dateTimePickerRepairDate.Value;
            string laborHours = textBoxLaborHours.Text;
            string totalCost = textBoxTotalCost.Text;
            string repairReport = textBoxRepairReport.Text;

            // Начинаем с основного запроса
            string query = "SELECT r.repair_id, r.repair_date, r.labor_hours, r.total_cost, r.repair_report, m.full_name AS masterFullName " +
                           "FROM Repairs r " +
                           "LEFT JOIN masters m ON r.master_id = m.master_id WHERE 1=1";

            // Добавляем условия поиска только для заполненных полей
            if (!string.IsNullOrEmpty(master))
            {
                query += $" AND m.full_name = '{master}'";
            }

            if (checkBoxUseDate.Checked)
            {
                query += $" AND r.repair_date = '{selectedDate.Value.ToString("yyyy-MM-dd")}'";
            }

            if (!string.IsNullOrEmpty(laborHours))
            {
                query += $" AND r.labor_hours LIKE '%{laborHours}%'";
            }

            if (!string.IsNullOrEmpty(totalCost))
            {
                query += $" AND r.total_cost LIKE '%{totalCost}%'";
            }

            if (!string.IsNullOrEmpty(repairReport))
            {
                query += $" AND r.repair_report LIKE '%{repairReport}%'";
            }

            // Выполняем запрос и заполняем DataGridView
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            dataGridViewResults.DataSource = dataTable;
            labelCount.Text = $"{dataTable.Rows.Count} из {GetTotalCount()}"; // Обновление количества записей
        }

        private int GetTotalCount()
        {
            db.openConnection();
            string query = "SELECT COUNT(*) FROM Repairs";
            MySqlCommand command = new MySqlCommand(query, connection);

            return Convert.ToInt32(command.ExecuteScalar());
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private ComboBox comboBoxMasters;
        private DateTimePicker dateTimePickerRepairDate;
        private CheckBox checkBoxUseDate;
        private TextBox textBoxLaborHours;
        private TextBox textBoxTotalCost;
        private TextBox textBoxRepairReport;
        private Button buttonSearch;
        private DataGridView dataGridViewResults;
        private Label labelCount;
        private Button buttonClose;
    }
}
