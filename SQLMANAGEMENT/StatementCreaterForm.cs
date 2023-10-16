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
    public partial class StatementCreaterForm : Form
    {
        DataBase dataBase = new DataBase();
        public StatementCreaterForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreaterStatement_CreateButton_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            var numberStatementColumn = CreaterStatement_NumberStatementColumnTextBox.Text;
            var numberBookColumn = CreaterStatement_NumberBookColumnTextBox.Text;
            var numberStudentColumn = CreaterStatement_NumberStudentColumnTextBox.Text;
            var dateForImportBookColumn = CreaterStatement_DateForImportBookColumnTextBox.Text;
            var dateForExportBookColumn = CreaterStatement_DateForExportBookColumnTextBox.Text;
            var bookStatusColumn = CreaterStatement_BookStatusColumnTextBox.Text;
            var librarianColumn = CreaterStatement_LibrarianColumnTextBox.Text;
            try
            {
                string addQuery = $"insert into StatementLibrary (НомерВедомости,НомерКниги,НомерСтудента,ДатаВыдачиКниги,ДатаВозвратаКниги,СтатусКниги,Библиотекарь)" +
                    $" values('{numberStatementColumn}','{numberBookColumn}','{numberStudentColumn}','{dateForImportBookColumn}','{dateForExportBookColumn}','{bookStatusColumn}','{librarianColumn}')";
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
