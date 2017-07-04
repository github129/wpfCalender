// <copyright file="CalenderWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WpfApp1
{
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
    using Calender.Entitey;

    /// <summary>
    /// CalenderWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class CalenderWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CalenderWindow"/> class.
        /// 初期化
        /// </summary>
        public CalenderWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// カレンダーデータクラス
        /// </summary>
        private CalenderData data = new CalenderData();

        /// <summary>
        /// オプションクラス
        /// </summary>
        private Option op = new Option();

        /// <summary>
        /// Gets データクラス用のプロパティ
        /// </summary>
        public CalenderData Data
        {
            get { return this.data; }
            private set { this.data = value; }
        }

        /// <summary>
        /// Gets オプションクラス用のプロパティ
        /// </summary>
        public Option Op
        {
            get { return this.op; }
            private set { this.op = value; }
        }

        /// <summary>
        /// 実行メソッド
        /// </summary>
        /// <param name="date">日付</param>
        public void UserContorol(DateTime date)
        {
            this.Data.Date = date;
            var option = new Option();
            var calVm = new CalenderWindowViewModel();
            calVm.SetOneCalender(this.Data, option);
            this.DataContext = calVm;
        }

        /// <summary>
        /// 曜日の始まり選択クリック時の処理
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">イベントデータ</param>
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)this.weekChangeCheck.IsChecked)
            {
                this.Op.DatePrintChangeFlg = false;
            }
            else
            {
                this.Op.DatePrintChangeFlg = true;
            }

            ((CalenderWindowViewModel)this.DataContext).Data.CalenderDays.Clear();
            ((CalenderWindowViewModel)this.DataContext).SetOneCalender(this.Data, this.Op);
        }

        /// <summary>
        /// 当日の背景色洗濯時の処理
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">イベントデータ</param>
        private void TodayColorChange_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)this.TodayColorChange.IsChecked)
            {
                this.Op.TodayColorChangeFlg = false;
            }
            else
            {
                this.Op.TodayColorChangeFlg = true;
            }

            ((CalenderWindowViewModel)this.DataContext).Data.CalenderDays.Clear();
            ((CalenderWindowViewModel)this.DataContext).SetOneCalender(this.Data, this.Op);
        }
    }
}
