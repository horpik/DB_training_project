using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using DBTrainingProject.DB;

namespace DBTrainingProject.Controllers;

public static class Controller
{
    private static Db myDb = new Db();
    private static string connectionString;

    public static void CreateConnection(string connectionString)
    {
        try
        {
            myDb.CreateConnection(connectionString);
            myDb.OpenConnection();
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.ToString());
        }
    }

    public static DataTable GetTable(string commandStr)
    {
        try
        {
            SqlCommand createCommand = new SqlCommand(commandStr, myDb.GetConnection());
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dataTable = new DataTable(); // В скобках указываем название таблицы
            dataAdp.Fill(dataTable);
            return dataTable;
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.ToString());
            throw;
        }
    }
}