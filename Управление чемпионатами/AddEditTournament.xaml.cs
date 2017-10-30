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
    /// Логика взаимодействия для AddEditTournament.xaml
    /// </summary>
    /// 
    public class TeamParticipant
    {
        int id;
        string name;
        bool participates;

        public TeamParticipant(int id, string name, bool participates)
        {
            this.Id = id;
            this.Name = name;
            this.Participates = participates;
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public bool Participates
        {
            get { return participates; }
            set { participates = value; }
        }
    }

        public partial class AddEditTournament : Window
        {
            int tournamentID;
            List<TeamParticipant> participants;

            public AddEditTournament()
            {
                InitializeComponent();
                InitializeTable();
                LoadAllTeams();
            }

            public int TournamentID
            {
                get { return tournamentID; }
                set { tournamentID = value; }
            }

            public AddEditTournament(DataGridRow dataGridRow)
            {
                InitializeComponent();
            }

            void InitializeTable()
            {
                //DataTable dt = DB.RunSelect("select ID_Team, TeamName from Teams");

                //DataGridTextColumn newColumn = new DataGridTextColumn();
                //newColumn.Binding = new Binding("Id");
                //newColumn.Visibility = Visibility.Hidden;
                //countriesSelectionTable.Columns.Add(newColumn);

                //newColumn = new DataGridTextColumn();
                //newColumn.Binding = new Binding("Name");
                //newColumn.Header = "Team";
                //countriesSelectionTable.Columns.Add(newColumn);

                //DataGridCheckBoxColumn checkboxColumn = new DataGridCheckBoxColumn();
                //checkboxColumn.Header = "Participates";
                //newColumn.Binding = new Binding("Participates");
            }
            void UpdateTable()
            {
                countriesSelectionTable.ItemsSource = DB.RunSelect("select ID_Team,TeamName from Teams").DefaultView;
            }

            void FilterByRegion(string region)//Заменить на фильтрацию
            {
                //countriesSelectionTable.ItemsSource = DB.RunSelect("select ID_Team,TeamName from Teams where Region ='" + region + "'").DefaultView;
            }

            internal void FillFields(DataRowView tournament)
            {
                tournamentID = (int)tournament.Row["ID_Tournament"];
                tournamentNameText.Text = (string)tournament.Row["TournamentName"];
                startDate.SelectedDate = (DateTime)tournament.Row["Start_Date"];
                endDate.SelectedDate = (DateTime)tournament.Row["End_Date"];
                LoadParticipatingTeams();
            }
            void LoadAllTeams()
            {
                participants = new List<TeamParticipant>();
                DataTable teams = DB.RunSelect("select * from Teams");
                foreach (DataRow team in teams.Rows)
                {
                    participants.Add(new TeamParticipant((int)team["ID_Team"], (string)team["TeamName"], false));
                }
                countriesSelectionTable.ItemsSource = participants;
            }
            void MarkParticipatingTeams()
            {

            }
            void LoadParticipatingTeams()
            {
                DataTable teams = DB.RunSelect("select * from Teams");
                DataTable partis = DB.RunSelect("select * from teams where ID_Team in (select Team_ID from TeamsInTournaments where Tournament_ID = " + tournamentID + ")");
                int particCount = partis.Rows.Count;
                participants = new List<TeamParticipant>();
                foreach (DataRow team in teams.Rows)
                {
                    participants.Add(new TeamParticipant((int)team["ID_Team"], (string)team["TeamName"], false));
                }

                if (particCount != 0)
                {
                    foreach (TeamParticipant team in participants)
                    {
                        foreach (DataRow dr in partis.Rows)
                            if (team.Id == (int)dr["ID_Team"])
                            {
                                team.Participates = true;
                            }
                    }
                }

                countriesSelectionTable.ItemsSource = participants;
            }
            bool CheckIfFieldsAreFilled()
            {
                if (tournamentNameText.Text == null || startDate.SelectedDate == null || endDate.SelectedDate == null)
                    return false;
                else
                    return true;
            }

            private void RadioButton_Checked(object sender, RoutedEventArgs e)
            {
                string region = (sender as RadioButton).Content.ToString();
                if (region == "All")
                {
                    UpdateTable();
                }
                else if (region == "others")
                {
                    countriesSelectionTable.ItemsSource = DB.RunSelect("select * from teams where region NOT in ('Africa','America','Europe','Asia')").DefaultView;
                }
                else
                {
                    FilterByRegion(region);
                }
            }
            private void countriesSelectionTable_Loaded(object sender, RoutedEventArgs e)
            {
                if (Owner is ManageTournaments)
                {
                    //DataGridRow dr = (Owner as ManageTournaments).
                }
            }
            private void saveAndCloseButton_Click(object sender, RoutedEventArgs e)
            {
                if (Owner is ManageTournaments)
                {
                    if (CheckIfFieldsAreFilled())
                    {
                        DB.RunInsert("Update Tournaments set (TournamentName='" +
                            tournamentNameText.Text +
                            "', Start_date= '" +
                            startDate.SelectedDate.Value.ToString("yyyy-MM-dd") + "', End_Date = '" +
                            endDate.SelectedDate.Value.ToString("yyyy-MM-dd") + "') where Id_Tournament=" +
                            tournamentID);

                        ManageTournaments manageTournaments = Owner as ManageTournaments;
                    }
                    else
                    {
                        DB.RunInsert("Insert into Tournaments values ('" +
                            tournamentNameText.Text + "','" +
                            startDate.SelectedDate.Value.ToString("yyyy-MM-dd") + "','" +
                            endDate.SelectedDate.Value.ToString("yyyy-MM-dd") + "')");
                        tournamentID = (int)DB.RunSelect("Select top 1 ID_Tournament from Tournaments order by ID_Tournament Desc").Rows[0][0];
                        Owner.Focus();

                        string command = "Insert into TeamsInTournaments values ";

                        int indexer = 0;
                        foreach (TeamParticipant team in participants)
                        {
                            if (team.Participates)
                            {
                                command += "('" +
                                    tournamentID + "','" +
                                    team.Id +
                                    "')";

                                if (indexer != participants.Count - 1)
                                {
                                    command += ",";
                                }
                            }
                            indexer++;
                        }
                        DB.RunInsert(command);

                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Заполните все поля!");
                }
            }
            private void closeButton_Click(object sender, RoutedEventArgs e)
            {
                Close();
            }
        }
    }
