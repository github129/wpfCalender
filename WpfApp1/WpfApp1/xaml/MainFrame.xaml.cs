// <copyright file="MainFrame.xaml.cs" company="PlaceholderCompany">
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
    using FlickrAPI;

    /// <summary>
    /// MainFrame.xaml の相互作用ロジック
    /// </summary>
    public partial class MainFrame : Window
    {
        /// <summary>
        /// カレンダーデータクラス
        /// </summary>
        private CalenderData data;

        /// <summary>
        /// オプションクラス
        /// </summary>
        private Option op;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainFrame"/> class.
        /// </summary>
        public MainFrame()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// VMを動かすメソッド
        /// </summary>
        /// <param name="data">カレンダーデータクラス</param>
        /// <param name="op">オプションクラス</param>
        public void UserContorol(CalenderData data, Option op)
        {
            this.data = data;
            this.op = op;
            ((MainFrameViewModel)this.DataContext).CreateControl(data, op);
        }

        /// <summary>
        /// 表示変更ボタンが押されたときのイベント
        /// </summary>
        /// <param name="sender">クラス情報</param>
        /// <param name="e">イベント情報</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((MainFrameViewModel)this.DataContext).TogglePageEvent();
        }
    }
}
