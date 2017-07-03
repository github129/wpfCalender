// <copyright file="SomeCalenderWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
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
    using Calender.Entitey;

    /// <summary>
    /// SomeCalenderWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class SomeCalenderWindow : Window
    {
        /// <summary>
        /// SomeCalenderWindowViewModelクラス
        /// </summary>
        private SomeCalenderWindowViewModel vm = new SomeCalenderWindowViewModel();

        /// <summary>
        /// オプションクラス
        /// </summary>
        private Option op = new Option();

        /// <summary>
        /// カレンダーデータクラス
        /// </summary>
        private CalenderData data = new CalenderData();

        /// <summary>
        /// SomeCalenderWindowViewModelクラスが入ったリスト
        /// </summary>
        private IList<SomeCalenderWindowViewModel> calender = new ObservableCollection<SomeCalenderWindowViewModel>();

        /// <summary>
        /// Initializes a new instance of the <see cref="SomeCalenderWindow"/> class.
        /// 初期化処理
        /// </summary>
        public SomeCalenderWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// カレンダーの情報をDateContextに入れる処理
        /// </summary>
        /// <param name="date">年月日</param>
        /// <param name="n">個数</param>
        /// <param name="nFlg">個数を入力しているかどうかのフラグ</param>
        public void SomeCalenderControl(DateTime date, int n, bool nFlg)
        {
            this.op.CalenderCreateCount = n;
            this.op.InputCreateountFlg = nFlg;
            this.data.InputDate = date;
            this.data.UpDataDate = date;
            if (nFlg)
            {
                date = date.AddMonths(-1);
            }

            this.data.Date = date;
            this.vm.CalenderEntitysNew(this.data, this.op);
            this.DataContext = this.vm;
        }

        /// <summary>
        /// 前年に戻るイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">イベント情報</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.vm.BackYearCount--;
            this.vm.NextYearCount++;
            this.data.UpDataDate = this.data.UpDataDate.AddYears(-1);
            this.vm.ChangeFilter(this.data);
        }

        /// <summary>
        /// 来年に進むイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">イベント情報</param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.vm.BackYearCount++;
            this.vm.NextYearCount--;
            this.data.UpDataDate = this.data.UpDataDate.AddYears(1);
            this.vm.ChangeFilter(this.data);
        }

        /// <summary>
        /// 始まりの曜日を変えるイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">イベント情報</param>
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)this.weekChangeCheck.IsChecked)
            {
                this.op.DatePriontChangeFlg = false;
            }
            else
            {
                this.op.DatePriontChangeFlg = true;
            }
            this.data.Date = this.data.InputDate.AddMonths(-1);
            ((SomeCalenderWindowViewModel)this.DataContext).UpdataCalender(this.data, this.op);
        }

        /// <summary>
        /// 当日のカラーを変更するイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">イベント情報</param>
        private void TodayColorChange_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)this.TodayColorChange.IsChecked)
            {
                this.op.TodayColorChangeFlg = false;
            }
            else
            {
                this.op.TodayColorChangeFlg = true;
            }
            this.data.Date = this.data.InputDate.AddMonths(-1);
            ((SomeCalenderWindowViewModel)this.DataContext).UpdataCalender(this.data, this.op);
        }
    }
}