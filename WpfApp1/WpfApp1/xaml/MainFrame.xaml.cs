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
        private CalenderData data;

        private Option op;

        private CalenderWindowViewModel calVm;

        private SomeCalenderWindowViewModel somVm;

        public MainFrame()
        {
            InitializeComponent();
        }

        public void UserContorol(CalenderData data, Option op)
        {
            this.data = data;
            this.op = op;
            ((MainFrameViewModel)this.DataContext).CreateControl(data, op);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((MainFrameViewModel)this.DataContext).TogglePageEvent();
        }
    }
}
