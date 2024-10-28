using DataBaseLib;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AddRepairForm : Form
    {
        public AddRepairForm()
        {
            InitializeComponent();
            LoadComboBoxData();

        }
        private void LoadComboBoxData()
        {
            DB db = new DB();

            // Загрузка данных для ComboBox с мастерами
            MySqlDataAdapter mastersAdapter = new MySqlDataAdapter("SELECT master_id, full_name FROM masters", db.GetConnection());
            DataTable mastersTable = new DataTable();
            mastersAdapter.Fill(mastersTable);
            comboBoxMasters.DataSource = mastersTable;
            comboBoxMasters.DisplayMember = "full_name";
            comboBoxMasters.ValueMember = "master_id";

            // Загрузка данных для ComboBox с заявками
            string query = "SELECT request_id, CONCAT(request_id, ' - ', problemDescryption) AS requestDisplay FROM repairrequests";
            MySqlDataAdapter requestsAdapter = new MySqlDataAdapter(query, db.GetConnection());
            DataTable requestsTable = new DataTable();
            requestsAdapter.Fill(requestsTable);
            comboBoxRequests.DataSource = requestsTable;
            comboBoxRequests.DisplayMember = "requestDisplay";
            comboBoxRequests.ValueMember = "request_id";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSaveMaster_Click(object sender, EventArgs e)
        {
            // Получаем значения из текстовых полей
            int masterId = Convert.ToInt32(comboBoxMasters.SelectedValue);
            int requestId = Convert.ToInt32(comboBoxRequests.SelectedValue);
            DateTime repairDate = dateTimePickerRepairDate.Value;
            decimal laborHours = Convert.ToDecimal(textBoxLaborHours.Text);
            decimal totalCost = Convert.ToDecimal(textBoxTotalCost.Text);
            string repairReport = textBoxRepairReport.Text;

            // Проверяем, что все поля заполнены
            if (laborHours <= 0 || totalCost <= 0 || string.IsNullOrEmpty(repairReport))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Вставляем данные в таблицу repairs
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO repairs (request_id, master_id, repair_date, labor_hours, total_cost, repair_report) VALUES (@requestId, @masterId, @repairDate, @laborHours, @totalCost, @repairReport)", db.GetConnection());

            command.Parameters.Add("@requestId", MySqlDbType.Int32).Value = requestId;
            command.Parameters.Add("@masterId", MySqlDbType.Int32).Value = masterId;
            command.Parameters.Add("@repairDate", MySqlDbType.Date).Value = repairDate;
            command.Parameters.Add("@laborHours", MySqlDbType.Decimal).Value = laborHours;
            command.Parameters.Add("@totalCost", MySqlDbType.Decimal).Value = totalCost;
            command.Parameters.Add("@repairReport", MySqlDbType.Text).Value = repairReport;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Ремонт успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ошибка при добавлении ремонта.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            db.closeConnection();
        }
    }
}
