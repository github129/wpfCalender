// <copyright file="MainWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WpfApp1
{
    using System;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// ViewModelクラス
        /// </summary>
        private MainWindowViewModel vm = new MainWindowViewModel();

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
            this.vm.MonthListCreate();
            this.DataContext = this.vm;
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
            CalenderData data = new CalenderData();
            this.vm.SearchButtonPushEvent(data);
        }
    }
}
