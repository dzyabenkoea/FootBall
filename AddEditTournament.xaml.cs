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

namespace Football
{
    /// <summary>
    /// Логика взаимодействия для AddEditTournament.xaml
    /// </summary>
    public partial class AddEditTournament : Window
    {
        public AddEditTournament()
        {
            InitializeComponent();
        }
        public AddEditTournament(int rowID,DataGridRow dr)//Конструктор для сценария редактирования
        {
            InitializeComponent();

        }
    }
}
