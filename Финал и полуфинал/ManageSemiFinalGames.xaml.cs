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

        private void Finish_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = DBAdapter.DB.RunSelect("Select Team1_ID, Team2_ID, Score1, Score2 From Stage Where StageType_ID = 11");
            Country1.Content = dt.DataSet.Tables[0].Rows[0].ItemArray[0];
            Country2.Content = dt.DataSet.Tables[0].Rows[0].ItemArray[1];
            Point1.Content = dt.DataSet.Tables[0].Rows[0].ItemArray[2];
            Point2.Content = dt.DataSet.Tables[0].Rows[0].ItemArray[3];

            Country3.Content = dt.DataSet.Tables[0].Rows[1].ItemArray[0];
            Country4.Content = dt.DataSet.Tables[0].Rows[1].ItemArray[1];
            Point3.Content = dt.DataSet.Tables[0].Rows[1].ItemArray[2];
            Point4.Content = dt.DataSet.Tables[0].Rows[1].ItemArray[3];
        }
    }
}
