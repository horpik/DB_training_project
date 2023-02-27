using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
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

    public static void SaveToPDF(DataTable dataTable)
    {
        string fileName = "";
        iTextSharp.text.Document doc = new iTextSharp.text.Document();
        PdfWriter.GetInstance(doc, new FileStream("D:/pdfTables.pdf", FileMode.Create));
        doc.Open();

        PdfPTable table = new PdfPTable(dataTable.Columns.Count);

        PdfPCell cell = new PdfPCell(new Phrase("БД " + fileName));

        cell.Colspan = dataTable.Columns.Count;
        cell.HorizontalAlignment = 1;
        cell.Border = 0;
        table.AddCell(cell);

        for (int j = 0; j < dataTable.Columns.Count; j++)
        {
            cell = new PdfPCell(new Phrase(new Phrase(dataTable.Columns[j].ColumnName)));
            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
            table.AddCell(cell);
        }

        for (int j = 0; j < dataTable.Rows.Count; j++)
        {
            for (int k = 0; k < dataTable.Columns.Count; k++)
            {
                table.AddCell(new Phrase(dataTable.Rows[j][k].ToString()));
            }
        }

        doc.Add(table);

        doc.Close();

        MessageBox.Show("Pdf-документ сохранен");
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
        catch (Exception exception)
        {
            MessageBox.Show(exception.ToString());
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
        catch (Exception exception)
        {
            MessageBox.Show(exception.ToString());
            return new DataTable();
        }
    }
}