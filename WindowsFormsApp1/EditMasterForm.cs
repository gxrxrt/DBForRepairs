using DataBaseLib;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class EditMasterForm : Form
    {
        private int masterId;

        public EditMasterForm(int selectedMasterId)
        {
            InitializeComponent();
            masterId = selectedMasterId;
            LoadMasterData();
        }
        private void LoadMasterData()
        {
            DB db = new DB();
            string query = "SELECT full_name, phone_number, specialization FROM masters WHERE master_id = @masterId";

            MySqlCommand command = new MySqlCommand(query, db.GetConnection());
            command.Parameters.Add("@masterId", MySqlDbType.Int32).Value = masterId;

            db.openConnection();

            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                textBoxFullName.Text = reader["full_name"].ToString();
                textBoxPhoneNumber.Text = reader["phone_number"].ToString();
                comboBoxSpecialization.Text = reader["specialization"].ToString();
            }

            db.closeConnection();
        }

        private void btnSaveMaster_Click(object sender, System.EventArgs e)
        {
            DB db = new DB();
            string query = "UPDATE masters SET full_name = @fullName, phone_number = @phoneNumber, specialization = @specialization WHERE master_id = @masterId";

            MySqlCommand command = new MySqlCommand(query, db.GetConnection());
            command.Parameters.Add("@fullName", MySqlDbType.VarChar).Value = textBoxFullName.Text;
            command.Parameters.Add("@phoneNumber", MySqlDbType.VarChar).Value = textBoxPhoneNumber.Text;
            command.Parameters.Add("@specialization", MySqlDbType.VarChar).Value = comboBoxSpecialization.Text;
            command.Parameters.Add("@masterId", MySqlDbType.Int32).Value = masterId;

            db.openConnection();

            if (command.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Информация о мастере успешно обновлена.");
                this.Close(); // Закрываем форму
            }
            else
            {
                MessageBox.Show("Ошибка при обновлении данных мастера.");
            }

            db.closeConnection();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
