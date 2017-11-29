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
    /// 


    public class Tournament
    {
        int id;
        string name;
        DateTime startDate, endDate;

        public Tournament(int id, string name, DateTime startDate, DateTime endDate)
        {
            this.id = id;
            this.name = name;
            this.startDate = startDate;
            this.endDate = endDate;
        }
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }
        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }
    }

    public partial class ManageTournaments : Window
    {
        DataTable tournaments;

        public ManageTournaments()
        {
            InitializeComponent();
            InitializeTable();
        }

        void InitializeTable()
        {
            tournaments = DB.RunSelect("select * from Tournaments");
            tournamentsTable.ItemsSource = tournaments.DefaultView;
        }

        void UpdateTable()
        {
            tournaments = DB.SelectEntireTable("Tournaments");
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
