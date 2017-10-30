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
    /// Логика взаимодействия для addedit_to_startinggrid.xaml
    /// </summary>
    public partial class AddEditToStartingGrid : Window
    {
        public AddEditToStartingGrid()
        {
            InitializeComponent();
        }
        bool AddEdit = false;
        string idPlayer;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //DataTable dt = DBAdapter.DB.RunSelect("SELECT Team1_ID, Team2_ID, Score1, Score2, Tournament_ID FROM Stage WHERE StageType_ID = 8");
            ////dt.DataSet.Tables[0];
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            LoadPlayers();
      
            

           
        }

        void LoadPlayers()
        {
            DataTable table = DBAdapter.DB.RunSelect("SELECT DISTINCT lastname FROM [Players]");
            for(int i =0; i < table.Rows.Count; i++)
            {
                Player.Items.Add(table.Rows[i][0].ToString());
            }
        }

        void LoadPositon()
        {
            DataTable table = DBAdapter.DB.RunSelect("SELECT DISTINCT position FROM [Players]");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Position.Items.Add(table.Rows[i][0].ToString());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!AddEdit)
            {
                DBAdapter.DB.RunInsert("Insert Into [Players] (lastname,position) values('" + Player.SelectedValue + "','" + Position.SelectedValue + "')");
            }
            else
            {
                if (Position.Text != "" && Player.Text != "")
                    DBAdapter.DB.RunInsert($"Update [Players] Set player = '{Player.SelectedValue}', position = '{Position.SelectedValue}' WHERE ID_Player = '{idPlayer}'");
                
            }
            EditGameStartingGrid frm = (EditGameStartingGrid)this.Owner;
            frm.AddEditPlayers();



            Close();
        }
    }
   
}
