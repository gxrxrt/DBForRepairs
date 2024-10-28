using DataBaseLib;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AddMasterForm : Form
    {
        public AddMasterForm()
        {
            InitializeComponent();
        }

        private void btnSaveMaster_Click(object sender, EventArgs e)
        {
            // Получаем значения из текстовых полей
            string fullName = textBoxFullName.Text;
            string phone = textBoxPhoneNumber.Text;
            string login = textBox1.Text;
            string password = textBox2.Text;
            string specialization = comboBoxSpecialization.Text;

            // Проверяем, что все поля заполнены
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(specialization))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Вставляем данные в таблицу masters
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO masters (full_name, phone_number, login, password, specialization) VALUES (@fullName, @phone, @login, @password, @specialization)", db.GetConnection());

            command.Parameters.Add("@fullName", MySqlDbType.VarChar).Value = fullName;
            command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;
            command.Parameters.Add("@specialization", MySqlDbType.VarChar).Value = specialization;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Мастер успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ошибка при добавлении мастера.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            db.closeConnection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

