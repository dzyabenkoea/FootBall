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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Football
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class ManageSemiFinal : Window
    {
        public ManageSemiFinal()
        {
            InitializeComponent();
        }



        private void Finish_Click_1(object sender, RoutedEventArgs e)
        {
            // 2017.10.29 Михаил. Метод передаёт в форму ManageExecution метку Yes, когда работа с текущей формой закончена
            ManageExecutionMenu main = this.Owner as ManageExecutionMenu;
            if (main != null)
            {
                main.label5.Content = "Yes";
            }
        }

        private void Finish_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = DBAdapter.DB.RunSelect("SELECT Teams.TeamName, Stage.Score1, Stage.Score2, Stage.Tournament_ID FROM Stage, Teams WHERE (StageType_ID = 11)AND(Teams.ID_Team = Stage.Team1_ID)");
            DataTable dt1 = DBAdapter.DB.RunSelect("SELECT Teams.TeamName FROM Stage, Teams WHERE (StageType_ID = 11)AND(Teams.ID_Team = Stage.Team2_ID)");

        //    DataTable dt = DBAdapter.DB.RunSelect("Select Team1_ID, Team2_ID, Score1, Score2 From Stage Where StageType_ID = 11");
            Country1.Content = dt.Rows[0].ItemArray[0];
            Country2.Content = dt1.Rows[0].ItemArray[0];
            Point1.Content = dt.Rows[0].ItemArray[1];
            Point2.Content = dt.Rows[0].ItemArray[2];

            Country3.Content = dt.Rows[1].ItemArray[0];
            Country4.Content = dt1.Rows[1].ItemArray[0];
            Point3.Content = dt.Rows[1].ItemArray[1];
            Point4.Content = dt.Rows[1].ItemArray[2];
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Edit1_Click(object sender, RoutedEventArgs e)
        {
            EditGameStartingGrid gameStartingGrid = new EditGameStartingGrid();
            gameStartingGrid.Namegroup = Country1.Content.ToString() + "-" + Country2.Content.ToString();
            gameStartingGrid.Score = Point1.Content.ToString() + ":" + Point2.Content.ToString();
            gameStartingGrid.Owner = this;
            gameStartingGrid.ShowDialog();
        }

        private void Edit2_Click(object sender, RoutedEventArgs e)
        {
            EditGameStartingGrid gameStartingGrid = new EditGameStartingGrid();
            gameStartingGrid.Namegroup = Country3.Content.ToString() + "-" + Country4.Content.ToString();
            gameStartingGrid.Score = Point3.Content.ToString() + ":" + Point4.Content.ToString();
            gameStartingGrid.Owner = this;
            gameStartingGrid.ShowDialog();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            DataTable dt = DBAdapter.DB.RunSelect("SELECT Teams.TeamName, Stage.Score1, Stage.Score2, Stage.Tournament_ID FROM Stage, Teams WHERE (StageType_ID = 11)AND(Teams.ID_Team = Stage.Team1_ID)");
            DataTable dt1 = DBAdapter.DB.RunSelect("SELECT Teams.TeamName FROM Stage, Teams WHERE (StageType_ID = 11)AND(Teams.ID_Team = Stage.Team2_ID)");

            //    DataTable dt = DBAdapter.DB.RunSelect("Select Team1_ID, Team2_ID, Score1, Score2 From Stage Where StageType_ID = 11");
            Country1.Content = dt.Rows[0].ItemArray[0];
            Country2.Content = dt1.Rows[0].ItemArray[0];
            Point1.Content = dt.Rows[0].ItemArray[1];
            Point2.Content = dt.Rows[0].ItemArray[2];

            Country3.Content = dt.Rows[1].ItemArray[0];
            Country4.Content = dt1.Rows[1].ItemArray[0];
            Point3.Content = dt.Rows[1].ItemArray[1];
            Point4.Content = dt.Rows[1].ItemArray[2];
        }
    }
}

