using System.Windows;
using Microsoft.AspNetCore.SignalR.Client;

namespace IUS_OKO
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HubConnection connection;
        public MainWindow()
        {
            InitializeComponent();
            
            connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7098/ius_oko")
                .Build();

            connection.On<string>("Receive", (message) =>
            {
                Dispatcher.Invoke(() =>
                {
                    var newMessage = $"{message}";
                    chatbox.Items.Insert(0, newMessage);
                });
            });
        }
    }
}