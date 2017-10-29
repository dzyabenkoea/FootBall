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
using System.Windows.Controls;

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
        string url, region, idTeam;

        private void SaveAndCloseBut_Click(object sender, RoutedEventArgs e)
        {
            if(!AddEdit)
            {
                DBAdapter.DB.RunInsert("Insert Into [Teams] (flag_url, TeamName, countrycode, region) values('" + ImageCountry.Source + "','" + TeamNameTextBox.Text + "','" + CountryCodeTextBox.Text + "','" + RegionComBox.SelectedValue + "'))");
            }
            else
            {
                DBAdapter.DB.RunInsert("Update[Teams] Set flag_url = '" + TeamNameTextBox + "', TeamName = '" + TeamNameTextBox.Text + "', countrycode = '" + TeamNameTextBox.Text + "', region = '" + RegionComBox.SelectedValue + "' WHERE ID_Team = '" + idTeam + "'");
            }

            Close();
        }

        private void AddBut_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBut_Click(object sender, RoutedEventArgs e)
        {
            int i = DataGrid1.SelectedIndex;
            if (i != -1)
            {
                if (MessageBox.Show("Удалить?", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    DBAdapter.DB.RunInsert("Delete From [Players] Where ID_Player = '" + ((DataRowView)DataGrid1.Items[i]).Row[0].ToString() + "'");
            }
            else
            {
                MessageBox.Show("Выберите команду для удаления");
            }
        }

        private void AddBut_Click_1(object sender, RoutedEventArgs e)
        {
            AddEditPlayer form = new AddEditPlayer();
            form.Show();
        }

        private void EditBut_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid1.SelectedIndex != -1)
            {
                int i = DataGrid1.SelectedIndex;
                AddEditPlayer form = new AddEditPlayer(((DataRowView)DataGrid1.Items[i]).Row[0].ToString(), ((DataRowView)DataGrid1.Items[i]).Row[2].ToString(), ((DataRowView)DataGrid1.Items[i]).Row[1].ToString(), ((DataRowView)DataGrid1.Items[i]).Row[3].ToString(), ((DataRowView)DataGrid1.Items[i]).Row[4].ToString(), Convert.ToDateTime(((DataRowView)DataGrid1.Items[i]).Row[5]));
                form.Show();
            }
            else
            {
                MessageBox.Show("Выберите игрока для редактирования");
            }
        }

        private void CloseBut_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SelectFlagButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog myDialog = new Microsoft.Win32.OpenFileDialog();
            myDialog.Filter = "Картинки(*.JPG;*.PNG)|*.JPG;*.PNG";
            myDialog.CheckFileExists = true;
            myDialog.Multiselect = true;
            if (myDialog.ShowDialog() == true)
            {
                TeamNameTextBox.Text = myDialog.FileName;
            }
        }

        public AddEditTeam(string idTeam, string Url, string TeamName, string Region, string CountryCode)
        {
            InitializeComponent();
            AddEdit = true;
            //ImageCountry.Source = BitmapFrame.Create(new Uri(@"pack://siteoforigin:,,,/Resources/" + Url));
            url = Url;
            this.idTeam = idTeam;
            region = Region;
            TeamNameTextBox.Text = TeamName;
            CountryCodeTextBox.Text = CountryCode;
            url = url.Substring(url.IndexOf('\\') + 1);
        }

        void LoadPlayersTeam()
        {
            DataGrid1.ItemsSource = DBAdapter.DB.RunSelect("Select ID_Player As ID, firstname as [First name],  lastname As [Last name] , shirt_number As [Shirt number], position As Position, date_of_birth as [Date of birth] From [Players] where team_id = '" + idTeam + "'").DefaultView;
            DataGrid1.Columns[0].Visibility = Visibility.Hidden;
           //var s = ImageCountry.Source;
        }


    }
}
