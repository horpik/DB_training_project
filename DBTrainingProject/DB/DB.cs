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
            MessageBox.Show("Подключение открыто");
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
            MessageBox.Show("Подключение закрыто"); 
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