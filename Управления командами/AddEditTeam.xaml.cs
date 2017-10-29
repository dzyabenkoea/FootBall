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
    /// Логика взаимодействия для AddEditTeam.xaml
    /// </summary>
    public partial class AddEditTeam : Window
    {
        public AddEditTeam()
        {
            InitializeComponent();
        }

        bool AddEdit = false;
        string url, region;

        private void EditBut_Copy_Click(object sender, RoutedEventArgs e)
        {
            if(!AddEdit)
            {
                DBAdapter.DB.RunInsert("Insert Into [Teams] (flag_url, TeamName, countrycode, region) values('" + CountryCodeTextBox.Text + "','" + CountryCodeTextBox.Text + "','" + CountryCodeTextBox.Text + "','" + CountryCodeTextBox.Text + "'))");
            }
        }

        private void AddBut_Click(object sender, RoutedEventArgs e)
        {

        }

        public AddEditTeam(string idTeam, string Url, string TeamName, string Region, string CountryCode)
        {
            InitializeComponent();
            AddEdit = true;
            url = Url;
            region = Region;
            TeamNameTextBox.Text = TeamName;
            CountryCodeTextBox.Text = CountryCode;
        }

       
    }
}
