using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SQLMANAGEMENT
{
    public partial class loginForm : Form
    {
        public loginForm()
        {//Загрузка и иницализация формы
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            ServerNameLoginLabel.Text = Properties.Settings.Default.ServerName;
            DataBaseNameLoginLabel.Text = Properties.Settings.Default.DataBaseName;
            UserNameLoginLabel.Text = Properties.Settings.Default.UserLogin;
        }

        private void enterLoginButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ServerName = ServerNameLoginLabel.Text;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.DataBaseName = DataBaseNameLoginLabel.Text;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.UserLogin = UserNameLoginLabel.Text;
            Properties.Settings.Default.Save();

            DataBase.ServerName = ServerNameLoginLabel.Text;
            DataBase.DataBaseName = DataBaseNameLoginLabel.Text;
            DataBase.UserLogin = UserNameLoginLabel.Text;
            DataBase.UserPassword = UserPasswordLoginLabel.Text;
            try
            {
                DataBase dataBase = new DataBase();
                dataBase.openConnection();
                mainForm myMainForm = new mainForm();
                this.Hide();
                myMainForm.ShowDialog();
                dataBase.closeConnection();
                this.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Неверные данные входа, повторите попытку.");
            }
        }
    }
}
