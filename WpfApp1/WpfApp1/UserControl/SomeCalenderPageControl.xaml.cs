// <copyright file="SomeCalenderPageControl.xaml.cs" company="PlaceholderCompany">
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
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using Calender.Entitey;

    /// <summary>
    /// SomeCalenderPageControl.xaml の相互作用ロジック
    /// </summary>
    public partial class SomeCalenderPageControl : UserControl
    {
        /// <summary>
        /// カレンダーデータクラス
        /// </summary>
        private CalenderData data = new CalenderData();

        /// <summary>
        /// オプションクラス
        /// </summary>
        private Option op = new Option();

        /// <summary>
        /// SomeCalenderWindowViewModelクラスが入ったリスト
        /// </summary>
        private IList<SomeCalenderWindowViewModel> calender = new ObservableCollection<SomeCalenderWindowViewModel>();

        /// <summary>
        /// Initializes a new instance of the <see cref="SomeCalenderPageControl"/> class.
        /// </summary>
        public SomeCalenderPageControl()
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
        /// 始まりの曜日を変えるイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">イベント情報</param>
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
        /// 当日のカラーを変更するイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">イベント情報</param>
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
