using System.Data.SqlClient;

namespace SQLMANAGEMENT
{
    public class DataBase
    {
        //Глобальные переменные параметры входа
        public static string ServerName { get; set; }
        public static string DataBaseName { get; set; }
        public static string UserLogin { get; set; }
        public static string UserPassword { get; set; }
        // Наследуем класс для подключение к базе данных
        SqlConnection connetionString = new SqlConnection($"Data Source={ServerName};" +
            $" Initial Catalog={DataBaseName}; User ID={UserLogin}; Password={UserPassword}");

        public void openConnection()
        {//Функция на открытия подключения с проверкой
            if(connetionString.State == System.Data.ConnectionState.Closed)
            {
                connetionString.Open();
            }

        }
        public void closeConnection()
        {//Функция на закрытие подключения с проверкой
            if (connetionString.State == System.Data.ConnectionState.Open)
            {
                connetionString.Close();
            }
        }
        public SqlConnection getConnection()
        {//Функция на пересылку подключения другим функциям
            return connetionString;
        }
    }
}
