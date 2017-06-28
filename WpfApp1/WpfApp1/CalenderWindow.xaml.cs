﻿namespace WpfApp1
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

        private CalenderData data = new CalenderData();

        private Option op = new Option();

        public CalenderData Data
        {
            get { return this.data; }
            private set { this.data = value; }
        }

        public Option Op
        {
            get { return this.op; }
            private set { this.op = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CalenderWindow"/> class.
        /// 初期化
        /// </summary>
        public CalenderWindow()
        {
            this.InitializeComponent();
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
            calVm.SetOneCalender(Data, option);
            this.DataContext = calVm;
        }

        /// <summary>
        /// チェックボックスクリック時の処理
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">イベントデータ</param>
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)this.weekChangeCheck.IsChecked)
            {
                this.Op.DatePriontChangeFlg = false;
            }
            else
            {
                this.Op.DatePriontChangeFlg = true;
            }

            ((CalenderWindowViewModel)this.DataContext).Data.CalenderDays.Clear();
            ((CalenderWindowViewModel)this.DataContext).SetOneCalender(this.Data, this.Op);
        }


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