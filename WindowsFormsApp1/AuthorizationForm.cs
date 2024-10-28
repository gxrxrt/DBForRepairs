using DataBaseLib;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AuthorizationForm : Form
    {
        DB db = new DB();
        string captchaText = string.Empty;
        private int loginAttempts = 0;
        private bool isLocked = false;
        private DateTime lockoutEndTime;
        private Timer lockoutTimer = new Timer();


        MainForm MainForm;
        public AuthorizationForm(MainForm form)
        {
            MainForm = form;
            InitializeComponent();
            pictureBox1.Image = GenerateCaptchaImage(pictureBox1.Width, pictureBox1.Height);

            lockoutTimer.Interval = 1000;
            lockoutTimer.Tick += new EventHandler(LockoutTimer_Tick);
        }



        private Bitmap GenerateCaptchaImage(int Width, int Height)
        {
            Random rnd = new Random();
            Bitmap result = new Bitmap(Width, Height);
            int Xpos = rnd.Next(0, Width - 50);
            int Ypos = rnd.Next(15, Height - 15);
            Brush[] colors = { Brushes.Black, Brushes.Red, Brushes.RoyalBlue, Brushes.Green };
            Graphics g = Graphics.FromImage((Image)result);
            g.Clear(Color.White);

            captchaText = string.Empty;
            string ALF = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
            for (int i = 0; i < 5; ++i)
                captchaText += ALF[rnd.Next(ALF.Length)];

            g.DrawString(captchaText, new Font("Arial", 15), colors[rnd.Next(colors.Length)], new PointF(Xpos, Ypos));
            g.DrawLine(Pens.Black, new Point(0, 0), new Point(Width - 1, Height - 1));
            g.DrawLine(Pens.Black, new Point(0, Height - 1), new Point(Width - 1, 0));

            for (int i = 0; i < Width; ++i)
                for (int j = 0; j < Height; ++j)
                    if (rnd.Next() % 20 == 0)
                        result.SetPixel(i, j, Color.Black);

            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = GenerateCaptchaImage(pictureBox1.Width, pictureBox1.Height);

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            passField.UseSystemPasswordChar = !checkBox1.Checked;
        }
        private void LockoutTimer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now >= lockoutEndTime)
            {
                isLocked = false;
                loginAttempts = 0;
                buttonLogin.Enabled = true;
                lockoutTimer.Stop();
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (isLocked)
            {
                TimeSpan remainingLockTime = lockoutEndTime - DateTime.Now;
                MessageBox.Show($"Попробуйте через {remainingLockTime.Minutes} минут {remainingLockTime.Seconds} секунд.", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (loginField.Text == "" || passField.Text == "")
            {
                MessageBox.Show("Введите логин и пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (pictureBox1.Visible)
            {
                if (caphchaField.Text != captchaText)
                {
                    MessageBox.Show("Неправильно введена капча. Попробуйте снова.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    caphchaField.Clear();
                    pictureBox1.Image = GenerateCaptchaImage(pictureBox1.Width, pictureBox1.Height);
                    loginAttempts++;
                    CheckLockout();
                    return;
                }
            }

            string loginUser = loginField.Text;
            string passwordUser = passField.Text;

            db.openConnection();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `masters` WHERE `login` = @uL AND `password` = @uP", db.GetConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passwordUser;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];


                loginAttempts = 0;
                isLocked = false;
                lockoutTimer.Stop();

                pictureBox1.Visible = false;
                caphchaField.Visible = false;
                button1.Visible = false;

                SaveLoginHistory(loginUser, true);
                IdentificateUser(row);
                MainForm.Show();
                MainForm.GetPermissions();
                Close();
            }
            else
            {
                loginAttempts++;
                MessageBox.Show("Неправильный логин или пароль.", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SaveLoginHistory(loginUser, false);
                if (loginAttempts >= 1 && !pictureBox1.Visible)
                {
                    ShowCaptcha();
                }

                CheckLockout();
            }

            db.closeConnection();
        }
        private void IdentificateUser(DataRow row)
        {
            string userRole = Convert.ToString(row["specialization"]);
            string userFullname = Convert.ToString(row["full_name"]);

            if (userRole == "Мастер")
                MainForm.masterRole = MainForm.Role.Master;

            if (userRole == "Оператор")
                MainForm.masterRole = MainForm.Role.Operator;

            if (userRole == "Менеджер")
                MainForm.masterRole = MainForm.Role.Manager;

            MainForm.RoleLabel.Text = $"Роль: {userRole}";
            MainForm.FullnameLabel.Text = $"ФИО: {userFullname}";
        }
        private void CheckLockout()
        {
            if (loginAttempts == 3)
            {
                LockAccount();
            }
            else if (loginAttempts >= 4)
            {
                LockAccountForever();
            }
        }
        private void ShowCaptcha()
        {
            pictureBox1.Visible = true;
            caphchaField.Visible = true;
            button1.Visible = true;
            pictureBox1.Image = GenerateCaptchaImage(pictureBox1.Width, pictureBox1.Height);
        }
        private void LockAccount()
        {
            isLocked = true;
            lockoutEndTime = DateTime.Now.AddMinutes(3); // 3 минуты
            lockoutTimer.Start();
            MessageBox.Show("Ваш аккаунт заблокирован на 3 минуты.", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            buttonLogin.Enabled = false;
        }
        private void LockAccountForever()
        {
            isLocked = true;
            MessageBox.Show("Вы исчерпали количество попыток входа. Вход заблокирован навсегда.", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            buttonLogin.Enabled = false;
        }

        private void SaveLoginHistory(string login, bool isSuccess)
        {
            db.openConnection();
            MySqlCommand command = new MySqlCommand("INSERT INTO `login_history` (login, attempt_time, success) VALUES (@login, NOW(), @success)", db.GetConnection());
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@success", MySqlDbType.Bit).Value = isSuccess ? 1 : 0;
            command.ExecuteNonQuery();
            db.closeConnection();
        }
    }
}
