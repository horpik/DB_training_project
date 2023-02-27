using System.Data;
using System.Windows;
using DBTrainingProject.Controllers;

namespace DBTrainingProject;

public partial class ContextMenuTableActions : Window
{
    private DataRowView _rowView;
    private string nameTable;

    public ContextMenuTableActions()
    {
        InitializeComponent();
    }

    private void Change_OnClick(object sender, RoutedEventArgs e)
    {
        // throw new System.NotImplementedException();
    }
    private void Delete_OnClick(object sender, RoutedEventArgs e)
    {
        // Controller.ExecuteCommand($"DELETE FROM {nameTable} WHERE 'SalesReasonID' = {_rowView[0]}");
    }
    public void SetRowView(DataRowView rowView) => _rowView = rowView;
    public void SetTableName(string nameTable) => this.nameTable = nameTable;
}