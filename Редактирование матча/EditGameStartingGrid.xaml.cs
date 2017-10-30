using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для editgame_starting_grid.xaml
    /// </summary>
    public partial class EditGameStartingGrid : Window
    {
        public EditGameStartingGrid()
        {
            InitializeComponent();           
        }
        bool AddEdit = false;

        void LoadPlayers()
        {
            Grid.ItemsSource = DBAdapter.DB.RunSelect("SELECT ID_Player AS [ID], lastname AS [Lastname], position AS Position FROM [Players]").DefaultView;
            Grid.Columns[3].Visibility = Visibility.Hidden;
        }
        void LoadPlayers_1()
        {
            Grid2.ItemsSource = DBAdapter.DB.RunSelect("SELECT ID_Player AS [ID], lastname AS [Lastname], position AS Position FROM [Players]").DefaultView;
            Grid2.Columns[3].Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddEditToStartingGrid addEditToStarting = new AddEditToStartingGrid();
            addEditToStarting.Owner = this;
            addEditToStarting.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AddEditToStartingGrid addEditToStarting = new AddEditToStartingGrid();
            addEditToStarting.Owner = this;
            addEditToStarting.ShowDialog();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            LoadPlayers();
           

                }
        
        public void AddEditPlayers()
        {
            void LoadPlayers()
            {
                Grid.ItemsSource = DBAdapter.DB.RunSelect("SELECT ID_Player AS [ID], lastname AS [Lastname], position AS Position FROM [Players]").DefaultView;
                Grid.Columns[3].Visibility = Visibility.Hidden;
               
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            int i = Grid.SelectedIndex;
            if (i != -1)
            {
                if (MessageBox.Show("Удалить?", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    DBAdapter.DB.RunInsert("Delete From [Players] Where ID_Player = '" + ((DataRowView)Grid.Items[i]).Row[0].ToString() + "'");
            }
            else
            {
                MessageBox.Show("Выберите команду для удаления");
            }

        }
        private void Grid2_Loaded(object sender, RoutedEventArgs e)
        {
            LoadPlayers();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            int i = Grid2.SelectedIndex;
            if (i != -1)
            {
                if (MessageBox.Show("Удалить?", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    DBAdapter.DB.RunInsert("Delete From [Players] Where ID_Player = '" + ((DataRowView)Grid2.Items[i]).Row[0].ToString() + "'");
            }
            else
            {
                MessageBox.Show("Выберите команду для удаления");
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            //if (!AddEdit)
            //{
            //    DBAdapter.DB.RunInsert("Insert Into [Players] (lastname,position) values('" + Player.SelectedValue + "','" + Position.SelectedValue + "')");
            //}
            //else
            //{
            //    if (Position.Text != "" && Player.Text != "")
            //        DBAdapter.DB.RunInsert($"Update [Players] Set player = '{Player.SelectedValue}', position = '{Position.SelectedValue}' WHERE ID_Player = '{idPlayer}'");

            //}
            //EditGameStartingGrid frm = (EditGameStartingGrid)this.Owner;
            //frm.AddEditPlayers();
            Close();
        }
        
    }
}
