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
    /// Логика взаимодействия для addedit_game_event.xaml
    /// </summary>
    public partial class AddEditGameEvent : Window
    {
        int StageID_; string Team1_; string Team2_; int IDEvent_=0; int Minute_; string Event_; string AdditionalInfo_; int Score1_; int Score2_;
        public AddEditGameEvent(int StageID, string T1, string T2)
        {
            InitializeComponent();
             StageID_ = StageID;
             Team1_ = T1;
             Team2_ = T2;
        }
        public AddEditGameEvent(int StageID, string T1, string T2, int id_Event, string SelectionTeam, int Min, string Event, string Info, int sc1, int sc2)
        {
            InitializeComponent();
            StageID_ = StageID;
            Team1_ = T1;
            Team2_ = T2;
            IDEvent_ = id_Event;
            Minute_ = Min;
            Event_ = Event;
            AdditionalInfo_ = Info;
            Score1_=sc1;
            Score2_=sc2;
            if (Team1_ == SelectionTeam) { Team1.IsChecked = true; }
            else if (Team2_ == SelectionTeam) { Team2.IsChecked = true; }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Team1.Content = Team1_;
            Team2.Content = Team2_;
            if (IDEvent_ == 0)
            {
                Additional.Text = ""; Minute.Text = "";
                Team1.IsChecked = true;
            }
            else
            {
                Additional.Text = AdditionalInfo_;
                Minute.Text = Minute_.ToString();
                
            }
            List<string> events_ = new List<string>() { "Goal", "Foul", "Free kick", "Corner", "Penalty", "Substitute", "Yellow Card", "Red Card" };

            for (int i = 0; i <= events_.Count-1; i++)
            {
                ListEvent.Items.Add(events_[i]);
                if (Event_ == events_[i])
                {
                    ListEvent.SelectedValue = Event_;
                }
            }

        }
        public bool Valid()
        {
            if (Minute.Text != "" && ListEvent.Text != "" && Additional.Text != "")
                return true;
            else return false;
        }
        private void OK(object sender, RoutedEventArgs e)
        {
            if (Valid())
            {
                Minute_ = int.Parse(Minute.Text);
                string SelectedTeam = "";
                if (Team1.IsChecked == true)
                {
                    SelectedTeam = Team1.Content.ToString();
                }
                else if (Team2.IsChecked == true)
                {
                    SelectedTeam = Team2.Content.ToString();
                }
                else
                {
                    MessageBox.Show("Выберите команду!");
                }
                Event_ = ListEvent.Text;
                AdditionalInfo_ = Additional.Text;
                DataTable Sel = DBAdapter.DB.RunSelect("Select ID_Team from Teams where TeamName='" + SelectedTeam + "'");
                int selectedTeam = int.Parse(Sel.Rows[0].ItemArray[0].ToString());
                if(Event_ == "Goal")
                {
                    if(SelectedTeam==Team1_)
                    {
                        Score1_++;
                    }
                    else 
                    {
                        Score2_++;
                    }
                }
                EditGameStartingGrid editGameStartingGrid = new EditGameStartingGrid();
                if (IDEvent_ != 0)
                {
                   DBAdapter.DB.RunInsert("Update [Events] SET [Min] = '"+Minute_+"', [Team_ID] = '"+selectedTeam+"', [Event] = '"+Event_+"', [AdditionalInformation] = '"+AdditionalInfo_+"' where [ID_Event] = '"+IDEvent_+"'");
                   
                    editGameStartingGrid.Refresh(Score1_, Score2_,StageID_);
                }
                else//add
                {
                    DBAdapter.DB.RunInsert("Insert Into [Events] (Stage_ID, Min, Team_ID,  Event, AdditionalInformation) values('" + StageID_ + "','" + Minute_ + "','" + selectedTeam + "','" + Event_ + "','" + AdditionalInfo_ + "')");
                    editGameStartingGrid.Refresh(Score1_, Score2_,StageID_);
                }
                Close();
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
        }

        private void cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       
    }
}
