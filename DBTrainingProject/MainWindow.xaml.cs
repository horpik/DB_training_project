using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
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

        public MainWindow()
        {
            InitializeComponent();
            // connectionString = "Server=CHARNELE;Database=DOROFEEV;User Id=CHARNELE\\horpi;Trusted_Connection=True;";
            connectionString = "Server=5.228.168.187, 13971;Database=mirea;User Id=mirea; Password=mirea;";
        }

        private void ButtonConnection_OnClick(object sender, RoutedEventArgs e)
        {
            ConnectionWindow connectionWindow = new ConnectionWindow();
            connectionWindow.Show();
            // Controller.CreateConnection(connectionString);
        }

        private void ButtonSelectTable_OnClick(object sender, RoutedEventArgs e)
        {
            StudentsGrid.ItemsSource = Controller.GetTable("SELECT * FROM dorofeev").DefaultView;
        }
    }
}