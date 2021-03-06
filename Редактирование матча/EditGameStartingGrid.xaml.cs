﻿using System;
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
            //if (Check2.IsThreeState==true)
            //{ Ev.Visibility = Visibility.Visible; }
        }

        int cod1comand;
        int cod2comand;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        string nameG;
        string score;
        string[] nG = new string[2];
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
            var q = $"Update [Stage] SET [IsFinished] = {Convert.ToInt32(Check1.IsChecked)} WHERE ID_Stage = {StageID_}";
            DBAdapter.DB.RunInsert(q);
            

            
            Close();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            Result.Content = nameG;

            nG = nameG.Split('-');
            Grid.ItemsSource = DBAdapter.DB.RunSelect("SELECT ID_Player AS [ID], lastname AS [Lastname], firstname as[Firstname], position AS Position FROM [Players] inner join Teams on Players.team_id=Teams.ID_Team Where TeamName ='" + nG[0] + "'").DefaultView;
            //Grid.Columns[3].Visibility = Visibility.Hidden;
            Grid2.ItemsSource = DBAdapter.DB.RunSelect("SELECT ID_Player AS [ID], lastname AS [Lastname], firstname as[Firstname], position AS Position FROM [Players] inner join Teams on Players.team_id=Teams.ID_Team Where TeamName ='" + nG[1] + "'").DefaultView;
            //Grid2.Columns[3].Visibility = Visibility.Hidden;

            // найти код команд
             cod1comand = Convert.ToInt32( DBAdapter.DB.RunSelect(@"SELECT ID_Team
                                                      From Teams
                                                      Where TeamName = '"+ nG[0] + "'").Rows[0][0]);
             cod2comand = Convert.ToInt32(DBAdapter.DB.RunSelect(@"SELECT ID_Team
                                                      From Teams
                                                      Where TeamName = '" + nG[1] + "'").Rows[0][0]);
            
            DataTable dt = DBAdapter.DB.RunSelect(@"SELECT *
                                                    From Stage
                                                    Where (Team1_ID = '"+ cod1comand + "' and Team2_ID = '"+ cod2comand + "')");
            if (dt.Rows.Count > 0)
            {
                Team1 = nG[0];
                Team2 = nG[1];
                TableEvents((int)dt.Rows[0].ItemArray[0]);
                StageID_ = (int)dt.Rows[0].ItemArray[0];

                Score1_ = (int)dt.Rows[0].ItemArray[3];
                Score2_ = (int)dt.Rows[0].ItemArray[4];
                Sc.Content = (Score1_+":"+Score2_).ToString();
            }
            Check1.IsChecked = (bool)dt.Rows[0]["IsFinished"];

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//add event
        {
          //  AddEditGameEvent addEditGameEvent = new AddEditGameEvent(StageID_, Team1, Team2, id_event, s, Min, Event, Info, Score1_, Score2_);
            AddEditGameEvent addEditGameEvent = new AddEditGameEvent(StageID_, Team1, Team2,Score1_,Score2_);
            addEditGameEvent.Show();


        }
        public void Refresh(int sc1, int sc2, int st,string t1,string t2)
        {
            cod1comand = Convert.ToInt32(DBAdapter.DB.RunSelect(@"SELECT ID_Team
                                                      From Teams
                                                      Where TeamName = '" +t1 + "'").Rows[0][0]);
            cod2comand = Convert.ToInt32(DBAdapter.DB.RunSelect(@"SELECT ID_Team
                                                      From Teams
                                                      Where TeamName = '" + t2 + "'").Rows[0][0]);


            StageID_ =st;
            TableEvent.ItemsSource = null;
            
            TableEvent.Items.Refresh();
            TableEvent.ItemsSource = DBAdapter.DB.RunSelect("SELECT ID_Event, Min, Team_ID, Event, AdditionalInformation from [Events] where Stage_ID ='" + StageID_ + "'").DefaultView;
            Score1_=sc1;
            Score2_=sc2;
            Sc.Content = (Score1_+":"+Score2_).ToString();

            if (Score1_ > Score2_)
                DBAdapter.DB.RunInsert("Update [Stage] SET [Score1]='" + Score1_ + "', [Score2]='" + Score2_ + "', [win]='"+ cod1comand + "' where [ID_Stage] = '" + StageID_ + "'");
            else
                DBAdapter.DB.RunInsert("Update [Stage] SET [Score1]='" + Score1_ + "', [Score2]='" + Score2_ + "', [win]='" + cod2comand + "' where [ID_Stage] = '" + StageID_ + "'");


        }
        private void EditEvent_Click(object sender, RoutedEventArgs e)
        {
            int id_event = (int) (TableEvent.SelectedItem as DataRowView).Row[0];
            int Min = (int)(TableEvent.SelectedItem as DataRowView).Row[1];
            int SelTeam = (int)(TableEvent.SelectedItem as DataRowView).Row[2];
            string Event = (string)(TableEvent.SelectedItem as DataRowView).Row[3];
            string Info = (string)(TableEvent.SelectedItem as DataRowView).Row[4];
            
            DataTable Sel = DBAdapter.DB.RunSelect("Select TeamName from Teams where ID_Team='"+SelTeam+"'");
            string s = Sel.Rows[0].ItemArray[0].ToString();
            AddEditGameEvent addEditGameEvent = new AddEditGameEvent(StageID_, Team1, Team2, id_event, s, Min, Event, Info, Score1_, Score2_);

            addEditGameEvent.Show();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)//delete_event
        {
            if (TableEvent.SelectedCells.Count > 0)
            {
                MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить событие?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    int id_event = (int)(TableEvent.SelectedItem as DataRowView).Row[0];
                    var q = "Delete from [Events] where ID_Event ='" + id_event + "'";
                    DBAdapter.DB.RunInsert(q);
                    TableEvent.ItemsSource = DBAdapter.DB.RunSelect("SELECT ID_Event, Min, Team_ID, Event, AdditionalInformation from [Events] where Stage_ID ='" + StageID_ + "'").DefaultView;
                }
            }
            else
            {
                MessageBox.Show("Выберите строку, которую необходимо удалить!");
            }
        }
        public int StageID_; string Team1; string Team2; int Score1_; int Score2_;
        public void TableEvents(int StageId) {
            TableEvent.ItemsSource = DBAdapter.DB.RunSelect("SELECT ID_Event, Min, Team_ID, Event, AdditionalInformation from [Events] where Stage_ID ='"+StageId+"'").DefaultView;
          

        }

        private void Button_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
           
        }

        private void this_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
          
        }

        private void this_Activated(object sender, EventArgs e)
        {
            Result.Content = nameG;

            nG = nameG.Split('-');
            Grid.ItemsSource = DBAdapter.DB.RunSelect("SELECT ID_Player AS [ID], lastname AS [Lastname], firstname as[Firstname], position AS Position FROM [Players] inner join Teams on Players.team_id=Teams.ID_Team Where TeamName ='" + nG[0] + "'").DefaultView;
            //Grid.Columns[3].Visibility = Visibility.Hidden;
            Grid2.ItemsSource = DBAdapter.DB.RunSelect("SELECT ID_Player AS [ID], lastname AS [Lastname], firstname as[Firstname], position AS Position FROM [Players] inner join Teams on Players.team_id=Teams.ID_Team Where TeamName ='" + nG[1] + "'").DefaultView;
            //Grid2.Columns[3].Visibility = Visibility.Hidden;

            cod1comand = Convert.ToInt32(DBAdapter.DB.RunSelect(@"SELECT ID_Team
                                                      From Teams
                                                      Where TeamName = '" + nG[0] + "'").Rows[0][0]);
            cod2comand = Convert.ToInt32(DBAdapter.DB.RunSelect(@"SELECT ID_Team
                                                      From Teams
                                                      Where TeamName = '" + nG[1] + "'").Rows[0][0]);

            DataTable dt = DBAdapter.DB.RunSelect(@"SELECT *
                                                    From Stage
                                                    Where (Team1_ID = '" + cod1comand + "' and Team2_ID = '" + cod2comand + "')");
            if (dt.Rows.Count > 0)
            {
                Team1 = nG[0];
                Team2 = nG[1];
                TableEvents((int)dt.Rows[0].ItemArray[0]);
                StageID_ = (int)dt.Rows[0].ItemArray[0];

                Score1_ = (int)dt.Rows[0].ItemArray[3];
                Score2_ = (int)dt.Rows[0].ItemArray[4];
                Sc.Content = (Score1_ + ":" + Score2_).ToString();
            }
        }
    }
}
