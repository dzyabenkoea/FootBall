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
    /// Логика взаимодействия для ManageExecutionMenu.xaml
    /// </summary>
    public partial class ManageExecutionMenu : Window
    {
        public ManageExecutionMenu()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            AllocateTeamsToGroups _allocate = new AllocateTeamsToGroups();
            _allocate.Owner = this; 
            _allocate.ShowDialog();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ManageGroupStageResults _managegroup = new ManageGroupStageResults();
            _managegroup.Owner = this;
            _managegroup.ShowDialog();

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            ManageRoundOf16Games _manageround = new ManageRoundOf16Games();
            _manageround.Owner = this;
            _manageround.ShowDialog();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            ManageQuarterFinalGames _managequarter = new ManageQuarterFinalGames();
            _managequarter.Owner = this;
            _managequarter.ShowDialog();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            ManageSemiFinal _managesemi = new ManageSemiFinal();
            _managesemi.Owner = this;
            _managesemi.ShowDialog();
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            ManageFinal _managefinal = new ManageFinal();
            _managefinal.Owner = this;
            _managefinal.ShowDialog();
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
