using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using DBTrainingProject.Controllers;

namespace DBTrainingProject;

public partial class ConnectionWindow : Window
{
    private string ipAddress;
    private string port;
    private string dbName;
    private string login;
    private string password;

    public ConnectionWindow()
    {
        InitializeComponent();
    }

    private void ButtonInputIp_OnClick(object sender, RoutedEventArgs e)
    {
        ipAddress = IpAddress.Text;
        port = Port.Text;
        ButtonInputIp.Background = Brushes.Chartreuse;
    }

    private void ButtonInputNameDB_OnClick(object sender, RoutedEventArgs e)
    {
        dbName = DatabaseName.Text;
        ButtonInputNameDB.Background = Brushes.Chartreuse;
    }

    private void ButtonInputPassword_OnClick(object sender, RoutedEventArgs e)
    {
        login = Login.Text;
        password = Password.Text;
        ButtonInputPassword.Background = Brushes.Chartreuse;
    }

    private void ButtonConnected_OnClick(object sender, RoutedEventArgs e)
    {
        string connectionString;
        if (port.ToString() == "")
        {
            connectionString = $"Server={ipAddress};Database={dbName};User Id={login};Trusted_Connection=True;";
        }
        else
        {
            connectionString = $"Server={ipAddress}, {port};Database={dbName};User Id={login}; Password={password}";
        }

        Controller.CreateConnection(connectionString);

        Close();
    }
}