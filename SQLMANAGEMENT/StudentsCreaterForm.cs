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
    public partial class StudentsCreaterForm : Form
    {
        DataBase dataBase = new DataBase();
        public StudentsCreaterForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;  
        }

        private void CreaterStudents_CreateButton_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            var numberStudentColumn = CreaterStudents_NumberStudentColumnTextBox.Text;
            var studentNameColumn = CreaterStudents_StudentNameColumnTextBox.Text;
            var studentFamilyNameColumn = CreaterStudents_StudentNameColumnTextBox.Text;
            var studentCourseColumn = CreaterStudents_StudentCourseColumnTextBox.Text;
            var studentGroupColumn = CreaterStudents_StudentGroupColumnTextBox.Text;
            var studentBirthYearColumn = CreaterStudents_StudentBirthYearColumnTextBox.Text;
            var studentStatusColumn = CreaterStudents_StudentStatusColumnTextBox.Text;

            try
            {
                string addQuery = $"insert into Students (НомерСтудента,Имя,Фамилия,Курс,Группа,ГодРождения,Статус)" +
                    $" values('{numberStudentColumn}','{studentNameColumn}','{studentFamilyNameColumn}','{studentCourseColumn}','{studentGroupColumn}','{studentBirthYearColumn}','{studentStatusColumn}')";
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
