﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Npgsql;

namespace IUS_OKO
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string databaseConnection = "Server=37.252.23.79; Port=5432; Database=default_db; User Id=gen_user; Password=197194208206bolt;";
        public MainWindow()
        {
            InitializeComponent();
            Window1 window = new Window1();
            window.Show();
        }
        private void SqlConnectionReader()
        {
            NpgsqlConnection sqlConnection = new NpgsqlConnection(databaseConnection);
            sqlConnection.Open();
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = sqlConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT data FROM discrete_level WHERE id = 1";
            command.Dispose();
            NpgsqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.HasRows)
            {
                
            }
            sqlConnection.Close();
        }
    }
}
