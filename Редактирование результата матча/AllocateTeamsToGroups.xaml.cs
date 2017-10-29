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

        private void SaveCloseButton_Click(object sender, RoutedEventArgs e)
        {
            // 2017.10.29 Михаил. Метод передаёт в форму ManageExecution метку Yes, когда работа с текущей формой закончена
            ManageExecutionMenu main = this.Owner as ManageExecutionMenu;
            if (main != null)
            {
                main.label1.Content = "Yes";
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

    }
}
