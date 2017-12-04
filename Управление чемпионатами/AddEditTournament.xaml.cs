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

    public partial class AddEditTournament : Window
    {
        int tournamentID;
        List<TeamParticipant> participants;
        public int TournamentID
        {
            get { return tournamentID; }
            set { tournamentID = value; }
        }

        public AddEditTournament()
        {
            InitializeComponent();
            LoadParticipants();
        }
        public AddEditTournament(DataRowView dataGridRow)
        {
            InitializeComponent();
            FillFields(dataGridRow);
        }

        /// <summary>
        /// Фильтрует записи по выбранному региону.
        /// </summary>
        /// <param name="region">Регион</param>
        void FilterByRegion(string region)//Заменить на фильтрацию
        {
            //countriesSelectionTable.ItemsSource = DB.RunSelect("select ID_Team,TeamName from Teams where Region ='" + region + "'").DefaultView;
        }

        /// <summary>
        /// Заполняет поля формы на основании выбранной строки списка чемпионатов.
        /// </summary>
        /// <param name="tournament"></param>
        internal void FillFields(DataRowView tournament)
        {

            tournamentID = (int)tournament.Row["ID_Tournament"];
            tournamentNameText.Text = (string)tournament.Row["TournamentName"];
            startDate.SelectedDate = (DateTime)tournament.Row["Start_Date"];
            endDate.SelectedDate = (DateTime)tournament.Row["End_Date"];
            LoadParticipants();
        }


        /// <summary>
        /// Заполняет таблицу участников.
        /// </summary>
        /// <param name="tournament"></param>
        void LoadParticipants()
        {
            participants = new List<TeamParticipant>();
            DataTable teams = DB.RunSelect(@"select
                ID_Team,
                TeamName,
                countrycode,
                region,
                Tournament_ID from Teams left join
                (select * from TeamsInTournaments where Tournament_ID = " + tournamentID +
                ") as temp on ID_Team = Team_ID");

            //Блок, в котором реализовано отображение того, участвует команда в чемпионате или нет
            foreach (DataRow team in teams.Rows)
            {
                bool participates = false;
                if (team["Tournament_ID"] == DBNull.Value)
                    participates = false;
                else
                    participates = true;

                participants.Add(new TeamParticipant((int)team["ID_Team"], (string)team["TeamName"], participates));
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

        //Фильтрация
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            string region = (sender as RadioButton).Content.ToString();
            if (region == "All")
            {
                //
            }
            else if (region == "others")
            {
                //
            }
            else
            {
                //
            }
        }
        private void saveAndCloseButton_Click(object sender, RoutedEventArgs e)
        {
            if (tournamentNameText.Text == "")
            {
                return;
            }
            else
            {
                DB.RunInsert("Update Tournaments set TournamentName='" +
                        tournamentNameText.Text +
                        "', Start_date= '" +
                        startDate.SelectedDate.Value.ToString("yyyy-MM-dd") + "', End_Date = '" +
                        endDate.SelectedDate.Value.ToString("yyyy-MM-dd") + "' where Id_Tournament=" +
                        tournamentID);
                DB.RunInsert("Delete from TeamsInTournaments where Tournament_ID=" + tournamentID);


                string insertCommand = "insert into TeamsInTournaments values ";

                int insertedCounter = 0;
                int ammountToInsert = 0;

                foreach (TeamParticipant team in participants)
                {
                    if (team.Participates)
                    {
                        ammountToInsert++;
                    }
                }

                if (ammountToInsert != 0)
                {
                    foreach (TeamParticipant team in participants)
                    {
                        if (team.Participates)
                        {
                            insertCommand += "(" + tournamentID + "," + team.Id + ")";
                            if (insertedCounter != ammountToInsert - 1)
                                insertCommand += ",";

                            insertedCounter++;
                        }

                    }

                    DB.RunInsert(insertCommand);
                }
            }
        }
        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
