using System.Windows;
using DBTrainingProject.Controllers;

namespace DBTrainingProject;

public partial class TableActions : Window
{
    public TableActions()
    {
        InitializeComponent();
    }

    private void ButtonRemove_OnClick(object sender, RoutedEventArgs e)
    {
        Controller.ExecuteCommand($"DELETE FROM {TableNameRemove.Text} WHERE {ConditionNameRemove.Text}");
        ConditionNameRemove.Text = "";
    }

    private void ButtonInsert_OnClick(object sender, RoutedEventArgs e)
    {
        Controller.ExecuteCommand(
            $"INSERT INTO {TableNameInsert.Text} ({ColumnNameInsert.Text}) VALUES ({ValuesInsert.Text})");
        ColumnNameInsert.Text = "";
        ValuesInsert.Text = "";
    }

    private void ButtonUpdate_OnClick(object sender, RoutedEventArgs e)
    {
        if (ConditionUpdate.Text == "")
        {
            Controller.ExecuteCommand(
                $"UPDATE {TableNameUpdate.Text} SET {ColumnNameUpdate.Text} = {ValuesUpdate.Text}");
            ColumnNameUpdate.Text = "";
            ValuesUpdate.Text = ""; 
            return;
        }

        Controller.ExecuteCommand(
            $"UPDATE {TableNameUpdate.Text} SET {ColumnNameUpdate.Text} = {ValuesUpdate.Text} WHERE {ConditionUpdate.Text}");
        ColumnNameUpdate.Text = "";
        ValuesUpdate.Text = ""; 
        ConditionUpdate.Text = "";
    }

    private void ButtonBack_OnClick(object sender, RoutedEventArgs e)
    {
        Close();
    }
}