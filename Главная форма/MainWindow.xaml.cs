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
using DBAdapter;
using System.Data;

namespace Football
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            if (DB.CheckConnection())
            {
                connectionLabel.Background = new SolidColorBrush(Colors.LightGreen);
            }
            else
            {
                connectionLabel.Background = new SolidColorBrush(Colors.Red);
            }

        }

        private void ManageTournaments_Click(object sender, RoutedEventArgs e)
        {
            new ManageTournaments().Show();
        }

        private void ManageTeams_Click(object sender, RoutedEventArgs e)
        {
            ManageTeams form = new Football.ManageTeams();
            form.Show();
        }

        private void ManageExecution_Click(object sender, RoutedEventArgs e)
        {
            new ManageExecutionMenu().Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dataGridA.ItemsSource = DBAdapter.DB.RunSelect("Select A.TeamName As Team1, CONCAT (Score1, ':', Score2) as Score , B.TeamName As Team2 From (([Stage] inner join [Teams] A On [Stage].Team1_ID = A.ID_Team) inner join [Teams] B On [Stage].Team2_ID = B.ID_Team) Where StageType_ID='1' and Tournament_ID='1'").DefaultView;
            dataGridB.ItemsSource = DBAdapter.DB.RunSelect("Select A.TeamName As Team1, CONCAT (Score1, ':', Score2) as Score , B.TeamName As Team2 From (([Stage] inner join [Teams] A On [Stage].Team1_ID = A.ID_Team) inner join [Teams] B On [Stage].Team2_ID = B.ID_Team) Where StageType_ID='2' and Tournament_ID='1'").DefaultView;
            dataGridC.ItemsSource = DBAdapter.DB.RunSelect("Select A.TeamName As Team1, CONCAT (Score1, ':', Score2) as Score , B.TeamName As Team2 From (([Stage] inner join [Teams] A On [Stage].Team1_ID = A.ID_Team) inner join [Teams] B On [Stage].Team2_ID = B.ID_Team) Where StageType_ID='3' and Tournament_ID='1'").DefaultView;
            dataGridD.ItemsSource = DBAdapter.DB.RunSelect("Select A.TeamName As Team1, CONCAT (Score1, ':', Score2) as Score , B.TeamName As Team2 From (([Stage] inner join [Teams] A On [Stage].Team1_ID = A.ID_Team) inner join [Teams] B On [Stage].Team2_ID = B.ID_Team) Where StageType_ID='4' and Tournament_ID='1'").DefaultView;
            dataGridE.ItemsSource = DBAdapter.DB.RunSelect("Select A.TeamName As Team1, CONCAT (Score1, ':', Score2) as Score , B.TeamName As Team2 From (([Stage] inner join [Teams] A On [Stage].Team1_ID = A.ID_Team) inner join [Teams] B On [Stage].Team2_ID = B.ID_Team) Where StageType_ID='5' and Tournament_ID='1'").DefaultView;
            dataGridF.ItemsSource = DBAdapter.DB.RunSelect("Select A.TeamName As Team1, CONCAT (Score1, ':', Score2) as Score , B.TeamName As Team2 From (([Stage] inner join [Teams] A On [Stage].Team1_ID = A.ID_Team) inner join [Teams] B On [Stage].Team2_ID = B.ID_Team) Where StageType_ID='6' and Tournament_ID='1'").DefaultView;

            dataGridRound.ItemsSource = DBAdapter.DB.RunSelect("Select A.TeamName As Team1, CONCAT (Score1, ':', Score2) as Score , B.TeamName As Team2 From (([Stage] inner join [Teams] A On [Stage].Team1_ID = A.ID_Team) inner join [Teams] B On [Stage].Team2_ID = B.ID_Team) Where StageType_ID='8' and Tournament_ID='1'").DefaultView;
            dataGridQuarterfinals.ItemsSource = DBAdapter.DB.RunSelect("Select A.TeamName As Team1, CONCAT (Score1, ':', Score2) as Score , B.TeamName As Team2 From (([Stage] inner join [Teams] A On [Stage].Team1_ID = A.ID_Team) inner join [Teams] B On [Stage].Team2_ID = B.ID_Team) Where StageType_ID='10' and Tournament_ID='1'").DefaultView;
            DataTable semi = DBAdapter.DB.RunSelect("Select A.TeamName As Team1, CONCAT (Score1, ':', Score2) as Score , B.TeamName As Team2 From (([Stage] inner join [Teams] A On [Stage].Team1_ID = A.ID_Team) inner join [Teams] B On [Stage].Team2_ID = B.ID_Team) Where StageType_ID='11' and Tournament_ID='1'");

            

            dataGridFinal.ItemsSource = DBAdapter.DB.RunSelect("Select A.TeamName As Team1, CONCAT (Score1, ':', Score2) as Score , B.TeamName As Team2 From (([Stage] inner join [Teams] A On [Stage].Team1_ID = A.ID_Team) inner join [Teams] B On [Stage].Team2_ID = B.ID_Team) Where StageType_ID='12' and Tournament_ID='1'").DefaultView;

            if (semi.Rows.Count > 0 )
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Team1");
                dt.Columns.Add("Score");
                dt.Columns.Add("Team2");
                dt.Rows.Add(semi.Rows[0][0], semi.Rows[0][1], semi.Rows[0][2]);
                dataGridSemiFinal.ItemsSource = dt.DefaultView;

                dt = new DataTable();
                dt.Columns.Add("Team1");
                dt.Columns.Add("Score");
                dt.Columns.Add("Team2");
                dt.Rows.Add(semi.Rows[1][0], semi.Rows[1][1], semi.Rows[1][2]);
                dataGridSemiFinal1.ItemsSource = dt.DefaultView;
                //  dataGridA.Items.Add(BitmapFrame.Create(new Uri(@"pack://siteoforigin:,,,/Resources/" + "afc.png")));
            }


        }

        private void Window_Activated(object sender, EventArgs e)
        {
            dataGridA.ItemsSource = DBAdapter.DB.RunSelect("Select A.TeamName As Team1, CONCAT (Score1, ':', Score2) as Score , B.TeamName As Team2 From (([Stage] inner join [Teams] A On [Stage].Team1_ID = A.ID_Team) inner join [Teams] B On [Stage].Team2_ID = B.ID_Team) Where StageType_ID='1' and Tournament_ID='1'").DefaultView;
            dataGridB.ItemsSource = DBAdapter.DB.RunSelect("Select A.TeamName As Team1, CONCAT (Score1, ':', Score2) as Score , B.TeamName As Team2 From (([Stage] inner join [Teams] A On [Stage].Team1_ID = A.ID_Team) inner join [Teams] B On [Stage].Team2_ID = B.ID_Team) Where StageType_ID='2' and Tournament_ID='1'").DefaultView;
            dataGridC.ItemsSource = DBAdapter.DB.RunSelect("Select A.TeamName As Team1, CONCAT (Score1, ':', Score2) as Score , B.TeamName As Team2 From (([Stage] inner join [Teams] A On [Stage].Team1_ID = A.ID_Team) inner join [Teams] B On [Stage].Team2_ID = B.ID_Team) Where StageType_ID='3' and Tournament_ID='1'").DefaultView;
            dataGridD.ItemsSource = DBAdapter.DB.RunSelect("Select A.TeamName As Team1, CONCAT (Score1, ':', Score2) as Score , B.TeamName As Team2 From (([Stage] inner join [Teams] A On [Stage].Team1_ID = A.ID_Team) inner join [Teams] B On [Stage].Team2_ID = B.ID_Team) Where StageType_ID='4' and Tournament_ID='1'").DefaultView;
            dataGridE.ItemsSource = DBAdapter.DB.RunSelect("Select A.TeamName As Team1, CONCAT (Score1, ':', Score2) as Score , B.TeamName As Team2 From (([Stage] inner join [Teams] A On [Stage].Team1_ID = A.ID_Team) inner join [Teams] B On [Stage].Team2_ID = B.ID_Team) Where StageType_ID='5' and Tournament_ID='1'").DefaultView;
            dataGridF.ItemsSource = DBAdapter.DB.RunSelect("Select A.TeamName As Team1, CONCAT (Score1, ':', Score2) as Score , B.TeamName As Team2 From (([Stage] inner join [Teams] A On [Stage].Team1_ID = A.ID_Team) inner join [Teams] B On [Stage].Team2_ID = B.ID_Team) Where StageType_ID='6' and Tournament_ID='1'").DefaultView;

            dataGridRound.ItemsSource = DBAdapter.DB.RunSelect("Select A.TeamName As Team1, CONCAT (Score1, ':', Score2) as Score , B.TeamName As Team2 From (([Stage] inner join [Teams] A On [Stage].Team1_ID = A.ID_Team) inner join [Teams] B On [Stage].Team2_ID = B.ID_Team) Where StageType_ID='8' and Tournament_ID='1'").DefaultView;
            dataGridQuarterfinals.ItemsSource = DBAdapter.DB.RunSelect("Select A.TeamName As Team1, CONCAT (Score1, ':', Score2) as Score , B.TeamName As Team2 From (([Stage] inner join [Teams] A On [Stage].Team1_ID = A.ID_Team) inner join [Teams] B On [Stage].Team2_ID = B.ID_Team) Where StageType_ID='10' and Tournament_ID='1'").DefaultView;
            DataTable semi = DBAdapter.DB.RunSelect("Select A.TeamName As Team1, CONCAT (Score1, ':', Score2) as Score , B.TeamName As Team2 From (([Stage] inner join [Teams] A On [Stage].Team1_ID = A.ID_Team) inner join [Teams] B On [Stage].Team2_ID = B.ID_Team) Where StageType_ID='11' and Tournament_ID='1'");



            dataGridFinal.ItemsSource = DBAdapter.DB.RunSelect("Select A.TeamName As Team1, CONCAT (Score1, ':', Score2) as Score , B.TeamName As Team2 From (([Stage] inner join [Teams] A On [Stage].Team1_ID = A.ID_Team) inner join [Teams] B On [Stage].Team2_ID = B.ID_Team) Where StageType_ID='12' and Tournament_ID='1'").DefaultView;

            if (semi.Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Team1");
                dt.Columns.Add("Score");
                dt.Columns.Add("Team2");
                dt.Rows.Add(semi.Rows[0][0], semi.Rows[0][1], semi.Rows[0][2]);
                dataGridSemiFinal.ItemsSource = dt.DefaultView;

                dt = new DataTable();
                dt.Columns.Add("Team1");
                dt.Columns.Add("Score");
                dt.Columns.Add("Team2");
                dt.Rows.Add(semi.Rows[1][0], semi.Rows[1][1], semi.Rows[1][2]);
                dataGridSemiFinal1.ItemsSource = dt.DefaultView;
                //  dataGridA.Items.Add(BitmapFrame.Create(new Uri(@"pack://siteoforigin:,,,/Resources/" + "afc.png")));
            }
        }
    }
   
}
