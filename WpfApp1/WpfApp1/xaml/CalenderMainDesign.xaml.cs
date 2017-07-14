// <copyright file="CalenderMainDesign.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WpfApp1
{
    using System;
    using System.Windows;
    using Calender.Entitey;
    using FlickrAPI;
    using System.Windows.Media.Imaging;
    using System.Threading.Tasks;
    using System.Net.Http;
    using System.IO;
    using System.Collections.Generic;

    /// <summary>
    /// CalenderMainDesign.xaml の相互作用ロジック
    /// </summary>
    public partial class CalenderMainDesign : Window
    {
        private CalenderData data = new CalenderData();

        private CalenderWindowViewModel vm;

        private Option op = new Option();

        /// <summary>
        /// Initializes a new instance of the <see cref="CalenderMainDesign"/> class.
        /// 初期化処理
        /// </summary>
        public CalenderMainDesign()
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
        /// 実行メソッド
        /// </summary>
        /// <param name="date">DaateTime　入力された年月日</param>
        public void UserContorol(DateTime date)
        {
            this.Data.Date = date;
            this.Op = new Option();
            var vmList = new List<CalenderWindowViewModel>();
            for (var i = 0; i < 12; i++)
            {
                this.vm = new CalenderWindowViewModel();
                this.vm.SetOneCalender(this.Data, this.Op);
                var imgApi = new ImgAPI();
                UriTypeConverter con = new UriTypeConverter();
                this.vm.Entity.ImgUrl = imgApi.GetImg();
                vmList.Add(this.vm);
            }

            this.vm.Vms = vmList;
            this.DataContext = this.vm;
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
                this.Op.IsDatePrintChange = false;
            }
            else
            {
                this.Op.IsDatePrintChange = true;
            }

            for (int i = 0; i < 12; i++)
            {
                ((CalenderWindowViewModel)this.DataContext).Vms[i].UpdataCalender(this.op);
            }
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
                this.Op.IsTodayColorChange = false;
            }
            else
            {
                this.Op.IsTodayColorChange = true;
            }

            ((CalenderWindowViewModel)this.DataContext).Vms[DateTime.Now.Month - 1].ColorChangeEvent(this.op);
        }
    }
}
