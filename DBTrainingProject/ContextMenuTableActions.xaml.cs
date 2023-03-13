using System.Data;
using System.Windows;
using System.Windows.Controls;
using DBTrainingProject.Controllers;

namespace DBTrainingProject;

public partial class ContextMenuTableActions : Window
{
    private DataRowView _rowView;
    private DataGrid _dataGrid;
    private string _tableName;

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
        Controller.ExecuteCommand(
            $"DELETE FROM {_tableName} WHERE {_dataGrid.Columns[0]} = {_rowView[0]} AND {_dataGrid.Columns[1]} = {_rowView[1]} AND{_dataGrid.Columns[2]} = {_rowView[2]}");
    }

    public void SetRowView(DataRowView rowView) => _rowView = rowView;
    public void SetDataGrid(DataGrid dataGrid) => _dataGrid = dataGrid;
    public void SetTableName(string tableName) => _tableName = tableName;
}