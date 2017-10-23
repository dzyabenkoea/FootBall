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
using System.Data;

namespace Football
{
    /// <summary>
    /// Логика взаимодействия для ManageTeams.xaml
    /// </summary>
    public partial class ManageTeams : Window
    {
        public ManageTeams()
        {
            InitializeComponent();
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        void LoadTeams()
        {
            DataTable dt = DBAdapter.DB.RunSelect("Select ID_Team As ID, flag_url, TeamName As Team, countrycode As Code From [Teams]");
            DataGrid1.ItemsSource = dt.DefaultView;
            

        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataGrid1.ItemsSource = DBAdapter.DB.RunSelect("Select ID_Team As ID, flag_url, TeamName As Team, countrycode As Code From [Teams] Where TeamName = '"+ SearchTextBox.Text +"'").DefaultView;
        }

        private void AddBut_Click(object sender, RoutedEventArgs e)
        {
            ManageTeams form = new Football.ManageTeams();
            form.Show();
            DBAdapter.DB.RunInsert("Insert Into [Teams] (flag_url, TeamName, countrycode, region) values('" + SearchTextBox.Text+ "','" + SearchTextBox.Text + "','" + SearchTextBox.Text + "','" + SearchTextBox.Text + "'))");
        }
    }
}
