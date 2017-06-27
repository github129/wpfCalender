// <copyright file="MainWindow.xaml.cs" company="PlaceholderCompany">
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
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 実行メソッド
        /// </summary>
        private void UserContorol()
        {
            var vm = new MainWindowViewModel();
            this.DataContext = vm;
        }

        /// <summary>
        /// ロード時のイベント　カレンダーを表示する
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">イベントデータ情報</param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.UserContorol();
        }

        /// <summary>
        /// 検索ボタンが押下されたときのイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">イベントデータの情報</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new CalenderWindow();
            var someWindow = new SomeCalenderWindow();
            var year = int.Parse(((MainWindowViewModel)this.DataContext).InputYear);
            var month = int.Parse(((MainWindowViewModel)this.DataContext).InputMonth);
            var count = int.Parse(((MainWindowViewModel)this.DataContext).MakeCalenderCount);
            ((MainWindowViewModel)this.DataContext).Date = new DateTime(year, month, 1);
            if (count > 1)
            {
                someWindow.SomeCalenderControl(((MainWindowViewModel)this.DataContext).Date, count);
                someWindow.Show();
            }
            else
            {
                window.UserContorol(((MainWindowViewModel)this.DataContext).Date);
                window.Show();
            }

        }
    }
}
