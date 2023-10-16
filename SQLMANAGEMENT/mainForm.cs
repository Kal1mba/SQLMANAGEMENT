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
    enum RowState
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted,
    }
    public partial class mainForm : Form
    {

        DataBase dataBase = new DataBase();

        int selectedRowStatement;
        int selectedRowBooks;
        int selectedRowStudents;

        public mainForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            Statement_SearchPIC.Image = Properties.Resources.search;
            Books_SearchPIC.Image = Properties.Resources.search;
            Students_SearchPIC.Image = Properties.Resources.search;
        }
        //Погрузка информации по загрузке главной формы
        private void mainForm_Load(object sender, EventArgs e)
        {
            CreateStatementColumns();
            RefreshDataGrid(Statement_GridView, "StatementLibrary");
            CreateSBooksColumns();
            RefreshDataGrid(Books_GridView, "Books");
            CreateStudentsColumns();
            RefreshDataGrid(Students_GridView, "Students");
        }

        private void RefreshDataGrid(DataGridView dgv, string table)
        {
            dgv.Rows.Clear();

            string queryString = $"select * from {table}";

            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();
            
            if(table == "StatementLibrary")
            {
                while (reader.Read())
                {
                    ReadSingleRowStatement(dgv, reader);
                }
            }
            if (table == "Books")
            {
                while (reader.Read())
                {
                    ReadSingleRowBooks(dgv, reader);
                }
            }
            if (table == "Students")
            {
                while (reader.Read())
                {
                    ReadSingleRowStudents(dgv, reader);
                }
            }

            reader.Close();
        }

        //Statement
        //Добавление строк в обозреватель таблицы Statement
        private void CreateStatementColumns()
        {
            Statement_GridView.Columns.Add("НомерВедомости", "Номер ведомости");
            Statement_GridView.Columns.Add("НомерКниги", "Номер книги");
            Statement_GridView.Columns.Add("НомерСтудента", "Номер студента");
            Statement_GridView.Columns.Add("ДатаВыдачиКниги", "Дата выдачи книги");
            Statement_GridView.Columns.Add("ДатаВозвратаКниги", "Дата возврата книги");
            Statement_GridView.Columns.Add("СтатусКниги", "Статус Книги");
            Statement_GridView.Columns.Add("Библиотекарь", "Библиотекарь");
            Statement_GridView.Columns.Add("IsNew", String.Empty);
            Statement_GridView.Columns["IsNew"].Visible = false;
        }
        private void ReadSingleRowStatement(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetInt32(2),
                record.GetString(3), record.GetString(4), record.GetString(5),
                record.GetString(6), RowState.ModifiedNew);
        }
        //Функция передачи данных на панель иформации о строке Statement
        private void Statement_GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRowStatement = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = Statement_GridView.Rows[selectedRowStatement];

                Statement_NumberStatementColumnTextBox.Text = row.Cells[0].Value.ToString();
                Statement_NumberBookColumnTextBox.Text = row.Cells[1].Value.ToString();
                Statement_NumberStudentColumnTextBox.Text = row.Cells[2].Value.ToString();
                Statement_DateForImportBookColumnTextBox.Text = row.Cells[3].Value.ToString();
                Statement_DateForExportBookColumnTextBox.Text = row.Cells[4].Value.ToString();
                Statement_BookStatusColumnTextBox.Text = row.Cells[5].Value.ToString();
                Statement_LibrarianColumnTextBox.Text = row.Cells[6].Value.ToString();
            }
        }
        //Кнопка обновления таблицы Statement
        private void Statement_UpdateButton_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(Statement_GridView, "StatementLibrary");
        }
        //Вызов новой формы для добавления новой записи Statement
        private void Statement_GetNewTabelLineButton_Click(object sender, EventArgs e)
        {
            StatementCreaterForm statementCreaterForm = new StatementCreaterForm();
            statementCreaterForm.Show();
        }
        //Поле поиска по запясям Statement
        private void SearchStatementTabel(DataGridView dgv)
        {
            dgv.Rows.Clear();
            string searchString = $"select * from StatementLibrary where concat" +
                $" (НомерВедомости,НомерКниги,НомерСтудента,ДатаВыдачиКниги," +
                $"ДатаВозвратаКниги,СтатусКниги,Библиотекарь) " +
                $" like '%" + Statement_SearchTextBox.Text + "%'";
            SqlCommand command = new SqlCommand(searchString, dataBase.getConnection());
            dataBase.openConnection();
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                ReadSingleRowStatement(dgv, sqlDataReader);
            }
            sqlDataReader.Close();
        }
        private void Statement_SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            SearchStatementTabel(Statement_GridView);
        }
        //Функции удаления строки Statement
        private void Statement_delateRow()
        {
            int index = Statement_GridView.CurrentCell.RowIndex;
            Statement_GridView.Rows[index].Visible = false;
            if (Statement_GridView.Rows[index].Cells[0].Value.ToString() == String.Empty)
            {
                Statement_GridView.Rows[index].Cells[7].Value = RowState.Deleted;
                return;
            }
            Statement_GridView.Rows[index].Cells[7].Value = RowState.Deleted;
        }
        private void Statement_DeleteTabelLineButton_Click(object sender, EventArgs e)
        {
            Statement_delateRow();
        }
        //Функция обновления, удаления строк Statement
        private void Statement_updateRow()
        {
            dataBase.openConnection();

            for(int index = 0; index < Statement_GridView.Rows.Count; index++)
            {
                RowState rowState = (RowState)Statement_GridView.Rows[index].Cells[7].Value;

                if (rowState == RowState.Existed)
                    continue;

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(Statement_GridView.Rows[index].Cells[0].Value);
                    var deleteQuary = $"delete from StatementLibrary where НомерВедомости = {id}";

                    SqlCommand command = new SqlCommand(deleteQuary, dataBase.getConnection());
                    command.ExecuteNonQuery();
                    RefreshDataGrid(Statement_GridView, "StatementLibrary");
                }
                if (rowState == RowState.Modified)
                {
                    var umberStatementColumn = Statement_GridView.Rows[index].Cells[0].Value.ToString();
                    var numberBookColumn = Statement_GridView.Rows[index].Cells[1].Value.ToString();
                    var numberStudentColumn = Statement_GridView.Rows[index].Cells[2].Value.ToString();
                    var dateForImportBookColumn = Statement_GridView.Rows[index].Cells[3].Value.ToString();
                    var dateForExportBookColumn = Statement_GridView.Rows[index].Cells[4].Value.ToString();
                    var bookStatusColumn = Statement_GridView.Rows[index].Cells[5].Value.ToString();
                    var librarianColumn = Statement_GridView.Rows[index].Cells[6].Value.ToString();
                    string changeQuery = $"update StatementLibrary set НомерКниги = '{numberBookColumn}'," +
                        $" НомерСтудента = '{numberStudentColumn}', ДатаВыдачиКниги = '{dateForImportBookColumn}'," +
                        $" ДатаВозвратаКниги = '{dateForExportBookColumn}', СтатусКниги = '{bookStatusColumn}'," +
                        $" Библиотекарь = '{librarianColumn}' where НомерВедомости = '{umberStatementColumn}'";
                    SqlCommand changeStatementCommand = new SqlCommand(changeQuery, dataBase.getConnection());
                    changeStatementCommand.ExecuteNonQuery();
                    RefreshDataGrid(Statement_GridView, "StatementLibrary");
                }
            }
            dataBase.closeConnection();
        }
        private void Statement_SaveTabelLineButton_Click(object sender, EventArgs e)
        {
            Statement_updateRow();
        }
        //Кнопка на изменения данных в строке Statement
        private void Statement_ChangeRow()
        {
            var selectedRowStatement = Statement_GridView.CurrentCell.RowIndex;
            var numberStatementColumn = Statement_NumberStatementColumnTextBox.Text;
            var numberBookColumn = Statement_NumberBookColumnTextBox.Text;
            var numberStudentColumn = Statement_NumberStudentColumnTextBox.Text;
            var dateForImportBookColumn = Statement_DateForImportBookColumnTextBox.Text;
            var dateForExportBookColumn = Statement_DateForExportBookColumnTextBox.Text;
            var bookStatusColumn = Statement_BookStatusColumnTextBox.Text;
            var librarianColumn = Statement_LibrarianColumnTextBox.Text;
            if (Statement_GridView.Rows[selectedRowStatement].Cells[0].Value.ToString() != String.Empty)
            {
                Statement_GridView.Rows[selectedRowStatement].SetValues(numberStatementColumn,
                    numberBookColumn, numberStudentColumn, dateForImportBookColumn, dateForExportBookColumn,
                    bookStatusColumn, librarianColumn);
                Statement_GridView.Rows[selectedRowStatement].Cells[7].Value = RowState.Modified;
            }
        }
        private void Statement_UpdateTabelLineButton_Click(object sender, EventArgs e)
        {
            Statement_ChangeRow();
        }



        //BOOKS
        //Заполнение таблицы BOOKS
        private void CreateSBooksColumns()
        {
            Books_GridView.Columns.Add("НомерКниги", "Номер книги");
            Books_GridView.Columns.Add("АвторКниги", "Автор книги");
            Books_GridView.Columns.Add("НазваниеКниги", "Название книги");
            Books_GridView.Columns.Add("Год", "Год");
            Books_GridView.Columns.Add("Издание", "Издание");
            Books_GridView.Columns.Add("КоличествоВБиблиотеке", "Количество в библиотеке");
            Books_GridView.Columns.Add("IsNew", String.Empty);
            Books_GridView.Columns["IsNew"].Visible = false;
        }
        //Метод иницализации строк BOOKS
        private void ReadSingleRowBooks(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetInt32(3), record.GetInt32(4), record.GetInt32(5), RowState.ModifiedNew);
        }
        //Функция заполнения информации в поля BOOKS
        private void Books_GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRowBooks = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = Books_GridView.Rows[selectedRowBooks];

                Books_BookNumberColumnTextBox.Text = row.Cells[0].Value.ToString();
                Books_BookAuthorColumnTextBox.Text = row.Cells[1].Value.ToString();
                Books_BookNameColumnTextBox.Text = row.Cells[2].Value.ToString();
                Books_BookAgeColumnTextBox.Text = row.Cells[3].Value.ToString();
                Books_BookEditionColumnTextBox.Text = row.Cells[4].Value.ToString();
                Books_AmountBookColumnTextBox.Text = row.Cells[5].Value.ToString();
            }
        }
        //Книпка обновления таблицы BOOKS
        private void Books_UpdateButton_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(Books_GridView, "Books");
        }
        //Кнопка вызова формы добавления новой записи
        private void Books_GetNewTabelLineButton_Click(object sender, EventArgs e)
        {
            BooksCreaterForm booksCreaterForm = new BooksCreaterForm();
            booksCreaterForm.Show();
        }
        //Поисковая строка BOOKS
        private void SearchBooksTabel(DataGridView dgv)
        {
            dgv.Rows.Clear();

            string searchString = $"select * from Books where concat (НомерКниги,АвторКниги,НазваниеКниги,Год,Издание,КоличествоВБиблиотеке) " +
                $" like '%" + Books_SearchTextBox.Text + "%'";

            SqlCommand command = new SqlCommand(searchString, dataBase.getConnection());

            dataBase.openConnection();
            SqlDataReader sqlDataReader = command.ExecuteReader();

            while (sqlDataReader.Read())
            {
                ReadSingleRowBooks(dgv, sqlDataReader);
            }
            sqlDataReader.Close();
        }
        private void Books_SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            SearchBooksTabel(Books_GridView);
        }
        //Кнопка на изменение строки BOOKS
        private void Books_ChangeRow()
        {
            var selectedRowBooks = Books_GridView.CurrentCell.RowIndex;

            var bookNumberColumn = Books_BookNumberColumnTextBox.Text;
            var bookAuthorColumn = Books_BookAuthorColumnTextBox.Text;
            var bookNameColumn = Books_BookNameColumnTextBox.Text;
            var bookAgeColumn = Books_BookAgeColumnTextBox.Text;
            var bookEditionColumn = Books_BookEditionColumnTextBox.Text;
            var amountBookColumn = Books_AmountBookColumnTextBox.Text;

            if (Books_GridView.Rows[selectedRowBooks].Cells[0].Value.ToString() != String.Empty)
            {
                Books_GridView.Rows[selectedRowBooks].SetValues(bookNumberColumn, bookAuthorColumn, bookNameColumn, bookAgeColumn, bookEditionColumn, amountBookColumn);
                Books_GridView.Rows[selectedRowBooks].Cells[6].Value = RowState.Modified;
            }
        }
        private void Books_UpdateTabelLineButton_Click(object sender, EventArgs e)
        {
            Books_ChangeRow();
        }
        //Функция изменения и удаления строк BOOKS
        private void Books_updateRow()
        {
            dataBase.openConnection();

            for (int index = 0; index < Books_GridView.Rows.Count; index++)
            {
                var rowState = (RowState)Books_GridView.Rows[index].Cells[6].Value;

                if (rowState == RowState.Existed)
                    continue;

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(Books_GridView.Rows[index].Cells[0].Value);
                    var deleteQuary = $"delete from Books where НомерКниги = {id}";

                    SqlCommand bookCommand = new SqlCommand(deleteQuary, dataBase.getConnection());
                    bookCommand.ExecuteNonQuery();
                    RefreshDataGrid(Books_GridView, "Books");
                }

                if (rowState == RowState.Modified)
                {
                    var bookNumberColumn = Books_GridView.Rows[index].Cells[0].Value.ToString();
                    var bookAuthorColumn = Books_GridView.Rows[index].Cells[1].Value.ToString();
                    var bookNameColumn = Books_GridView.Rows[index].Cells[2].Value.ToString();
                    var bookAgeColumn = Books_GridView.Rows[index].Cells[3].Value.ToString();
                    var bookEditionColumn = Books_GridView.Rows[index].Cells[4].Value.ToString();
                    var amountBookColumn = Books_GridView.Rows[index].Cells[5].Value.ToString();

                    string changeQuery = $"update Books set АвторКниги = '{bookAuthorColumn}', НазваниеКниги = '{bookNameColumn}', Год = '{bookAgeColumn}', Издание = '{bookEditionColumn}', КоличествоВБиблиотеке = '{amountBookColumn}' where НомерКниги = '{bookNumberColumn}'";
                    SqlCommand changeBookCommand = new SqlCommand(changeQuery, dataBase.getConnection());
                    changeBookCommand.ExecuteNonQuery();
                    RefreshDataGrid(Books_GridView, "Books");
                }
            }
            dataBase.closeConnection();
        }
        private void Books_SaveTabelLineButton_Click(object sender, EventArgs e)
        {
            Books_updateRow();
        }

        //Students
        //Заполнение столбцов в таблице Students
        private void CreateStudentsColumns()
        {
            Students_GridView.Columns.Add("НомерСтудента", "Номер студента");
            Students_GridView.Columns.Add("Имя", "Имя");
            Students_GridView.Columns.Add("Фамилия", "Фамилия");
            Students_GridView.Columns.Add("Курс", "Курс");
            Students_GridView.Columns.Add("Группа", "Группа");
            Students_GridView.Columns.Add("ГодРождения", "Год рождения");
            Students_GridView.Columns.Add("Статус", "Статус");
            Students_GridView.Columns.Add("IsNew", String.Empty);
            Students_GridView.Columns["IsNew"].Visible = false;
        }
        //Функция иницализации столбцов Students
        private void ReadSingleRowStudents(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetInt32(3), record.GetString(4), record.GetString(5), record.GetString(6), RowState.ModifiedNew);
        }
        //Перенос данных в панель информации Students
        private void Students_GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRowStudents = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = Students_GridView.Rows[selectedRowStudents];

                Students_NumberStudentColumnTextBox.Text = row.Cells[0].Value.ToString();
                Students_StudentNameColumnTextBox.Text = row.Cells[1].Value.ToString();
                Students_StudentFamilyNameColumnTextBox.Text = row.Cells[2].Value.ToString();
                Students_StudentCourseColumnTextBox.Text = row.Cells[3].Value.ToString();
                Students_StudentGroupColumnTextBox.Text = row.Cells[4].Value.ToString();
                Students_StudentBirthYearColumnTextBox.Text = row.Cells[5].Value.ToString();
                Students_StudentStatusColumnTextBox.Text = row.Cells[6].Value.ToString();

            }
        }
        //Кнопа обновления таблицы Students
        private void Students_UpdateButton_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(Students_GridView, "Students");
        }
        //Кнопа вызова новой формы для создание я новой записи Students
        private void Students_GetNewTabelLineButton_Click(object sender, EventArgs e)
        {
            StudentsCreaterForm studentsCreaterForm = new StudentsCreaterForm();
            studentsCreaterForm.Show();
        }
        //Поле поиска Students
        private void SearchStudentsTabel(DataGridView dgv)
        {
            dgv.Rows.Clear();

            string searchString = $"select * from Students where concat (НомерСтудента,Имя,Фамилия,Курс,Группа,ГодРождения,Статус) " +
                $" like '%" + Students_SearchTextBox.Text + "%'";

            SqlCommand command = new SqlCommand(searchString, dataBase.getConnection());

            dataBase.openConnection();
            SqlDataReader sqlDataReader = command.ExecuteReader();

            while (sqlDataReader.Read())
            {
                ReadSingleRowStudents(dgv, sqlDataReader);
            }
            sqlDataReader.Close();
        }
        private void Students_SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            SearchStudentsTabel(Students_GridView);
        }

        //Изменение записей Students
        private void Students_ChangeRow()
        {
            var selectedRowStudents = Students_GridView.CurrentCell.RowIndex;

            var numberStudentColumn = Students_NumberStudentColumnTextBox.Text;
            var studentNameColumn = Students_StudentNameColumnTextBox.Text;
            var studentFamilyNameColumn = Students_StudentFamilyNameColumnTextBox.Text;
            var studentCourseColumn = Students_StudentCourseColumnTextBox.Text;
            var studentGroupColumn = Students_StudentGroupColumnTextBox.Text;
            var studentBirthYearColumn = Students_StudentBirthYearColumnTextBox.Text;
            var studentStatusColumn = Students_StudentStatusColumnTextBox.Text;

            if (Students_GridView.Rows[selectedRowStudents].Cells[0].Value.ToString() != String.Empty)
            {
                Students_GridView.Rows[selectedRowStudents].SetValues(numberStudentColumn, studentNameColumn, studentFamilyNameColumn, studentCourseColumn, studentGroupColumn, studentBirthYearColumn, studentStatusColumn);
                Students_GridView.Rows[selectedRowStudents].Cells[7].Value = RowState.Modified;
            }
        }
        private void Students_UpdateTabelLineButton_Click(object sender, EventArgs e)
        {
            Students_ChangeRow();
        }
        //Функция изменения и удаления строк Students
        private void Students_updateRow()
        {
            dataBase.openConnection();

            for (int index = 0; index < Students_GridView.Rows.Count; index++)
            {
                var rowState = (RowState)Students_GridView.Rows[index].Cells[7].Value;

                if (rowState == RowState.Existed)
                    continue;

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(Students_GridView.Rows[index].Cells[0].Value);
                    var deleteQuary = $"delete from Students where НомерСтудента = {id}";

                    SqlCommand studentsCommand = new SqlCommand(deleteQuary, dataBase.getConnection());
                    studentsCommand.ExecuteNonQuery();
                    RefreshDataGrid(Students_GridView, "Students");
                }

                if (rowState == RowState.Modified)
                {
                    var numberStudentColumn = Students_NumberStudentColumnTextBox.Text;
                    var studentNameColumn = Students_StudentNameColumnTextBox.Text;
                    var studentFamilyNameColumn = Students_StudentFamilyNameColumnTextBox.Text;
                    var studentCourseColumn = Students_StudentCourseColumnTextBox.Text;
                    var studentGroupColumn = Students_StudentGroupColumnTextBox.Text;
                    var studentBirthYearColumn = Students_StudentBirthYearColumnTextBox.Text;
                    var studentStatusColumn = Students_StudentStatusColumnTextBox.Text;

                    string changeQuery = $"update Students set Имя = '{studentNameColumn}', Фамилия = '{studentFamilyNameColumn}', Курс = '{studentCourseColumn}', Группа = '{studentGroupColumn}', ГодРождения = '{studentBirthYearColumn}', Статус = '{studentStatusColumn}' where НомерСтудента = '{numberStudentColumn}'";
                    SqlCommand changeStudentCommand = new SqlCommand(changeQuery, dataBase.getConnection());
                    changeStudentCommand.ExecuteNonQuery();
                    RefreshDataGrid(Students_GridView, "Students");
                }
            }
            dataBase.closeConnection();
        }
        private void Students_SaveTabelLineButton_Click(object sender, EventArgs e)
        {
            Students_updateRow();
        }

        private void Statement_GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        //private void Books_delateRow()
        //{
        //    int index = Books_GridView.CurrentCell.RowIndex;

        //    Books_GridView.Rows[index].Visible = false;

        //    if (Books_GridView.Rows[index].Cells[0].Value.ToString() == String.Empty)
        //    {
        //        Books_GridView.Rows[index].Cells[6].Value = RowState.Deleted;
        //        return;
        //    }
        //    Books_GridView.Rows[index].Cells[6].Value = RowState.Deleted;
        //}


        //private void Books_DeleteTabelLineButton_Click(object sender, EventArgs e)
        //{
        //    Books_delateRow();
        //}
    }
}
