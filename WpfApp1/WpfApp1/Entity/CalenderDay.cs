// <copyright file="CalenderDay.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Media;

    /// <summary>
    /// 曜日のの色の判断用enum
    /// </summary>
    public enum DateColor
    {
        None, Weekday, Saturday, Holiday,
    }

    /// <summary>
    /// カレンダーの日付を使うクラス
    /// </summary>
    public class CalenderDay : INotifyPropertyChanged
    {
        /// <summary>
        /// 日付の色
        /// </summary>
        private DateColor foreColor = (DateColor)1;

        /// <summary>
        /// 日付ごとの背景色
        /// </summary>
        private DateColor bgColor = (DateColor)1;

        private bool isToday = false;

        /// <summary>
        /// カラム
        /// </summary>
        private int col;

        /// <summary>
        /// 高さ（位置）
        /// </summary>
        private int row;

        /// <summary>
        /// 日付
        /// </summary>
        private string day;

        /// <summary>
        /// インターフェースの実装
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets grid coulm
        /// </summary>
        public int Col
        {
            get
            {
                return this.col;
            }

            set
            {
                if (this.col != value)
                {
                    this.col = value;
                    this.RaisePropertyChanged("Col");
                }
            }
        }

        /// <summary>
        /// Gets or sets grid coulm
        /// </summary>
        public bool IsToday
        {
            get
            {
                return this.isToday;
            }

            set
            {
                if (this.isToday != value)
                {
                    this.isToday = value;
                    this.RaisePropertyChanged("IsToday");
                }
            }
        }

        /// <summary>
        /// Gets or sets rowを扱うプロティ
        /// </summary>
        public int Row
        {
            get
            {
                return this.row;
            }

            set
            {
                if (this.row != value)
                {
                    this.row = value;
                    this.RaisePropertyChanged("Row");
                }
            }
        }

        /// <summary>
        /// Gets or sets 日付
        /// </summary>
        public string Day
        {
            get
            {
                return this.day;
            }

            set
            {
                if (this.day != value)
                {
                    this.day = value;
                    this.RaisePropertyChanged("Day");
                }
            }
        }

        /// <summary>
        /// Gets or sets 背景色用のプロパティ
        /// </summary>
        public DateColor BgColor
        {
            get
            {
                return this.bgColor;
            }

            set
            {
                if (this.bgColor != value)
                {
                    this.bgColor = value;
                    this.RaisePropertyChanged("BgColor");
                }
            }
        }

        /// <summary>
        /// Gets or sets 日付色用のプロパティ
        /// </summary>
        public DateColor ForeColor
        {
            get
            {
                return this.foreColor;
            }

            set
            {
                if (this.foreColor != value)
                {
                    this.foreColor = value;
                    this.RaisePropertyChanged("ForeColor");
                }
            }
        }

        /// <summary>
        /// 情報切り替え用のインターフェース
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        protected void RaisePropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
