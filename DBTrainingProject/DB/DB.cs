using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace DBTrainingProject.DB;

public class Db
{
    private SqlConnection connection;

    public void CreateConnection(string connectionString)
    {
        try
        {
            connection = new SqlConnection(connectionString);
            MessageBox.Show("Подключение создано");
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.ToString());
        }
    }

    public void OpenConnection()
    {
        try
        {
            if (connection.State == ConnectionState.Closed) connection.Open();
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.ToString());
        }
       
    }

    public void CloseConnection()
    {
        try
        {
            if (connection.State == ConnectionState.Open) connection.Close();
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.ToString());
        }
        
    }

    public SqlConnection GetConnection()
    {
        return connection;
    }
}