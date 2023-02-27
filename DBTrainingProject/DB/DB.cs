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
        catch (Exception e)
        {
            MessageBox.Show(e.ToString());
        }
    }

    public void OpenConnection()
    {
        try
        {
            if (connection.State == ConnectionState.Closed) connection.Open();
        }
        catch (Exception e)
        {
            MessageBox.Show(e.ToString());
        }
       
    }

    public void CloseConnection()
    {
        try
        {
            if (connection.State == ConnectionState.Open) connection.Close();
        }
        catch (Exception e)
        {
            MessageBox.Show(e.ToString());
        }
        
    }

    public SqlConnection GetConnection()
    {
        return connection;
    }
}