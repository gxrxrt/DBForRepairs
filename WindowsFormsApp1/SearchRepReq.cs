using DataBaseLib;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class SearchRepReq : Form
    {
        static DB db = new DB();
        static private MySqlConnection connection = db.GetConnection();

        public SearchRepReq()
        {
            InitializeComponent();
            InitializeComponents();

            LoadMasters();
            LoadClients();
            LoadModels();
        }

        private void InitializeComponents()
        {
            // Создание элементов управления
            this.textBoxProblemDesc = new System.Windows.Forms.TextBox();
            this.dateTimePickerRequestDate = new System.Windows.Forms.DateTimePicker();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.comboBoxMasters = new System.Windows.Forms.ComboBox();
            this.comboBoxClients = new System.Windows.Forms.ComboBox();
            this.comboBoxModels = new System.Windows.Forms.ComboBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.dataGridViewResults = new System.Windows.Forms.DataGridView();
            this.labelCount = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();

            // Настройка элементов управления
            this.textBoxProblemDesc.Location = new System.Drawing.Point(12, 12);
            this.textBoxProblemDesc.Size = new System.Drawing.Size(200, 20);
            this.textBoxProblemDesc.Text = "Описание проблемы";

            this.dateTimePickerRequestDate.Location = new System.Drawing.Point(12, 38);
            this.dateTimePickerRequestDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerRequestDate.CustomFormat = " ";
            this.dateTimePickerRequestDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerRequestDate.ShowCheckBox = true;

            this.comboBoxStatus.Location = new System.Drawing.Point(12, 64);
            this.comboBoxStatus.Size = new System.Drawing.Size(200, 21);
            this.comboBoxStatus.Items.AddRange(new string[] { "Ожидание", "В процессе ремонта", "Готова к выдаче", "Новая заявка" });

            this.comboBoxMasters.Location = new System.Drawing.Point(12, 91);
            this.comboBoxMasters.Size = new System.Drawing.Size(200, 21);

            this.comboBoxClients.Location = new System.Drawing.Point(12, 118);
            this.comboBoxClients.Size = new System.Drawing.Size(200, 21);

            this.comboBoxModels.Location = new System.Drawing.Point(12, 145);
            this.comboBoxModels.Size = new System.Drawing.Size(200, 21);

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
            this.Controls.Add(this.textBoxProblemDesc);
            this.Controls.Add(this.dateTimePickerRequestDate);
            this.Controls.Add(this.comboBoxStatus);
            this.Controls.Add(this.comboBoxMasters);
            this.Controls.Add(this.comboBoxClients);
            this.Controls.Add(this.comboBoxModels);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.dataGridViewResults);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.buttonClose);

            // Настройка формы
            this.ClientSize = new System.Drawing.Size(850, 450);
            this.Text = "Поиск заявок на ремонт";
        }

        public void LoadMasters()
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
        public void LoadClients()
        {
            string query = "SELECT full_name FROM customers";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
            DataTable clientsTable = new DataTable();
            adapter.Fill(clientsTable);

            foreach (DataRow row in clientsTable.Rows)
            {
                comboBoxClients.Items.Add(row["full_name"].ToString());
            }
        }

        public void LoadModels()
        {
            string query = "SELECT CONCAT(modelName, ' (', modelType, ')') AS model FROM models";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
            DataTable modelsTable = new DataTable();
            adapter.Fill(modelsTable);

            foreach (DataRow row in modelsTable.Rows)
            {
                comboBoxModels.Items.Add(row["model"].ToString());
            }
        }
        public void buttonSearch_Click(object sender, EventArgs e)
        {
            string problemDesc = textBoxProblemDesc.Text;
            DateTime? selectedDate = dateTimePickerRequestDate.Value;
            string status = comboBoxStatus.SelectedItem?.ToString();
            string master = comboBoxMasters.SelectedItem?.ToString();
            string client = comboBoxClients.SelectedItem?.ToString();
            string model = comboBoxModels.SelectedItem?.ToString();

            // Начинаем с основного запроса
            string query = "SELECT rr.request_id, rr.problemDescryption, rr.start_date, rr.requestStatus, " +
                           "rr.repairParts, m.full_name AS masterFullName, c.full_name AS clientFullName, " +
                           "CONCAT(mo.modelName, ' (', mo.modelType, ')') AS model " +
                           "FROM repairrequests rr " +
                           "LEFT JOIN masters m ON rr.masterID = m.master_id " +
                           "LEFT JOIN customers c ON rr.customerID = c.customer_id " +
                           "LEFT JOIN models mo ON rr.modelID = mo.modelID WHERE 1=1";

            // Добавляем условия поиска только для заполненных полей
            if (!string.IsNullOrEmpty(problemDesc))
            {
                query += $" AND rr.problemDescryption LIKE '%{problemDesc}%'";
            }

            if (dateTimePickerRequestDate.Checked)
            {
                query += $" AND rr.start_date = '{selectedDate.Value.ToString("yyyy-MM-dd")}'";
            }

            if (!string.IsNullOrEmpty(status))
            {
                query += $" AND rr.requestStatus = '{status}'";
            }

            if (!string.IsNullOrEmpty(master))
            {
                query += $" AND m.full_name = '{master}'";
            }

            if (!string.IsNullOrEmpty(client))
            {
                query += $" AND c.full_name = '{client}'";
            }

            if (!string.IsNullOrEmpty(model))
            {
                query += $" AND CONCAT(mo.modelName, ' (', mo.modelType, ')') = '{model}'";
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
            string query = "SELECT COUNT(*) FROM repairrequests";
            MySqlCommand command = new MySqlCommand(query, connection);

            return Convert.ToInt32(command.ExecuteScalar());
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private TextBox textBoxProblemDesc;
        private DateTimePicker dateTimePickerRequestDate;
        private ComboBox comboBoxStatus;
        public ComboBox comboBoxMasters;
        public ComboBox comboBoxClients;
        private ComboBox comboBoxModels;
        private Button buttonSearch;
        public DataGridView dataGridViewResults;
        private Label labelCount;
        private Button buttonClose;
    }
}
