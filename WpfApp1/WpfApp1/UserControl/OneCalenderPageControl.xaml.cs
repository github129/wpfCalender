// <copyright file="OneCalenderPageControl.xaml.cs" company="PlaceholderCompany">
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
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using Calender.Entitey;

    /// <summary>
    /// OneCalenderPageControl.xaml の相互作用ロジック
    /// </summary>
    public partial class OneCalenderPageControl : UserControl
    {
        private CalenderData data = new CalenderData();

        private Option op = new Option();

        /// <summary>
        /// Initializes a new instance of the <see cref="OneCalenderPageControl"/> class.
        /// </summary>
        public OneCalenderPageControl()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets カレンダーデータクラス
        /// </summary>
        public CalenderData Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        /// <summary>
        /// Gets or sets オプションクラス
        /// </summary>
        public Option Op
        {
            get { return this.op; }
            set { this.op = value; }
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
                this.Op.IsDatePrintChange = true;
            }
            else
            {
                this.Op.IsDatePrintChange = false;
            }

            SingleCalenderEventControl.Instance.IsWeekChange = this.Op.IsDatePrintChange;
            SingleCalenderEventControl.Instance.UpdataCalender(this.Op);
        }

        /// <summary>
        /// 当日の背景色選択時の処理
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">イベントデータ</param>
        private void TodayColorChange_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)this.TodayColorChange.IsChecked)
            {
                this.Op.IsTodayColorChange = true;
            }
            else
            {
                this.Op.IsTodayColorChange = false;
            }

            SingleCalenderEventControl.Instance.IsTodayColor = this.Op.IsTodayColorChange;
            SingleCalenderEventControl.Instance.ColorChangeEvent(this.Op);
        }
    }
}
