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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Successor_001_to_Vahren
{
    /// <summary>
    /// Page005_StrategyMenu.xaml の相互作用ロジック
    /// </summary>
    public partial class Page005_StrategyMenu : Page
    {
        public Page005_StrategyMenu()
        {
            InitializeComponent();
        }

        public void SetData()
        {
            var window = Application.Current.Properties["window"];
            if (window == null)
            {
                return;
            }
            var mainWindow = window as MainWindow;
            if (mainWindow == null)
            {
                return;
            }

            DisplayPowerStatus(mainWindow);
        }

        public void DisplayPowerStatus(MainWindow mainWindow)
        {
            //旗
            {
                List<string> strings = new List<string>();
                strings.Add(mainWindow.ClassConfigGameTitle.DirectoryGameTitle[mainWindow.NowNumberGameTitle].FullName);
                strings.Add("030_FlagImage");
                strings.Add(mainWindow.ClassGameStatus.SelectionPowerAndCity.ClassPower.FlagPath);
                string path = System.IO.Path.Combine(strings.ToArray());
                BitmapImage bitimg1 = new BitmapImage(new Uri(path));
                this.imgFlag.Source = bitimg1;
            }
            //勢力名
            {
                this.lblNamePower.Content = mainWindow.ClassGameStatus.SelectionPowerAndCity.ClassPower.Name;
            }
            //顔グラ
            {
                var ima = mainWindow.ClassGameStatus.ListUnit
                    .Where(x => x.NameTag == mainWindow.ClassGameStatus.SelectionPowerAndCity.ClassPower.MasterTag)
                    .FirstOrDefault();
                if (ima != null)
                {
                    List<string> strings = new List<string>();
                    strings.Add(mainWindow.ClassConfigGameTitle.DirectoryGameTitle[mainWindow.NowNumberGameTitle].FullName);
                    strings.Add("010_FaceImage");
                    strings.Add(ima.Face);
                    string path = System.IO.Path.Combine(strings.ToArray());
                    BitmapImage bitimg1 = new BitmapImage(new Uri(path));
                    this.imgFace.Source = bitimg1;
                }
            }

            //軍資金
            {
                this.lblNameMoney.Content = mainWindow.ClassGameStatus.SelectionPowerAndCity.ClassPower.Money;
            }
            //総収入
            {
                this.lblNameTotalIncome.Content = "";
            }
            //収入補正
            {
                this.lblNameIncomeCorrection.Content = "";
            }
            //領土数
            {
                this.lblNameNumberSpot.Content = "";
            }
            //ユニット数
            {
                this.lblNameNumberUnit.Content = "";
            }
            //維持費
            {
                this.lblNameMaintenanceCosts.Content = "";
            }
            //財政値
            {
                this.lblNameNumberFinance.Content = "";
            }
            //訓練値
            {
                this.lblNameNumberTraining.Content = "";
            }
            //影響力
            {
                this.lblNameInfluence.Content = "";
            }
        }

        private void btnTurnEnd_Click(object sender, RoutedEventArgs e)
        {
            var window = Application.Current.Properties["window"];
            if (window == null)
            {
                return;
            }
            var mainWindow = window as MainWindow;
            if (mainWindow == null)
            {
                return;
            }

            //ターン終了時処理

            //ターン加算

            //ターン開始時処理
            mainWindow.ExecuteEvent();
        }
    }
}
