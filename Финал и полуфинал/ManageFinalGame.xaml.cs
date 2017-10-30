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
            DataTable dt = DBAdapter.DB.RunSelect("Select Team1_ID, Team2_ID, Score1, Score2 From Stage Where StageType_ID = 12");
            Country1.Content = dt.DataSet.Tables[0].Rows[0].ItemArray[0];
            Country2.Content = dt.DataSet.Tables[0].Rows[0].ItemArray[1];
            Point1.Content = dt.DataSet.Tables[0].Rows[0].ItemArray[2];
            Point2.Content = dt.DataSet.Tables[0].Rows[0].ItemArray[3];

        }
    }
}
