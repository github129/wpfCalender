// <copyright file="CalenderDayBehavior.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Interactivity;
    using System.Windows.Media;
    using System.Windows.Shapes;

    /// <summary>
    /// 日付用ビヘイビアクラス
    /// </summary>
    public class CalenderDayBehavior : Behavior<System.Windows.Shapes.Rectangle>
    {
        /// <summary>
        /// DayPropaty(xaml)を扱うプロパティ
        /// </summary>
        private static readonly DependencyProperty NumberProperty =
            DependencyProperty.Register(
                "Number", // プロパティ名を指定
                typeof(string), // プロパティの型を指定
                typeof(CalenderDayBehavior), // プロパティを所有する型を指定
                new PropertyMetadata(string.Empty, NumberChanged)); // メタデータを指定。ここではデフォルト値を設定してる

        /// <summary>
        /// Color(xaml)を扱うプロパティ
        /// </summary>
        private static readonly DependencyProperty DayColorProperty =
            DependencyProperty.Register(
                "DayColor",
                typeof(DateColor),
                typeof(CalenderDayBehavior),
                new PropertyMetadata((DateColor)0, KeyCheck));

        private string number;

        private DateColor color = (DateColor)0;

        /// <summary>
        /// Gets or sets 文字列Day（DayClass）の情報を扱うプロパティ
        /// </summary>
        public string Number
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets 文字色
        /// </summary>
        public DateColor DayColor
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
            ((CalenderDayBehavior)d).number = (string)e.NewValue;
        }

        private static void KeyCheck(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((CalenderDayBehavior)d).color = (DateColor)e.NewValue;
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
                    var dayPath = "Day" + this.number;
                    var dayColorPath = "DayColor" + (int)this.color;

                    var strColor = this.AssociatedObject.FindResource(dayColorPath);

                    var resource = this.AssociatedObject.FindResource(dayPath);
                    this.AssociatedObject.OpacityMask = (System.Windows.Media.Brush)resource;
                    this.AssociatedObject.Fill = (System.Windows.Media.Brush)strColor;
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
