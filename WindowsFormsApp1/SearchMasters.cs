using DataBaseLib;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class SearchMasters : Form
    {
        static DB db = new DB();
        static private MySqlConnection connection = db.GetConnection();

        public SearchMasters()
        {
            InitializeComponent();
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            // Создание элементов управления
            this.textBoxFullName = new System.Windows.Forms.TextBox();
            this.textBoxPhoneNumber = new System.Windows.Forms.TextBox();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.textBoxSpecialization = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.dataGridViewResults = new System.Windows.Forms.DataGridView();
            this.labelCount = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();

            // Настройка элементов управления
            this.textBoxFullName.Location = new System.Drawing.Point(12, 12);
            this.textBoxFullName.Size = new System.Drawing.Size(200, 20);
            this.textBoxFullName.Text = "ФИО";

            this.textBoxPhoneNumber.Location = new System.Drawing.Point(12, 38);
            this.textBoxPhoneNumber.Size = new System.Drawing.Size(200, 20);
            this.textBoxPhoneNumber.Text = "Телефон";

            this.textBoxLogin.Location = new System.Drawing.Point(12, 64);
            this.textBoxLogin.Size = new System.Drawing.Size(200, 20);
            this.textBoxLogin.Text = "Логин";

            this.textBoxSpecialization.Location = new System.Drawing.Point(12, 90);
            this.textBoxSpecialization.Size = new System.Drawing.Size(200, 20);
            this.textBoxSpecialization.Text = "Специализация";

            this.buttonSearch.Location = new System.Drawing.Point(12, 116);
            this.buttonSearch.Text = "Поиск";
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);

            this.dataGridViewResults.Location = new System.Drawing.Point(220, 12);
            this.dataGridViewResults.Size = new System.Drawing.Size(600, 400);

            this.labelCount.Location = new System.Drawing.Point(220, 420);
            this.labelCount.Size = new System.Drawing.Size(100, 20);

            this.buttonClose.Location = new System.Drawing.Point(12, 146);
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);

            // Добавление элементов управления на форму
            this.Controls.Add(this.textBoxFullName);
            this.Controls.Add(this.textBoxPhoneNumber);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.textBoxSpecialization);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.dataGridViewResults);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.buttonClose);

            // Настройка формы
            this.ClientSize = new System.Drawing.Size(850, 450);
            this.Text = "Поиск мастеров";
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string fullName = textBoxFullName.Text;
            string phoneNumber = textBoxPhoneNumber.Text;
            string login = textBoxLogin.Text;
            string specialization = textBoxSpecialization.Text;

            // Начинаем с основного запроса
            string query = "SELECT * FROM Masters WHERE 1=1";

            // Добавляем условия поиска только для заполненных полей
            if (!string.IsNullOrEmpty(fullName))
            {
                query += $" AND full_name LIKE '%{fullName}%'";
            }

            if (!string.IsNullOrEmpty(phoneNumber))
            {
                query += $" AND phone_number LIKE '%{phoneNumber}%'";
            }

            if (!string.IsNullOrEmpty(login))
            {
                query += $" AND login LIKE '%{login}%'";
            }

            if (!string.IsNullOrEmpty(specialization))
            {
                query += $" AND specialization LIKE '%{specialization}%'";
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
            string query = "SELECT COUNT(*) FROM Masters";
            MySqlCommand command = new MySqlCommand(query, connection);

            return Convert.ToInt32(command.ExecuteScalar());
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private TextBox textBoxFullName;
        private TextBox textBoxPhoneNumber;
        private TextBox textBoxLogin;
        private TextBox textBoxSpecialization;
        private Button buttonSearch;
        private DataGridView dataGridViewResults;
        private Label labelCount;
        private Button buttonClose;
    }
}
