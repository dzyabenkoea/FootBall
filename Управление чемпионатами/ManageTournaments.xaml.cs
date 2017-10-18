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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DBAdapter;

namespace Football
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class ManageTournaments : Window
    {
        public ManageTournaments()
        {
            InitializeComponent();
            FillTableWithCountries();
            UpdateTable();

        }

        void InititializeTable()
        {
            tournamentsTable.Columns[0].Visibility = Visibility.Hidden;
        }

        void UpdateTable()
        {
            tournamentsTable.ItemsSource = DB.SelectEntireTable("Tournaments").DefaultView;
        }

        void FillTableWithCountries()
        {
            //  foreach(string s in )
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new AddEditTournament().Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new AddEditTournament(tournamentsTable.SelectedItem as DataGridRow).Show();
        }

        private void tournamentsTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tournamentsTable.SelectedItem != null)
            {
                editButton.IsEnabled = true;
                deleteButton.IsEnabled = true;
            }
        }
    }
}
