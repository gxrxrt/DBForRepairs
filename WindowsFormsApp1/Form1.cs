using DataBaseLib;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        DB db = new DB();
        int selectedRequestID = -1;
        int selectedMasterID = -1;
        int selectedRepairID = -1;

        public enum Role
        {
            None,
            Manager, //Может управлять персоналом
            Master, // Может доабвлять, просматривать, изменять заявки и отчёты
            Operator // Может добавлять, просматривать и изменять заявки
        }

        public Role masterRole = Role.None;

        public MainForm()
        {

            InitializeComponent();

            AuthorizationForm auth = new AuthorizationForm(this);
            auth.ShowDialog();
            GetPermissions();
        }
        public void GetPermissions()
        {
            if (masterRole == Role.Master)
            {
                button1.Visible = true;
                panel1.Visible = true;
                panel3.Visible = true;

                panel2.Visible = false;
            }
            if (masterRole == Role.Operator)
            {
                button1.Visible = true;
                panel1.Visible = true;

                panel2.Visible = false;
                panel3.Visible = false;
            }
            if (masterRole == Role.Manager)
            {
                panel2.Visible = true;

                button1.Visible = false;
                panel1.Visible = false;
                panel3.Visible = false;
            }
            if (masterRole == Role.None)
            {
                tabControl1.Visible = false;
                MessageBox.Show("Несанкционированный вход в систему, перезагрузите программу!");
            }
        }

        private void button10_Click(object sender, System.EventArgs e)
        {
            Hide();
            AuthorizationForm auth = new AuthorizationForm(this);
            auth.ShowDialog();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            // Получаем данные с формы
            DateTime requestDate = dateTimePickerRequestDate.Value;
            string problemDesc = textBoxProblemDesc.Text;
            string repairParts = textBoxRepairParts.Text;
            int masterID = (int)comboBoxMasters.SelectedValue;
            int customerID = (int)comboBoxClients.SelectedValue;
            int modelID = (int)comboBoxModels.SelectedValue;

            // SQL-запрос для добавления заявки
            string query = @"
        INSERT INTO repairrequests (problemDescryption, start_date, requestStatus, repairParts, masterID, customerID, modelID)
        VALUES (@problemDescryption, @start_date, 'Новая заявка', @repairParts, @masterID, @customerID, @modelID)";

            // Открытие соединения
            db.openConnection();

            try
            {
                MySqlCommand command = new MySqlCommand(query, db.GetConnection());

                // Параметры запроса
                command.Parameters.AddWithValue("@problemDescryption", problemDesc);
                command.Parameters.AddWithValue("@start_date", requestDate.ToString("yyyy-MM-dd")); // Приведение даты к формату для MySQL
                command.Parameters.AddWithValue("@repairParts", repairParts);
                command.Parameters.AddWithValue("@masterID", masterID);
                command.Parameters.AddWithValue("@customerID", customerID);
                command.Parameters.AddWithValue("@modelID", modelID);

                // Выполнение запроса
                if (command.ExecuteNonQuery() > 0)
                {
                    updateTabels();
                    MessageBox.Show("Заявка успешно добавлена!");
                }
                else
                {
                    MessageBox.Show("Ошибка при добавлении заявки!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
            finally
            {
                // Закрытие соединения
                db.closeConnection();
            }
        }


        // Метод для загрузки данных из таблицы repairrequests в dataGridView1
        private void LoadRepairRequests()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            // SQL-запрос с объединением таблиц для получения необходимых данных
            string query = @"
        SELECT 
            rr.request_id AS 'Номер запроса', 
            rr.problemDescryption AS 'Описание проблемы', 
            rr.start_date AS 'Дата заявки', 
            rr.requestStatus AS 'Статус', 
            rr.repairParts AS 'Необходимые запчасти',
            CONCAT(m.full_name, ' (', m.phone_number, ')') AS 'ФИО мастера',
            CONCAT(c.full_name, ' (', c.phone_number, ')') AS 'ФИО клиента',
            md.modelName AS 'Название модели'
        FROM 
            repairrequests rr
        LEFT JOIN 
            masters m ON rr.masterID = m.master_id
        LEFT JOIN 
            customers c ON rr.customerID = c.customer_id
        LEFT JOIN 
            models md ON rr.modelID = md.modelID";

            db.openConnection();

            MySqlCommand command = new MySqlCommand(query, db.GetConnection());
            adapter.SelectCommand = command;

            adapter.Fill(table);

            dataGridView1.DataSource = table;

            db.closeConnection();
        }


        // Метод для загрузки данных из таблицы masters в dataGridView2
        public void LoadMasters()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            // SQL-запрос для получения данных из таблицы masters
            string query = @"
        SELECT 
            master_id AS 'ID Мастера', 
            full_name AS 'ФИО', 
            phone_number AS 'Телефон', 
            login AS 'Логин', 
            specialization AS 'Специализация'
        FROM 
            masters";

            db.openConnection();

            MySqlCommand command = new MySqlCommand(query, db.GetConnection());
            adapter.SelectCommand = command;

            adapter.Fill(table);

            dataGridView2.DataSource = table;

            db.closeConnection();
        }

        // Метод для загрузки данных из таблицы repairs в dataGridView3
        public void LoadRepairs()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            // SQL-запрос с объединением таблиц repairs, masters и repairrequests
            string query = @"
        SELECT 
            r.repair_id AS 'ID Ремонта', 
            rr.request_id AS 'ID Заявки', 
            CONCAT(m.full_name, ' (', m.phone_number, ')') AS 'Мастер',
            r.repair_date AS 'Дата ремонта', 
            r.labor_hours AS 'Часы работы', 
            r.total_cost AS 'Стоимость', 
            r.repair_report AS 'Отчёт о ремонте'
        FROM 
            repairs r
        LEFT JOIN 
            repairrequests rr ON r.request_id = rr.request_id
        LEFT JOIN 
            masters m ON r.master_id = m.master_id";

            db.openConnection();

            MySqlCommand command = new MySqlCommand(query, db.GetConnection());
            adapter.SelectCommand = command;

            adapter.Fill(table);

            dataGridView3.DataSource = table;

            db.closeConnection();
        }

        private void updateTabels()
        {
            LoadRepairRequests();
            LoadMasters();
            LoadRepairs();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            updateTabels();
            LoadMastersComboBox();
            LoadClientsComboBox();
            LoadModelsComboBox();
        }
        public void LoadMastersComboBox()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            string query = "SELECT master_id, full_name FROM masters";

            db.openConnection();

            MySqlCommand command = new MySqlCommand(query, db.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);

            db.closeConnection();

            comboBoxMasters.DisplayMember = "full_name"; // что будет показываться
            comboBoxMasters.ValueMember = "master_id";   // значение, которое передаётся
            comboBoxMasters.DataSource = table;
        }

        public void LoadClientsComboBox()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            string query = "SELECT customer_id, full_name FROM customers";

            db.openConnection();

            MySqlCommand command = new MySqlCommand(query, db.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);

            db.closeConnection();

            comboBoxClients.DisplayMember = "full_name";
            comboBoxClients.ValueMember = "customer_id";
            comboBoxClients.DataSource = table;
        }
        public void LoadModelsComboBox()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            string query = "SELECT modelID, CONCAT(modelName, ' (', modelType, ')') AS modelDisplay FROM models";

            db.openConnection();

            MySqlCommand command = new MySqlCommand(query, db.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);

            db.closeConnection();

            comboBoxModels.DisplayMember = "modelDisplay";
            comboBoxModels.ValueMember = "modelID";
            comboBoxModels.DataSource = table;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                selectedRequestID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Номер запроса"].Value);
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (selectedRequestID != -1)
            {
                // Открываем форму редактирования с сохранённым ID
                editRequestForm editForm = new editRequestForm(selectedRequestID);
                editForm.ShowDialog();

                LoadRepairRequests();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите заявку для редактирования.");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            LoadRepairRequests();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (selectedRequestID > 0)
            {
                var result = MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Подтверждение удаления", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    // Удаляем запись
                    DeleteRequest(selectedRequestID);

                    // Обновляем DataGridView после удаления
                    LoadRepairRequests();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите запись для удаления.");
            }
        }

        private void DeleteRequest(int requestId)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("DELETE FROM repairrequests WHERE request_id = @requestID", db.GetConnection());
            command.Parameters.Add("@requestID", MySqlDbType.Int32).Value = requestId;

            db.openConnection();

            try
            {
                if (command.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Заявка успешно удалена");
                }
                else
                {
                    MessageBox.Show("Ошибка при удалении заявки");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }

            db.closeConnection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                // Получаем ID мастера
                int selectedMasterId = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["ID Мастера"].Value);

                // Открываем форму редактирования и передаем выбранный ID мастера
                EditMasterForm editForm = new EditMasterForm(selectedMasterId);
                editForm.ShowDialog();

            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите мастера для редактирования.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int selectedMasterId = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["ID Мастера"].Value);
                var result = MessageBox.Show("Вы уверены, что хотите удалить этого мастера?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DB db = new DB();
                    string query = "DELETE FROM masters WHERE master_id = @masterId";
                    MySqlCommand command = new MySqlCommand(query, db.GetConnection());
                    command.Parameters.Add("@masterId", MySqlDbType.Int32).Value = selectedMasterId;

                    db.openConnection();

                    if (command.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Мастер успешно удален.");
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при удалении мастера.");
                    }

                    db.closeConnection();
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            LoadMasters();
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                selectedMasterID = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["ID Мастера"].Value);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                int selectedRepairId = Convert.ToInt32(dataGridView3.SelectedRows[0].Cells["ID Ремонта"].Value);
                EditRepairForm editForm = new EditRepairForm(selectedRepairId);
                editForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите ремонт для редактирования.");
            }
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                selectedRepairID = Convert.ToInt32(dataGridView3.SelectedRows[0].Cells["ID Ремонта"].Value);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            LoadRepairs();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                int selectedRepairId = Convert.ToInt32(dataGridView3.SelectedRows[0].Cells["ID Ремонта"].Value);
                var result = MessageBox.Show("Вы уверены, что хотите удалить этот ремонт?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DB db = new DB();
                    string query = "DELETE FROM repairs WHERE repair_id = @repairId";
                    MySqlCommand command = new MySqlCommand(query, db.GetConnection());
                    command.Parameters.Add("@repairId", MySqlDbType.Int32).Value = selectedRepairId;

                    db.openConnection();

                    if (command.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Ремонт успешно удален.");
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при удалении ремонта.");
                    }

                    db.closeConnection();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите ремонт для удаления.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddMasterForm addMasterForm = new AddMasterForm();
            addMasterForm.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AddRepairForm addRepairForm = new AddRepairForm();
            addRepairForm.ShowDialog();
        }

        private void buttonSearchRepairreq_Click(object sender, EventArgs e)
        {
            SearchRepReq searchRepReq = new SearchRepReq();
            searchRepReq.ShowDialog();
        }

        private void buttonSearchMasters_Click(object sender, EventArgs e)
        {
            SearchMasters searchMasters = new SearchMasters();
            searchMasters.ShowDialog();
        }

        private void buttonSearchRepairs_Click(object sender, EventArgs e)
        {
            SearchRepairs searchRepairs = new SearchRepairs();
            searchRepairs.ShowDialog();
        }
    }
}