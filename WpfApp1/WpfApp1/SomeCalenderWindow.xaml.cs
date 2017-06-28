﻿namespace WpfApp1
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
        private SomeCalenderWindowViewModel vm = new SomeCalenderWindowViewModel();

        private Option op = new Option();

        private CalenderData data = new CalenderData();

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
        public void SomeCalenderControl(DateTime date, int n)
        {
            this.op.CalenderCreateCount = n;
            this.data.Date = date;
            this.data.InputDate = date;
            this.vm.SetSomeCalender(this.data, this.op);
            this.DataContext = this.vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.vm.ChangeFilter(this.data.InputDate.AddYears(-1), this.data.InputDate);
            this.data.InputDate = this.data.InputDate.AddYears(-1);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.vm.ChangeFilter(this.data.InputDate.AddYears(1), this.data.InputDate);
            this.data.InputDate = this.data.InputDate.AddYears(1);
        }
    }
}