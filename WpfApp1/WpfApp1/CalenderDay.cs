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

        private string foreColor = "Black";

        private string bgColor = "White";

        private int col;

        private int row;

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

        public string BgColor
        {
            get { return this.bgColor; }
            set { this.bgColor = value; }
        }

        public string ForeColor
        {
            get { return this.foreColor; }
            set { this.foreColor = value; }
        }
    }
}
