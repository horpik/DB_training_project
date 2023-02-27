using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using DBTrainingProject.Controllers;
using DBTrainingProject.DB;

namespace DBTrainingProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string connectionString;
        private string nameTable;
        private DataTable dataTable;

        public MainWindow()
        {
            InitializeComponent();
            connectionString = "Server=CHARNELE;Database=DOROFEEV;User Id=CHARNELE\\horpi;Trusted_Connection=True;";
            //connectionString = "Server=5.228.168.187, 13971;Database=mirea;User Id=mirea; Password=mirea;";
        }

        private void ButtonConnection_OnClick(object sender, RoutedEventArgs e)
        {
            // ConnectionWindow connectionWindow = new ConnectionWindow();
            // connectionWindow.Show();
            Controller.CreateConnection(connectionString);
        }

        private void ButtonAllowCommand_OnClick(object sender, RoutedEventArgs e)
        {
            string command = TextBoxCommand.Text;
            if (command.ToLower().Contains("select"))
            {
                TableGrid.ItemsSource = Controller.GetTable(command).DefaultView;
            }
            else
            {
                Controller.ExecuteCommand(command);
                TableGrid.ItemsSource = Controller.GetTable(command).DefaultView;
            }
        }

        private void ButtonAllowSelect_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                nameTable = NameSelectTable.Text;
                var tmp = Controller.GetTable("select * from " + nameTable);
                TableGrid.ItemsSource = tmp.DefaultView;
                dataTable = tmp;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void ButtonTableActions_OnClick(object sender, RoutedEventArgs e)
        {
            TableActions tableActions = new TableActions();
            tableActions.Show();
        }

        private void Update_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (NameSelectTable.Text == "")
                {
                    MessageBox.Show("Укажите название таблицы");
                    return;
                }

                var tmp = Controller.GetTable("select * from " + nameTable);
                TableGrid.ItemsSource = tmp.DefaultView;
                dataTable = tmp;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void TableGrid_OnBeginningEdit(object? sender, DataGridBeginningEditEventArgs e)
        {
            DataRowView rowView = e.Row.Item as DataRowView;
            // ContextMenuTableActions contextMenuTableActions = new ContextMenuTableActions();
            // contextMenuTableActions.SetRowView(rowView);
            // contextMenuTableActions.SetTableName(NameSelectTable.Text);
            // contextMenuTableActions.Show();
            if (rowView.Row["Image"] is string imageStr) TableImage.Source = new BitmapImage(new Uri(imageStr));
        }

        private void ExportPDF_OnClick(object sender, RoutedEventArgs e)
        {
            Controller.SaveToPDF(dataTable);
        }
    }
}