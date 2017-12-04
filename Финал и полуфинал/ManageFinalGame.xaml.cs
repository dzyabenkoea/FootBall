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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class ManageFinal : Window
    {
        public int ID_Stage { get; private set; }
        public bool IsEnded { get; private set; }

        public ManageFinal()
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = DBAdapter.DB.RunSelect("SELECT Stage.ID_Stage AS [ID_Stage], Teams.TeamName, Stage.Score1, Stage.Score2, Stage.Tournament_ID FROM Stage, Teams WHERE (StageType_ID = 12)AND(Teams.ID_Team = Stage.Team1_ID)");
            DataTable dt1 = DBAdapter.DB.RunSelect("SELECT Teams.TeamName FROM Stage, Teams WHERE (StageType_ID = 12)AND(Teams.ID_Team = Stage.Team2_ID)");

            Country1.Content = dt.Rows[0].ItemArray[1];
            Country2.Content = dt1.Rows[0].ItemArray[0];
            Point1.Content = dt.Rows[0].ItemArray[2];
            Point2.Content = dt.Rows[0].ItemArray[3];
            ID_Stage = (int)dt.Rows[0]["ID_Stage"];
            //IsEnded = (bool)dt.Rows[0]["IsEnded"];


        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            EditGameStartingGrid gameStartingGrid = new EditGameStartingGrid();
            gameStartingGrid.Namegroup = Country1.Content.ToString() + "-" + Country2.Content.ToString();
            gameStartingGrid.Score = Point1.Content.ToString() + ":" + Point2.Content.ToString();
            gameStartingGrid.Owner = this;
            gameStartingGrid.ID_Stage = ID_Stage;
            gameStartingGrid.IsEnded = IsEnded;

            gameStartingGrid.ShowDialog();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            DataTable dt = DBAdapter.DB.RunSelect("SELECT Stage.ID_Stage AS [ID_Stage], Teams.TeamName, Stage.Score1, Stage.Score2, Stage.Tournament_ID FROM Stage, Teams WHERE (StageType_ID = 11)AND(Teams.ID_Team = Stage.Team1_ID)");
            DataTable dt1 = DBAdapter.DB.RunSelect("SELECT Teams.TeamName FROM Stage, Teams WHERE (StageType_ID = 12)AND(Teams.ID_Team = Stage.Team2_ID)");

            Country1.Content = dt.Rows[0].ItemArray[1];
            Country2.Content = dt1.Rows[0].ItemArray[0];
            Point1.Content = dt.Rows[0].ItemArray[2];
            Point2.Content = dt.Rows[0].ItemArray[3];
            ID_Stage = (int)dt.Rows[0]["ID_Stage"];
            //IsEnded = (bool)dt.Rows[0]["IsEnded"];
        }
    }
}
