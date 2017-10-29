﻿using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using DBAdapter;

namespace Football
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
    
        public MainWindow()
        {
            InitializeComponent();
            if (DB.CheckConnection())
            {
                connectionLabel.Background = new SolidColorBrush(Colors.LightGreen);
            }
            else
            {
                connectionLabel.Background = new SolidColorBrush(Colors.Red);
            }

        }

        private void ManageTournaments_Click(object sender, RoutedEventArgs e)
        {
            new ManageTournaments().Show();
        }

        private void ManageTeams_Click(object sender, RoutedEventArgs e)
        {
            ManageTeams form = new Football.ManageTeams();
            form.Show();
        }

        private void ManageExecution_Click(object sender, RoutedEventArgs e)
        {
            new ManageExecutionMenu().Show();
        }
    }
}
