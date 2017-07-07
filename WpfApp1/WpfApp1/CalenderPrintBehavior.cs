﻿// <copyright file="CalenderPrintBehavior.cs" company="PlaceholderCompany">
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
    using System.Windows.Interactivity;
    using System.Windows.Media;
    using System.Windows.Shapes;

    /// <summary>
    /// Day表示用ビヘイビアクラス
    /// </summary>
    public class CalenderPrintBehavior : Behavior<Rectangle>
    {
        /// <summary>
        /// DayPropaty(xaml)を扱うプロパティ
        /// </summary>
        private static readonly DependencyProperty NumberProperty =
            DependencyProperty.Register(
                "Number", // プロパティ名を指定
                typeof(string), // プロパティの型を指定
                typeof(CalenderPrintBehavior), // プロパティを所有する型を指定
                new PropertyMetadata(string.Empty, NumberChanged)); // メタデータを指定。ここではデフォルト値を設定してる

        /// <summary>
        /// DayPropaty(xaml)を扱うプロパティ
        /// </summary>
        private static readonly DependencyProperty DateMonthProperty =
            DependencyProperty.Register(
                "Key", // プロパティ名を指定
                typeof(string), // プロパティの型を指定
                typeof(CalenderPrintBehavior), // プロパティを所有する型を指定
                new PropertyMetadata(string.Empty, KeyCheck)); // メタデータを指定。ここではデフォルト値を設定してる

        private string number = string.Empty;

        private string key = string.Empty;

        /// <summary>
        /// Gets or sets 文字列Day（DayClass）の情報を扱うプロパティ
        /// </summary>
        public string Number
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets 先頭の文字列
        /// </summary>
        public string Key
        {
            get; set;
        }

        /// <summary>
        /// 文字列DayをCalenderDictionaryに登録したKeyに変更するメソッド
        /// </summary>
        /// <param name="d">クラス情報</param>
        /// <param name="e">変更情報</param>
        private static void NumberChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((CalenderPrintBehavior)d).number = (string)e.NewValue;
        }

        private static void KeyCheck(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((CalenderPrintBehavior)d).key = (string)e.NewValue;
        }

        /// <summary>
        /// 要素がアタッチ(加えられた)されたときの処理
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.Loaded += (s, e) =>
            {
                if (!string.IsNullOrEmpty(this.number))
                {
                    var dayPath = this.key + this.number;
                    var resource = this.AssociatedObject.FindResource(dayPath);
                    this.AssociatedObject.Fill = (Brush)resource;
                }
            };
        }

        /// <summary>
        /// 要素がデタッチされたときの処理
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();
        }
    }
}