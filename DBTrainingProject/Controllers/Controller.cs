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
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.ToString());
        }
    }

    public static void ExecuteCommand(string commandStr)
    {
        try
        {
            myDb.OpenConnection();
            SqlCommand sqlCommand = new SqlCommand(commandStr, myDb.GetConnection());
            if (sqlCommand.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("OK!");
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.ToString());
        }
    }

    public static DataTable GetTable(string commandStr)
    {
        try
        {
            myDb.OpenConnection();
            SqlCommand sqlCommand = new SqlCommand(commandStr, myDb.GetConnection());
            sqlCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable(); // В скобках указываем название таблицы
            dataAdp.Fill(dataTable);
            myDb.CloseConnection();
            return dataTable;
        }
        catch (Exception e)
        {
            MessageBox.Show(e.ToString());
            return new DataTable();
        }
    }
}