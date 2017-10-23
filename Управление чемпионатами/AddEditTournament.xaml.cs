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
using DBAdapter;
using System.Data;

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
            InitializeTable();
        }

        public AddEditTournament(DataGridRow dataGridRow)
        {
            InitializeComponent();
        }

        void InitializeTable()
        {
            //countriesSelectionTable.ItemsSource 
            DataTable dt = DB.RunSelect("select ID_Team, TeamName from Teams");
            foreach (DataRow dr in dt.Rows)
            {
                DataGridRow dataGridRow = new DataGridRow();
                
                countriesSelectionTable.Items.Add(dataGridRow);
            }
        }
        void UpdateTable()
        {
            countriesSelectionTable.ItemsSource = DB.RunSelect("select ID_Team,TeamName from Teams").DefaultView;
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
