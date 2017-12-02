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
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        string nameG;
        string score;
       public string Namegroup
        {
              set { nameG = value; }
        }
        public string Score
        {
            set { score = value; }
        }

        public bool IsEnded { get; set; }

        public int ID_Stage;
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            var q = $"Update [Stage] SET [IsFinished] = {Convert.ToInt32(Check1.IsChecked)} WHERE ID_Stage = {ID_Stage}";
            DBAdapter.DB.RunInsert(q);
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            Sc.Content = score;
            Result.Content = nameG;

            string[] nG = new string[2];
            nG = nameG.Split('-');
            Grid.ItemsSource = DBAdapter.DB.RunSelect("SELECT ID_Player AS [ID], lastname AS [Lastname], firstname as[Firstname], position AS Position FROM [Players] inner join Teams on Players.team_id=Teams.ID_Team Where TeamName ='" + nG[0] + "'").DefaultView;
            //Grid.Columns[3].Visibility = Visibility.Hidden;
            Grid2.ItemsSource = DBAdapter.DB.RunSelect("SELECT ID_Player AS [ID], lastname AS [Lastname], firstname as[Firstname], position AS Position FROM [Players] inner join Teams on Players.team_id=Teams.ID_Team Where TeamName ='" + nG[1] + "'").DefaultView;
            //Grid2.Columns[3].Visibility = Visibility.Hidden;

            // найти код команд
            int cod1comand = Convert.ToInt32( DBAdapter.DB.RunSelect(@"SELECT ID_Team
                                                      From Teams
                                                      Where TeamName = '"+ nG[0] + "'").Rows[0][0]);
            int cod2comand = Convert.ToInt32(DBAdapter.DB.RunSelect(@"SELECT ID_Team
                                                      From Teams
                                                      Where TeamName = '" + nG[1] + "'").Rows[0][0]);

            DataTable dt = DBAdapter.DB.RunSelect(@"SELECT *
                                                    From Stage
                                                    Where (Team1_ID = '"+ cod1comand + "' and Team2_ID = '"+ cod2comand + "')");

            Check1.IsChecked = (bool)dt.Rows[0]["IsFinished"];

        }

    }
}
