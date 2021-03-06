﻿using System;
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
    /// Логика взаимодействия для ManageExecutionMenu.xaml
    /// </summary>
    public partial class ManageExecutionMenu : Window
    {
        public ManageExecutionMenu()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            AllocateTeamsToGroups _allocate = new AllocateTeamsToGroups();
            _allocate.Owner = this; 
            _allocate.ShowDialog();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ManageGroupStageResults _managegroup = new ManageGroupStageResults();
            _managegroup.Owner = this;
            _managegroup.ShowDialog();

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            ManageRoundOf16Games _manageround = new ManageRoundOf16Games();
            _manageround.Owner = this;
            _manageround.ShowDialog();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            ManageQuarterFinalGames _managequarter = new ManageQuarterFinalGames();
            _managequarter.Owner = this;
            _managequarter.ShowDialog();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            ManageSemiFinal _managesemi = new ManageSemiFinal();
            _managesemi.Owner = this;
            _managesemi.ShowDialog();
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            ManageFinal _managefinal = new ManageFinal();
            _managefinal.Owner = this;
            _managefinal.ShowDialog();
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable group = DBAdapter.DB.RunSelect("Select * from Stage where StageType_ID='1' OR  StageType_ID='2' OR  StageType_ID='3' OR  StageType_ID='4' OR  StageType_ID='5' OR  StageType_ID='6' AND  IsFinished='1'");
            DataTable ei = DBAdapter.DB.RunSelect("Select * from Stage where StageType_ID='8' and IsFinished='1'");

            DataTable qu = DBAdapter.DB.RunSelect("Select * from Stage where StageType_ID='10' and IsFinished='1'");
            DataTable quNot = DBAdapter.DB.RunSelect("Select * from Stage where StageType_ID='10' and IsFinished='0'");

            DataTable semi = DBAdapter.DB.RunSelect("Select * from Stage where StageType_ID='11' and IsFinished='1'");
            DataTable semiNot = DBAdapter.DB.RunSelect("Select * from Stage where StageType_ID='11' and IsFinished='0'");

            DataTable final = DBAdapter.DB.RunSelect("Select * from Stage where StageType_ID='12' and IsFinished='1'");
            DataTable finalNot = DBAdapter.DB.RunSelect("Select * from Stage where StageType_ID='12' and IsFinished='0'");


            if (group.Rows.Count == 36)
            {
                button1.IsEnabled = false;
                label3.Content = "YES";

            }
            if (ei.Rows.Count == 8)
            {
                button2.IsEnabled = false;
                label5.Content = "YES";

                if (quNot.Rows.Count == 0 && qu.Rows.Count == 0)
                {                    
                    DBAdapter.DB.RunInsert("Insert Into [Stage] (Team1_ID, Team2_ID,Score1,Score2, StageType_ID,Tournament_ID,  IsFinished) values('" + ei.Rows[0][8] + "','" + ei.Rows[1][8] + "','0','0','10','1','0')");
                    DBAdapter.DB.RunInsert("Insert Into [Stage] (Team1_ID, Team2_ID,Score1,Score2, StageType_ID,Tournament_ID,  IsFinished) values('" + ei.Rows[2][8] + "','" + ei.Rows[3][8] + "','0','0','10','1','0')");
                    DBAdapter.DB.RunInsert("Insert Into [Stage] (Team1_ID, Team2_ID,Score1,Score2, StageType_ID,Tournament_ID,  IsFinished) values('" + ei.Rows[4][8] + "','" + ei.Rows[5][8] + "','0','0','10','1','0')");
                    DBAdapter.DB.RunInsert("Insert Into [Stage] (Team1_ID, Team2_ID,Score1,Score2, StageType_ID,Tournament_ID,  IsFinished) values('" + ei.Rows[6][8] + "','" + ei.Rows[7][8] + "','0','0','10','1','0')");
                }
            }
            if (qu.Rows.Count == 4)
            {
                button3.IsEnabled = false;
                label4.Content = "YES";
                if (semiNot.Rows.Count == 0 && semi.Rows.Count == 0)
                {
                    DBAdapter.DB.RunInsert("Insert Into [Stage] (Team1_ID, Team2_ID,Score1,Score2, StageType_ID,Tournament_ID,  IsFinished) values('" + qu.Rows[0][8] + "','" + qu.Rows[1][8] + "','0','0','11','1','0')");
                    DBAdapter.DB.RunInsert("Insert Into [Stage] (Team1_ID, Team2_ID,Score1,Score2, StageType_ID,Tournament_ID,  IsFinished) values('" + qu.Rows[2][8] + "','" + qu.Rows[3][8] + "','0','0','11','1','0')");
                }
            }
            if (semi.Rows.Count == 2)
            {
                button4.IsEnabled = false;
                label6.Content = "YES";
                if (finalNot.Rows.Count == 0 && final.Rows.Count == 0)
                {
                    DBAdapter.DB.RunInsert("Insert Into [Stage] (Team1_ID, Team2_ID,Score1,Score2, StageType_ID,Tournament_ID,  IsFinished) values('" + semi.Rows[0][8] + "','" + semi.Rows[1][8] + "','0','0','11','1','0')");
                }
            }
            if (final.Rows.Count == 1)
            {
                button5.IsEnabled = false;
                label7.Content = "YES";

            }

        }

        private void Window_Activated(object sender, EventArgs e)
        {
            DataTable group = DBAdapter.DB.RunSelect("Select * from Stage where StageType_ID='1' OR  StageType_ID='2' OR  StageType_ID='3' OR  StageType_ID='4' OR  StageType_ID='5' OR  StageType_ID='6' AND  IsFinished='1'");
            DataTable ei = DBAdapter.DB.RunSelect("Select * from Stage where StageType_ID='8' and IsFinished='1'");

            DataTable qu = DBAdapter.DB.RunSelect("Select * from Stage where StageType_ID='10' and IsFinished='1'");
            DataTable quNot = DBAdapter.DB.RunSelect("Select * from Stage where StageType_ID='10' and IsFinished='0'");

            DataTable semi = DBAdapter.DB.RunSelect("Select * from Stage where StageType_ID='11' and IsFinished='1'");
            DataTable semiNot = DBAdapter.DB.RunSelect("Select * from Stage where StageType_ID='11' and IsFinished='0'");

            DataTable final = DBAdapter.DB.RunSelect("Select * from Stage where StageType_ID='12' and IsFinished='1'");
            DataTable finalNot = DBAdapter.DB.RunSelect("Select * from Stage where StageType_ID='12' and IsFinished='0'");


            if (group.Rows.Count == 36)
            {
                button1.IsEnabled = false;
                label3.Content = "YES";

            }
            if (ei.Rows.Count == 8)
            {
                button2.IsEnabled = false;
                label5.Content = "YES";

                if (quNot.Rows.Count == 0 && qu.Rows.Count == 0)
                {
                    DBAdapter.DB.RunInsert("Insert Into [Stage] (Team1_ID, Team2_ID,Score1,Score2, StageType_ID,Tournament_ID,  IsFinished) values('" + ei.Rows[0][8] + "','" + ei.Rows[1][8] + "','0','0','10','1','0')");
                    DBAdapter.DB.RunInsert("Insert Into [Stage] (Team1_ID, Team2_ID,Score1,Score2, StageType_ID,Tournament_ID,  IsFinished) values('" + ei.Rows[2][8] + "','" + ei.Rows[3][8] + "','0','0','10','1','0')");
                    DBAdapter.DB.RunInsert("Insert Into [Stage] (Team1_ID, Team2_ID,Score1,Score2, StageType_ID,Tournament_ID,  IsFinished) values('" + ei.Rows[4][8] + "','" + ei.Rows[5][8] + "','0','0','10','1','0')");
                    DBAdapter.DB.RunInsert("Insert Into [Stage] (Team1_ID, Team2_ID,Score1,Score2, StageType_ID,Tournament_ID,  IsFinished) values('" + ei.Rows[6][8] + "','" + ei.Rows[7][8] + "','0','0','10','1','0')");
                }
            }
            if (qu.Rows.Count == 4)
            {
                button3.IsEnabled = false;
                label4.Content = "YES";
                if (semiNot.Rows.Count == 0 && semi.Rows.Count == 0)
                {
                    DBAdapter.DB.RunInsert("Insert Into [Stage] (Team1_ID, Team2_ID,Score1,Score2, StageType_ID,Tournament_ID,  IsFinished) values('" + qu.Rows[0][8] + "','" + qu.Rows[1][8] + "','0','0','11','1','0')");
                    DBAdapter.DB.RunInsert("Insert Into [Stage] (Team1_ID, Team2_ID,Score1,Score2, StageType_ID,Tournament_ID,  IsFinished) values('" + qu.Rows[2][8] + "','" + qu.Rows[3][8] + "','0','0','11','1','0')");
                }
            }
            if (semi.Rows.Count == 2)
            {
                button4.IsEnabled = false;
                label6.Content = "YES";
                if (finalNot.Rows.Count == 0 && final.Rows.Count == 0)
                {
                    DBAdapter.DB.RunInsert("Insert Into [Stage] (Team1_ID, Team2_ID,Score1,Score2, StageType_ID,Tournament_ID,  IsFinished) values('" + semi.Rows[0][8] + "','" + semi.Rows[1][8] + "','0','0','12','1','0')");
                }
            }
            if (final.Rows.Count == 1)
            {
                button5.IsEnabled = false;
                label7.Content = "YES";

            }
        }
    }
}
