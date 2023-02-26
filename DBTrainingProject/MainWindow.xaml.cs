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
        private Controller controller;

        public MainWindow()
        {
            InitializeComponent();
            controller = new Controller();
            connectionString = "Server=CHARNELE;Database=DOROFEEV;User Id=CHARNELE\\horpi;Trusted_Connection=True;";
        }

        private void ButtonConnection_OnClick(object sender, RoutedEventArgs e)
        {
            controller.CreateConnection(connectionString);
        }

        private void ButtonSelectTable_OnClick(object sender, RoutedEventArgs e)
        {
            StudentsGrid.ItemsSource = controller.GetTable("select * from forsales").DefaultView;
        }
    }
}