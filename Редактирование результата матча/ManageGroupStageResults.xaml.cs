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
    /// Логика взаимодействия для ManageGroupStageResults.xaml
    /// </summary>
    public partial class ManageGroupStageResults : Window
    {
        public ManageGroupStageResults()
        {
            InitializeComponent();
        }

        private void FinishButton_Click(object sender, RoutedEventArgs e)
        {
            // 2017.10.29 Михаил. Метод передаёт в форму ManageExecution метку Yes, когда работа с текущей формой закончена
            ManageExecutionMenu main = this.Owner as ManageExecutionMenu;
            if (main != null)
            {
                main.label3.Content = "Yes";
            }
        }

        private void Edit1Button_Click(object sender, RoutedEventArgs e)
        {
            EditGameStartingGrid gameStartingGrid = new EditGameStartingGrid();
            gameStartingGrid.Namegroup = Game1_Copy.Content.ToString() + "-" + Game1_Copy1.Content.ToString();
            gameStartingGrid.Score = Label1.Content.ToString();
            gameStartingGrid.Owner = this;
            gameStartingGrid.ShowDialog();
        }


        private void Edit2Button_Click(object sender, RoutedEventArgs e)
        {
            EditGameStartingGrid gameStartingGrid = new EditGameStartingGrid();
            gameStartingGrid.Namegroup = Game2.Content.ToString() + "-" + Game1_Copy2.Content.ToString();
            gameStartingGrid.Score = Label3.Content.ToString();
            gameStartingGrid.Owner = this;
            gameStartingGrid.ShowDialog();
        }

        private void Edit3Button_Click(object sender, RoutedEventArgs e)
        {
            EditGameStartingGrid gameStartingGrid = new EditGameStartingGrid();
            gameStartingGrid.Namegroup = Game3.Content.ToString() + "-" + Game1_Copy3.Content.ToString();
            gameStartingGrid.Score = Label4.Content.ToString();
            gameStartingGrid.Owner = this;
            gameStartingGrid.ShowDialog();
        }

        private void Edit4Button_Click(object sender, RoutedEventArgs e)
        {
            EditGameStartingGrid gameStartingGrid = new EditGameStartingGrid();
            gameStartingGrid.Namegroup = Game4.Content.ToString() + "-" + Game1_Copy4.Content.ToString();
            gameStartingGrid.Score = Label5.Content.ToString();
            gameStartingGrid.Owner = this;
            gameStartingGrid.ShowDialog();
        }

        private void Edit5Button_Click(object sender, RoutedEventArgs e)
        {
            EditGameStartingGrid gameStartingGrid = new EditGameStartingGrid();
            gameStartingGrid.Namegroup = Game5.Content.ToString() + "-" + Game1_Copy5.Content.ToString();
            gameStartingGrid.Score = Label6.Content.ToString();
            gameStartingGrid.Owner = this;
            gameStartingGrid.ShowDialog();
        }

        private void Edit6Button_Click(object sender, RoutedEventArgs e)
        {
            EditGameStartingGrid gameStartingGrid = new EditGameStartingGrid();
            gameStartingGrid.Namegroup = Game6.Content.ToString() + "-" + Game1_Copy6.Content.ToString();
            gameStartingGrid.Score = Label7.Content.ToString();
            gameStartingGrid.Owner = this;
            gameStartingGrid.ShowDialog();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            GroupComboBox.Items.Add("Group A");
            GroupComboBox.Items.Add("Group B");
            GroupComboBox.Items.Add("Group C");
            GroupComboBox.Items.Add("Group D");
            GroupComboBox.Items.Add("Group E");
            GroupComboBox.Items.Add("Group F");
            GroupComboBox.SelectedIndex = 0;

            DataTable dt = DBAdapter.DB.RunSelect("Select A From [Groups] ");
            DataTable team1 = DBAdapter.DB.RunSelect("Select TeamName From [Teams] where ID_Team= " + dt.Rows[0][0]);
            DataTable team2 = DBAdapter.DB.RunSelect("Select TeamName From [Teams] where ID_Team= " + dt.Rows[1][0]);
            DataTable team3 = DBAdapter.DB.RunSelect("Select TeamName From [Teams] where ID_Team= " + dt.Rows[2][0]);
            DataTable team4 = DBAdapter.DB.RunSelect("Select TeamName From [Teams] where ID_Team= " + dt.Rows[3][0]);

            Game1_Copy.Content = team1.Rows[0][0]; Game1_Copy1.Content = team2.Rows[0][0];
            Game2.Content = team3.Rows[0][0]; Game1_Copy2.Content = team4.Rows[0][0];
            Game3.Content = team2.Rows[0][0]; Game1_Copy3.Content = team4.Rows[0][0];
            Game4.Content = team1.Rows[0][0]; Game1_Copy4.Content = team3.Rows[0][0];
            Game5.Content = team4.Rows[0][0]; Game1_Copy5.Content = team1.Rows[0][0];
            Game1_Copy.Content = team1.Rows[0][0]; Game1_Copy1.Content = team2.Rows[0][0];
            Game6.Content = team2.Rows[0][0]; Game1_Copy6.Content = team3.Rows[0][0];
        }

        private void GroupComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(GroupComboBox.SelectedIndex==0)
            {
                DataTable dt = DBAdapter.DB.RunSelect("Select A From [Groups] ");
                DataTable team1 = DBAdapter.DB.RunSelect("Select TeamName From [Teams] where ID_Team= " + dt.Rows[0][0]);
                DataTable team2 = DBAdapter.DB.RunSelect("Select TeamName From [Teams] where ID_Team= " + dt.Rows[1][0]);
                DataTable team3 = DBAdapter.DB.RunSelect("Select TeamName From [Teams] where ID_Team= " + dt.Rows[2][0]);
                DataTable team4 = DBAdapter.DB.RunSelect("Select TeamName From [Teams] where ID_Team= " + dt.Rows[3][0]);

                Game1_Copy.Content = team1.Rows[0][0]; Game1_Copy1.Content = team2.Rows[0][0];
                Game2.Content = team3.Rows[0][0]; Game1_Copy2.Content = team4.Rows[0][0];
                Game3.Content = team2.Rows[0][0]; Game1_Copy3.Content = team4.Rows[0][0];
                Game4.Content = team1.Rows[0][0]; Game1_Copy4.Content = team3.Rows[0][0];
                Game5.Content = team4.Rows[0][0]; Game1_Copy5.Content = team1.Rows[0][0];
                Game1_Copy.Content = team1.Rows[0][0]; Game1_Copy1.Content = team2.Rows[0][0];
                Game6.Content = team2.Rows[0][0]; Game1_Copy6.Content = team3.Rows[0][0];
            }
            else if(GroupComboBox.SelectedIndex == 1)
            {
                DataTable dt = DBAdapter.DB.RunSelect("Select B From [Groups] ");
                DataTable team1 = DBAdapter.DB.RunSelect("Select TeamName From [Teams] where ID_Team= " + dt.Rows[0][0]);
                DataTable team2 = DBAdapter.DB.RunSelect("Select TeamName From [Teams] where ID_Team= " + dt.Rows[1][0]);
                DataTable team3 = DBAdapter.DB.RunSelect("Select TeamName From [Teams] where ID_Team= " + dt.Rows[2][0]);
                DataTable team4 = DBAdapter.DB.RunSelect("Select TeamName From [Teams] where ID_Team= " + dt.Rows[3][0]);

                Game1_Copy.Content = team1.Rows[0][0]; Game1_Copy1.Content = team2.Rows[0][0];
                Game2.Content = team3.Rows[0][0]; Game1_Copy2.Content = team4.Rows[0][0];
                Game3.Content = team2.Rows[0][0]; Game1_Copy3.Content = team4.Rows[0][0];
                Game4.Content = team1.Rows[0][0];Game1_Copy4.Content = team3.Rows[0][0];
                Game5.Content = team4.Rows[0][0]; Game1_Copy5.Content = team1.Rows[0][0];
                Game1_Copy.Content = team1.Rows[0][0];Game1_Copy1.Content = team2.Rows[0][0];
                Game6.Content = team2.Rows[0][0]; Game1_Copy6.Content = team3.Rows[0][0];
            }
            else if (GroupComboBox.SelectedIndex == 2)
            {
                DataTable dt = DBAdapter.DB.RunSelect("Select C From [Groups] ");
                DataTable team1 = DBAdapter.DB.RunSelect("Select TeamName From [Teams] where ID_Team= " + dt.Rows[0][0]);
                DataTable team2 = DBAdapter.DB.RunSelect("Select TeamName From [Teams] where ID_Team= " + dt.Rows[1][0]);
                DataTable team3 = DBAdapter.DB.RunSelect("Select TeamName From [Teams] where ID_Team= " + dt.Rows[2][0]);
                DataTable team4 = DBAdapter.DB.RunSelect("Select TeamName From [Teams] where ID_Team= " + dt.Rows[3][0]);


                Game1_Copy.Content = team1.Rows[0][0]; Game1_Copy1.Content = team2.Rows[0][0];
                Game2.Content = team3.Rows[0][0]; Game1_Copy2.Content = team4.Rows[0][0];
                Game3.Content = team2.Rows[0][0]; Game1_Copy3.Content = team4.Rows[0][0];
                Game4.Content = team1.Rows[0][0]; Game1_Copy4.Content = team3.Rows[0][0];
                Game5.Content = team4.Rows[0][0]; Game1_Copy5.Content = team1.Rows[0][0];
                Game1_Copy.Content = team1.Rows[0][0]; Game1_Copy1.Content = team2.Rows[0][0];
                Game6.Content = team2.Rows[0][0]; Game1_Copy6.Content = team3.Rows[0][0];
            }
            else if (GroupComboBox.SelectedIndex == 3)
            {
                DataTable dt = DBAdapter.DB.RunSelect("Select D From [Groups] ");
                DataTable team1 = DBAdapter.DB.RunSelect("Select TeamName From [Teams] where ID_Team= " + dt.Rows[0][0]);
                DataTable team2 = DBAdapter.DB.RunSelect("Select TeamName From [Teams] where ID_Team= " + dt.Rows[1][0]);
                DataTable team3 = DBAdapter.DB.RunSelect("Select TeamName From [Teams] where ID_Team= " + dt.Rows[2][0]);
                DataTable team4 = DBAdapter.DB.RunSelect("Select TeamName From [Teams] where ID_Team= " + dt.Rows[3][0]);

                Game1_Copy.Content = team1.Rows[0][0]; Game1_Copy1.Content = team2.Rows[0][0];
                Game2.Content = team3.Rows[0][0]; Game1_Copy2.Content = team4.Rows[0][0];
                Game3.Content = team2.Rows[0][0]; Game1_Copy3.Content = team4.Rows[0][0];
                Game4.Content = team1.Rows[0][0]; Game1_Copy4.Content = team3.Rows[0][0];
                Game5.Content = team4.Rows[0][0]; Game1_Copy5.Content = team1.Rows[0][0];
                Game1_Copy.Content = team1.Rows[0][0]; Game1_Copy1.Content = team2.Rows[0][0];
                Game6.Content = team2.Rows[0][0]; Game1_Copy6.Content = team3.Rows[0][0];
            }
            else if (GroupComboBox.SelectedIndex == 4)
            {
                DataTable dt = DBAdapter.DB.RunSelect("Select E From [Groups] ");
                DataTable team1 = DBAdapter.DB.RunSelect("Select TeamName From [Teams] where ID_Team= " + dt.Rows[0][0]);
                DataTable team2 = DBAdapter.DB.RunSelect("Select TeamName From [Teams] where ID_Team= " + dt.Rows[1][0]);
                DataTable team3 = DBAdapter.DB.RunSelect("Select TeamName From [Teams] where ID_Team= " + dt.Rows[2][0]);
                DataTable team4 = DBAdapter.DB.RunSelect("Select TeamName From [Teams] where ID_Team= " + dt.Rows[3][0]);

                Game1_Copy.Content = team1.Rows[0][0]; Game1_Copy1.Content = team2.Rows[0][0];
                Game2.Content = team3.Rows[0][0]; Game1_Copy2.Content = team4.Rows[0][0];
                Game3.Content = team2.Rows[0][0]; Game1_Copy3.Content = team4.Rows[0][0];
                Game4.Content = team1.Rows[0][0]; Game1_Copy4.Content = team3.Rows[0][0];
                Game5.Content = team4.Rows[0][0]; Game1_Copy5.Content = team1.Rows[0][0];
                Game1_Copy.Content = team1.Rows[0][0]; Game1_Copy1.Content = team2.Rows[0][0];
                Game6.Content = team2.Rows[0][0]; Game1_Copy6.Content = team3.Rows[0][0];
            }
            else if (GroupComboBox.SelectedIndex == 5)
            {
                DataTable dt = DBAdapter.DB.RunSelect("Select F From [Groups] ");
                DataTable team1 = DBAdapter.DB.RunSelect("Select TeamName From [Teams] where ID_Team= " + dt.Rows[0][0]);
                DataTable team2 = DBAdapter.DB.RunSelect("Select TeamName From [Teams] where ID_Team= " + dt.Rows[1][0]);
                DataTable team3 = DBAdapter.DB.RunSelect("Select TeamName From [Teams] where ID_Team= " + dt.Rows[2][0]);
                DataTable team4 = DBAdapter.DB.RunSelect("Select TeamName From [Teams] where ID_Team= " + dt.Rows[3][0]);

                Game1_Copy.Content = team1.Rows[0][0]; Game1_Copy1.Content = team2.Rows[0][0];
                Game2.Content = team3.Rows[0][0]; Game1_Copy2.Content = team4.Rows[0][0];
                Game3.Content = team2.Rows[0][0]; Game1_Copy3.Content = team4.Rows[0][0];
                Game4.Content = team1.Rows[0][0]; Game1_Copy4.Content = team3.Rows[0][0];
                Game5.Content = team4.Rows[0][0]; Game1_Copy5.Content = team1.Rows[0][0];
                Game1_Copy.Content = team1.Rows[0][0]; Game1_Copy1.Content = team2.Rows[0][0];
                Game6.Content = team2.Rows[0][0]; Game1_Copy6.Content = team3.Rows[0][0];
            }
        }
    }
}
