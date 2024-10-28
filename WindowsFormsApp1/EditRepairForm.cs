using DataBaseLib;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class EditRepairForm : Form
    {
        int repairID;
        public EditRepairForm(int selectedRepairId)
        {
            InitializeComponent();
            repairID = selectedRepairId;
            LoadRepairData();
            LoadMastersComboBox();
            LoadRequestsComboBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void LoadRepairData()
        {
            DB db = new DB();
            string query = "SELECT request_id, master_id, repair_date, labor_hours, total_cost, repair_report FROM repairs WHERE repair_id = @repairId";

            MySqlCommand command = new MySqlCommand(query, db.GetConnection());
            command.Parameters.Add("@repairId", MySqlDbType.Int32).Value = repairID;

            db.openConnection();

            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                // Заполняем поля формы данными из базы
                comboBoxRequests.SelectedValue = reader["request_id"].ToString();
                comboBoxMasters.SelectedValue = reader["master_id"].ToString();
                dateTimePickerRepairDate.Value = Convert.ToDateTime(reader["repair_date"]);
                textBoxLaborHours.Text = reader["labor_hours"].ToString();
                textBoxTotalCost.Text = reader["total_cost"].ToString();
                textBoxRepairReport.Text = reader["repair_report"].ToString();
            }

            db.closeConnection();
        }

        // Метод для загрузки списка мастеров в ComboBox
        private void LoadMastersComboBox()
        {
            DB db = new DB();
            string query = "SELECT master_id, full_name FROM masters";

            MySqlDataAdapter adapter = new MySqlDataAdapter(query, db.GetConnection());
            DataTable mastersTable = new DataTable();
            adapter.Fill(mastersTable);

            comboBoxMasters.DataSource = mastersTable;
            comboBoxMasters.DisplayMember = "full_name";
            comboBoxMasters.ValueMember = "master_id";
        }

        // Метод для загрузки списка заявок в ComboBox
        private void LoadRequestsComboBox()
        {
            DB db = new DB();
            string query = "SELECT request_id, CONCAT(request_id, ' - ', problemDescryption) AS requestDisplay FROM repairrequests";

            MySqlDataAdapter adapter = new MySqlDataAdapter(query, db.GetConnection());
            DataTable requestsTable = new DataTable();
            adapter.Fill(requestsTable);

            comboBoxRequests.DataSource = requestsTable;
            comboBoxRequests.DisplayMember = "requestDisplay";  // Показываем и ID, и описание
            comboBoxRequests.ValueMember = "request_id";  // Для обработки используем request_id
        }


        private void btnSaveMaster_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            string query = "UPDATE repairs SET request_id = @requestId, master_id = @masterId, repair_date = @repairDate, labor_hours = @laborHours, total_cost = @totalCost, repair_report = @repairReport WHERE repair_id = @repairId";

            MySqlCommand command = new MySqlCommand(query, db.GetConnection());
            command.Parameters.Add("@requestId", MySqlDbType.Int32).Value = comboBoxRequests.SelectedValue;
            command.Parameters.Add("@masterId", MySqlDbType.Int32).Value = comboBoxMasters.SelectedValue;
            command.Parameters.Add("@repairDate", MySqlDbType.Date).Value = dateTimePickerRepairDate.Value;
            command.Parameters.Add("@laborHours", MySqlDbType.Decimal).Value = Convert.ToDecimal(textBoxLaborHours.Text);
            command.Parameters.Add("@totalCost", MySqlDbType.Decimal).Value = Convert.ToDecimal(textBoxTotalCost.Text);
            command.Parameters.Add("@repairReport", MySqlDbType.Text).Value = textBoxRepairReport.Text;
            command.Parameters.Add("@repairId", MySqlDbType.Int32).Value = repairID;

            db.openConnection();

            if (command.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Данные о ремонте успешно обновлены.");
                this.Close();  // Закрываем форму после успешного сохранения
            }
            else
            {
                MessageBox.Show("Ошибка при обновлении данных о ремонте.");
            }

            db.closeConnection();
        }
    }
}
