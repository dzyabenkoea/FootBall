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
using System.Data;
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
            InitializeTable();
        }

        void InitializeTable()
        {
            DataTable dt = DB.RunSelect("select * from Tournaments");

            foreach (DataColumn dc in dt.Columns)
            {
                DataGridTextColumn newColumn = new DataGridTextColumn();
                newColumn.Header = dc.ColumnName;
                newColumn.Binding = new Binding(dc.ColumnName);
            }
            string[] columnsToShow = new string[] { "TournamentsName", "Start_date", "End_Date" };
            string[] columnsAliases = new string[] { "Tournament", "Start date", "End date" };

            tournamentsTable.ItemsSource = dt.DefaultView;

        }

        void UpdateTable()
        {
            tournamentsTable.ItemsSource = DB.SelectEntireTable("Tournaments").DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new AddEditTournament().Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddEditTournament addEdit = new AddEditTournament(tournamentsTable.SelectedItem as DataGridRow);
            addEdit.Owner = this;
            addEdit.FillFields(tournamentsTable.SelectedItem as DataRowView);
            addEdit.Show();
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
