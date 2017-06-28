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

    /// <summary>
    /// カレンダーの日付を使うクラス
    /// </summary>
    public class CalenderDay
    {
        /// <summary>
        /// 日付の色
        /// </summary>
        private string foreColor = "Black";

        /// <summary>
        /// 日付ごとの背景色
        /// </summary>
        private string bgColor = "White";

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
                this.col = value;
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
                this.row = value;
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
                this.day = value;
            }
        }

        /// <summary>
        /// Gets or sets 背景色用のプロパティ
        /// </summary>
        public string BgColor
        {
            get { return this.bgColor; }
            set { this.bgColor = value; }
        }

        /// <summary>
        /// Gets or sets 日付色用のプロパティ
        /// </summary>
        public string ForeColor
        {
            get { return this.foreColor; }
            set { this.foreColor = value; }
        }
    }
}
