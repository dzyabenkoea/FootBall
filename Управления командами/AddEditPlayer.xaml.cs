using System;
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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class AddEditPlayer : Window
    {
        public AddEditPlayer()
        {
            InitializeComponent();
        }

        bool AddEdit = false;

        private void SaveClose_Click(object sender, RoutedEventArgs e)
        {
            if (!AddEdit)
            {
                DBAdapter.DB.RunInsert("Insert Into [Players] (lastname, firstname, shirt_number, position, date_of_birth) values('" + LastNameTextBox.Text + "','" + FirstNameTextBox.Text + "','" + ShirtNumberTextBox.Text + "','" + PositionTextBox.Text + "','" + DatePicker.Text + "'))");
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public AddEditPlayer(string idPlayer, string lastName, string firstName, string shirtNumber,  string position, DateTime birthDate)
        {
            InitializeComponent();
            AddEdit = true;
            LastNameTextBox.Text = lastName;
            FirstNameTextBox.Text = firstName;
            ShirtNumberTextBox.Text = shirtNumber;
            PositionTextBox.Text = position;
            DatePicker.SelectedDate = birthDate; // Edit Lesha
        }
    }
}
