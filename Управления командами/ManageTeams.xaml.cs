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
            LoadTeams();
        }

        void LoadTeams()
        {
            DataGrid1.ItemsSource = DBAdapter.DB.RunSelect("Select ID_Team As ID, flag_url, TeamName As Team, countrycode As Code, region From [Teams]").DefaultView;
            DataGrid1.Columns[4].Visibility = Visibility.Hidden;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataGrid1.ItemsSource = DBAdapter.DB.RunSelect("Select ID_Team As ID, flag_url, TeamName As Team, countrycode As Code, region From [Teams] Where TeamName Like '%" + SearchTextBox.Text +"%'").DefaultView;
        }

        private void AddBut_Click(object sender, RoutedEventArgs e)
        {
            AddEditTeam form = new AddEditTeam();
            form.Owner = this;
            form.Show();
        }

        private void EditBut_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid1.SelectedIndex != -1)
            {
                int i = DataGrid1.SelectedIndex;
                
                AddEditTeam form = new AddEditTeam(((DataRowView)DataGrid1.Items[i]).Row[0].ToString(), ((DataRowView)DataGrid1.Items[i]).Row[1].ToString(), ((DataRowView)DataGrid1.Items[i]).Row[2].ToString(), ((DataRowView)DataGrid1.Items[i]).Row[4].ToString(), ((DataRowView)DataGrid1.Items[i]).Row[3].ToString());
                form.Owner = this;
                form.Show();
            }
            else
            {
                MessageBox.Show("Выберите команду для редактирования");
            }

        }



        private void DeleteBut_Click(object sender, RoutedEventArgs e)
        {
            int i = DataGrid1.SelectedIndex;
            if (i != -1)
            {
                if(MessageBox.Show("Удалить?", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                DBAdapter.DB.RunInsert("Delete From [Teams] Where ID_Team = '" + ((DataRowView)DataGrid1.Items[i]).Row[0].ToString() + "'");
            }
            else
            {
                MessageBox.Show("Выберите команду для удаления");
            }
        }

        public void AddEditSel()
        {
      
        }
    }
}
