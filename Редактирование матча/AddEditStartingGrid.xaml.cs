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
    /// Логика взаимодействия для addedit_to_startinggrid.xaml
    /// </summary>
    public partial class AddEditToStartingGrid : Window
    {
        public AddEditToStartingGrid()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = DBAdapter.DB.RunSelect("SELECT Team1_ID, Team2_ID, Score1, Score2, Tournament_ID FROM Stage WHERE StageType_ID = 8");
            //dt.DataSet.Tables[0];
        }
    }
}
