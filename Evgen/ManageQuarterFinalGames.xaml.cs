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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class ManageQuarterFinalGames : Window
    {
        public ManageQuarterFinalGames()
        {
            InitializeComponent();
        }

        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            // 2017.10.29 Михаил. Метод передаёт в форму ManageExecution метку Yes, когда работа с текущей формой закончена
            ManageExecutionMenu main = this.Owner as ManageExecutionMenu;
            if (main != null)
            {
                main.label4.Content = "Yes";
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                DataTable dt = DBAdapter.DB.RunSelect("SELECT Teams.TeamName, Stage.Score1, Stage.Score2, Stage.Tournament_ID FROM Stage, Teams WHERE (StageType_ID = 10)AND(Teams.ID_Team = Stage.Team1_ID)");
                DataTable dt1 = DBAdapter.DB.RunSelect("SELECT Teams.TeamName FROM Stage, Teams WHERE (StageType_ID = 10)AND(Teams.ID_Team = Stage.Team2_ID)");

                Country1.Content = dt.Rows[0].ItemArray[0];
                Country2.Content = dt1.Rows[0].ItemArray[0];
                Point1.Content = dt.Rows[0].ItemArray[1];
                Point2.Content = dt.Rows[0].ItemArray[2];

                Country3.Content = dt.Rows[1].ItemArray[0];
                Country4.Content = dt1.Rows[1].ItemArray[0];
                Point3.Content = dt.Rows[1].ItemArray[1];
                Point4.Content = dt.Rows[1].ItemArray[2];

                Country5.Content = dt.Rows[2].ItemArray[0];
                Country6.Content = dt1.Rows[2].ItemArray[0];
                Point5.Content = dt.Rows[2].ItemArray[1];
                Point6.Content = dt.Rows[2].ItemArray[2];

                Country7.Content = dt.Rows[3].ItemArray[0];
                Country8.Content = dt1.Rows[3].ItemArray[0];
                Point7.Content = dt.Rows[3].ItemArray[1];
                Point8.Content = dt.Rows[3].ItemArray[2];
            }
            catch { }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            EditGameStartingGrid gameStartingGrid = new EditGameStartingGrid();
            gameStartingGrid.Namegroup = Country1.Content.ToString() + "-" + Country2.Content.ToString();
            gameStartingGrid.Score = Point1.Content.ToString() + ":" + Point2.Content.ToString();
            gameStartingGrid.Owner = this;
            gameStartingGrid.ShowDialog();
        }

        private void Edit_Copy_Click(object sender, RoutedEventArgs e)
        {
            EditGameStartingGrid gameStartingGrid = new EditGameStartingGrid();
            gameStartingGrid.Namegroup = Country3.Content.ToString() + "-" + Country4.Content.ToString();
            gameStartingGrid.Score = Point3.Content.ToString() + ":" + Point4.Content.ToString();
            gameStartingGrid.Owner = this;
            gameStartingGrid.ShowDialog();
        }

        private void Edit_Copy1_Click(object sender, RoutedEventArgs e)
        {
            EditGameStartingGrid gameStartingGrid = new EditGameStartingGrid();
            gameStartingGrid.Namegroup = Country5.Content.ToString() + "-" + Country6.Content.ToString();
            gameStartingGrid.Score = Point5.Content.ToString() + ":" + Point6.Content.ToString();
            gameStartingGrid.Owner = this;
            gameStartingGrid.ShowDialog();
        }

        private void Edit_Copy2_Click(object sender, RoutedEventArgs e)
        {
            EditGameStartingGrid gameStartingGrid = new EditGameStartingGrid();
            gameStartingGrid.Namegroup = Country7.Content.ToString() + "-" + Country8.Content.ToString();
            gameStartingGrid.Score = Point7.Content.ToString() + ":" + Point8.Content.ToString();
            gameStartingGrid.Owner = this;
            gameStartingGrid.ShowDialog();
        }
    }
}
