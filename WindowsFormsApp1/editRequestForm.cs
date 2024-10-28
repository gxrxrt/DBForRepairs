using DataBaseLib;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class editRequestForm : Form
    {
        int requestID;
        DB db = new DB();

        public editRequestForm(int id)
        {
            InitializeComponent();

            LoadMastersComboBox();
            LoadCustomersComboBox();
            LoadModelsComboBox();

            requestID = id;
            LoadRequestData(requestID);
        }
        // Метод для загрузки данных в форму и установки значений для редактирования
        private void LoadRequestData(int requestID)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT * FROM repairrequests WHERE request_id = @requestID", db.GetConnection());
            command.Parameters.Add("@requestID", MySqlDbType.Int32).Value = requestID;

            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                // Заполняем текстовые поля
                textBoxProblemDesc.Text = reader["problemDescryption"].ToString();
                dateTimePickerRequestDate.Value = Convert.ToDateTime(reader["start_date"]);
                textBoxRepairParts.Text = reader["repairParts"].ToString();

                // Устанавливаем выбранное значение в ComboBox
                comboBoxMasters.SelectedValue = reader["masterID"];
                comboBoxClients.SelectedValue = reader["customerID"];
                comboBoxModels.SelectedValue = reader["modelID"];
            }

            reader.Close();
            db.closeConnection();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            db.openConnection();

            string query = "UPDATE repairrequests SET start_date = @start_date, problemDescryption = @problemDesc, repairParts = @repairParts, masterID = @masterID, customerID = @customerID, modelID = @modelID WHERE request_id = @id";
            MySqlCommand command = new MySqlCommand(query, db.GetConnection());

            command.Parameters.AddWithValue("@start_date", dateTimePickerRequestDate.Value);
            command.Parameters.AddWithValue("@problemDesc", textBoxProblemDesc.Text);
            command.Parameters.AddWithValue("@repairParts", textBoxRepairParts.Text);
            command.Parameters.AddWithValue("@masterID", comboBoxMasters.SelectedValue);
            command.Parameters.AddWithValue("@customerID", comboBoxClients.SelectedValue);
            command.Parameters.AddWithValue("@modelID", comboBoxModels.SelectedValue);
            command.Parameters.AddWithValue("@id", requestID);

            // Выполнение запроса
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Запись успешно обновлена!");
            }
            else
            {
                MessageBox.Show("Ошибка при обновлении записи.");
            }

            db.closeConnection();

            Close();
        }

        // Метод для загрузки данных мастеров в ComboBox
        private void LoadMastersComboBox()
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT master_id, full_name FROM masters", db.GetConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            comboBoxMasters.DataSource = table;
            comboBoxMasters.DisplayMember = "full_name";
            comboBoxMasters.ValueMember = "master_id";
        }

        // Метод для загрузки данных клиентов в ComboBox
        private void LoadCustomersComboBox()
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT customer_id, full_name FROM customers", db.GetConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            comboBoxClients.DataSource = table;
            comboBoxClients.DisplayMember = "full_name";
            comboBoxClients.ValueMember = "customer_id";
        }

        // Метод для загрузки данных моделей в ComboBox
        private void LoadModelsComboBox()
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT modelID, CONCAT(modelName, ' - ', modelType) AS modelFullName FROM models", db.GetConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            comboBoxModels.DataSource = table;
            comboBoxModels.DisplayMember = "modelFullName";
            comboBoxModels.ValueMember = "modelID";
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
