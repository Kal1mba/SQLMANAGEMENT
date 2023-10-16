using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLMANAGEMENT
{
    public partial class BooksCreaterForm : Form
    {
        DataBase dataBase = new DataBase();
        public BooksCreaterForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreaterBooks_CreateButton_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            var bookNumberColumn = CreaterBooks_BookNumberColumnTextBox.Text;
            var bookAuthorColumn = CreaterBooks_BookAuthorColumnTextBox.Text;
            var bookNameColumn = CreaterBooks_BookNameColumnTextBox.Text;
            var bookAgeColumn = CreaterBooks_BookAgeColumnTextBox.Text;
            var bookEditionColumn = CreaterBooks_BookEditionColumnTextBox.Text;
            var amountBookColumn = CreaterBooks_AmountBookColumnTextBox.Text;
            try
            {
                string addQuery = $"insert into Books (НомерКниги,АвторКниги,НазваниеКниги,Год,Издание,КоличествоВБиблиотеке)" +
                    $" values('{bookNumberColumn}','{bookAuthorColumn}','{bookNameColumn}','{bookAgeColumn}','{bookEditionColumn}','{amountBookColumn}')";
                SqlCommand command = new SqlCommand(addQuery, dataBase.getConnection());
                command.ExecuteNonQuery();

                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка. Проверьте заполненость всех полей. Повторите попытку");
            }
        }
    }
}
