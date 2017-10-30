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
using System.Collections.ObjectModel;

namespace Football
{ 

    /// <summary>
    /// Логика взаимодействия для AllocateTeamsToGroups.xaml
    /// </summary>
    public partial class AllocateTeamsToGroups : Window
    { 
        
    public AllocateTeamsToGroups()
        {
            InitializeComponent();
        }

        List<string> masA = new List<string>();

        private void SaveCloseButton_Click(object sender, RoutedEventArgs e)
        {
            if (masA.Count == 24)
            {
                DBAdapter.DB.RunInsert("delete from [Groups] ");

                DBAdapter.DB.RunInsert("Insert Into [Groups] (A, B, C, D, E,F) values('" + masA[0] + "','" + masA[4] + "','" + masA[8] + "','" + masA[12] + "','" + masA[16] + "','" + masA[20] + "')");
                DBAdapter.DB.RunInsert("Insert Into [Groups] (A, B, C, D, E,F) values('" + masA[1] + "','" + masA[5] + "','" + masA[9] + "','" + masA[13] + "','" + masA[17] + "','" + masA[21] + "')");
                DBAdapter.DB.RunInsert("Insert Into [Groups] (A, B, C, D, E,F) values('" + masA[2] + "','" + masA[6] + "','" + masA[10] + "','" + masA[14] + "','" + masA[18] + "','" + masA[22] + "')");
                DBAdapter.DB.RunInsert("Insert Into [Groups] (A, B, C, D, E,F) values('" + masA[3] + "','" + masA[7] + "','" + masA[11] + "','" + masA[15] + "','" + masA[19] + "','" + masA[23] + "')");
            }

            // 2017.10.29 Михаил. Метод передаёт в форму ManageExecution метку Yes, когда работа с текущей формой закончена
            ManageExecutionMenu main = this.Owner as ManageExecutionMenu;
            if (main != null)
            {
                main.label1.Content = "Yes";
            }
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < DBAdapter.DB.RunSelect("Select TeamName From [Teams] ").Rows.Count; i++)
            TeamsListBox.Items.Add(DBAdapter.DB.RunSelect("Select TeamName From [Teams] ORDER BY TeamName").Rows[i][0].ToString());

            DataTable dt = DBAdapter.DB.RunSelect("Select * From [Groups] ");

            ObservableCollection<ItemN> coll1 = new ObservableCollection<ItemN>();
            ObservableCollection<ItemN> coll2 = new ObservableCollection<ItemN>();
            ObservableCollection<ItemN> coll3 = new ObservableCollection<ItemN>();
            ObservableCollection<ItemN> coll4 = new ObservableCollection<ItemN>();
            ObservableCollection<ItemN> coll5 = new ObservableCollection<ItemN>();
            ObservableCollection<ItemN> coll6 = new ObservableCollection<ItemN>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                coll1.Add(new ItemN() { ShortName = DBAdapter.DB.RunSelect("Select TeamName From [Teams] where [ID_Team] =  '" + dt.Rows[i][1] + "' ").Rows[0][0].ToString(), Team = DBAdapter.DB.RunSelect("Select countrycode From [Teams] where [ID_Team] =  '" + dt.Rows[i][1] + "' ").Rows[0][0].ToString() });
                coll2.Add(new ItemN() { ShortName = DBAdapter.DB.RunSelect("Select TeamName From [Teams] where [ID_Team] =  '" + dt.Rows[i][2] + "' ").Rows[0][0].ToString(), Team = DBAdapter.DB.RunSelect("Select countrycode From [Teams] where [ID_Team] =  '" + dt.Rows[i][2] + "' ").Rows[0][0].ToString() });
                coll3.Add(new ItemN() { ShortName = DBAdapter.DB.RunSelect("Select TeamName From [Teams] where [ID_Team] =  '" + dt.Rows[i][3] + "' ").Rows[0][0].ToString(), Team = DBAdapter.DB.RunSelect("Select countrycode From [Teams] where [ID_Team] =  '" + dt.Rows[i][3] + "' ").Rows[0][0].ToString() });
                coll4.Add(new ItemN() { ShortName = DBAdapter.DB.RunSelect("Select TeamName From [Teams] where [ID_Team] =  '" + dt.Rows[i][4] + "' ").Rows[0][0].ToString(), Team = DBAdapter.DB.RunSelect("Select countrycode From [Teams] where [ID_Team] =  '" + dt.Rows[i][4] + "' ").Rows[0][0].ToString() });
                coll5.Add(new ItemN() { ShortName = DBAdapter.DB.RunSelect("Select TeamName From [Teams] where [ID_Team] =  '" + dt.Rows[i][5] + "' ").Rows[0][0].ToString(), Team = DBAdapter.DB.RunSelect("Select countrycode From [Teams] where [ID_Team] =  '" + dt.Rows[i][5] + "' ").Rows[0][0].ToString() });
                coll6.Add(new ItemN() { ShortName = DBAdapter.DB.RunSelect("Select TeamName From [Teams] where [ID_Team] =  '" + dt.Rows[i][6] + "' ").Rows[0][0].ToString(), Team = DBAdapter.DB.RunSelect("Select countrycode From [Teams] where [ID_Team] =  '" + dt.Rows[i][6] + "' ").Rows[0][0].ToString() });
            }
            GroupADataGrid.ItemsSource = coll1;
            GroupBDataGrid.ItemsSource = coll2;
            GroupCDataGrid.ItemsSource = coll3;
            GroupDDataGrid.ItemsSource = coll4;
            GroupEDataGrid.ItemsSource = coll5;
            GroupFDataGrid.ItemsSource = coll6;

            GroupADataGrid.Items.Refresh();
        }

        private class ItemN
        {
            public string ShortName { get; set; }
            public string Team { get; set; }

        }

        

        private void AllocateButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> mas1 = new List<string>();// string[DBAdapter.DB.RunSelect("Select TeamName From [Teams] ").Rows.Count];
            List<string> mas2 = new List<string>();// string[DBAdapter.DB.RunSelect("Select TeamName From [Teams] ").Rows.Count];
            List<string> mas3 = new List<string>();// string[DBAdapter.DB.RunSelect("Select TeamName From [Teams] ").Rows.Count];

            for (int i = 0; i < DBAdapter.DB.RunSelect("Select TeamName From [Teams] ").Rows.Count; i++)
                mas1.Add(DBAdapter.DB.RunSelect("Select TeamName, countrycode From [Teams] ORDER BY TeamName").Rows[i][0].ToString());

            for (int i = 0; i < DBAdapter.DB.RunSelect("Select TeamName From [Teams] ").Rows.Count; i++)
                mas2.Add(DBAdapter.DB.RunSelect("Select TeamName, countrycode From [Teams] ORDER BY TeamName").Rows[i][1].ToString());
            for (int i = 0; i < DBAdapter.DB.RunSelect("Select TeamName From [Teams] ").Rows.Count; i++)
                mas3.Add(DBAdapter.DB.RunSelect("Select [ID_Team], countrycode From [Teams] ORDER BY TeamName").Rows[i][0].ToString());

            Random r = new Random();

            ObservableCollection<ItemN> coll = new ObservableCollection<ItemN>();
            for (int i = 0; i < 4; i++)
            {
                int r1 = r.Next(0, mas1.Count);
                coll.Add(new ItemN() {  ShortName = mas1[r1], Team = mas2[r1] });
                mas1.RemoveAt(r1);
                mas2.RemoveAt(r1);
                masA.Add(mas3[r1]);
                mas3.RemoveAt(r1);
            }
            GroupADataGrid.ItemsSource = coll;
            GroupADataGrid.Items.Refresh();

            coll = new ObservableCollection<ItemN>();
            for (int i = 0; i < 4; i++)
            {
                int r1 = r.Next(0, mas1.Count);
                coll.Add(new ItemN() { ShortName = mas1[r1], Team = mas2[r1] });
                mas1.RemoveAt(r1);
                mas2.RemoveAt(r1);
                masA.Add(mas3[r1]);
                mas3.RemoveAt(r1);
            }
            GroupBDataGrid.ItemsSource = coll;
            GroupBDataGrid.Items.Refresh();

            coll = new ObservableCollection<ItemN>();
            for (int i = 0; i < 4; i++)
            {
                int r1 = r.Next(0, mas1.Count);
                coll.Add(new ItemN() { ShortName = mas1[r1], Team = mas2[r1] });
                mas1.RemoveAt(r1);
                mas2.RemoveAt(r1);
                masA.Add(mas3[r1]);
                mas3.RemoveAt(r1);
            }
            GroupCDataGrid.ItemsSource = coll;
            GroupCDataGrid.Items.Refresh();

            coll = new ObservableCollection<ItemN>();
            for (int i = 0; i < 4; i++)
            {
                int r1 = r.Next(0, mas1.Count);
                coll.Add(new ItemN() { ShortName = mas1[r1], Team = mas2[r1] });
                mas1.RemoveAt(r1);
                mas2.RemoveAt(r1);
                masA.Add(mas3[r1]);
                mas3.RemoveAt(r1);
            }
            GroupDDataGrid.ItemsSource = coll;
            GroupDDataGrid.Items.Refresh();

            coll = new ObservableCollection<ItemN>();
            for (int i = 0; i < 4; i++)
            {
                int r1 = r.Next(0, mas1.Count);
                coll.Add(new ItemN() { ShortName = mas1[r1], Team = mas2[r1] });
                mas1.RemoveAt(r1);
                mas2.RemoveAt(r1);
                masA.Add(mas3[r1]);
                mas3.RemoveAt(r1);
            }
            GroupEDataGrid.ItemsSource = coll;
            GroupEDataGrid.Items.Refresh();

            coll = new ObservableCollection<ItemN>();
            for (int i = 0; i < 4; i++)
            {
                int r1 = r.Next(0, mas1.Count);
                coll.Add(new ItemN() { ShortName = mas1[r1], Team = mas2[r1] });
                mas1.RemoveAt(r1);
                mas2.RemoveAt(r1);
                masA.Add(mas3[r1]);
                mas3.RemoveAt(r1);
            }
            GroupFDataGrid.ItemsSource = coll;
            GroupFDataGrid.Items.Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
