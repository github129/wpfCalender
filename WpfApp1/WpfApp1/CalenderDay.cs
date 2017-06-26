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
    public class CalenderDay : INotifyPropertyChanged
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
                if (this.col != value)
                {
                    this.col = value;
                    this.RaisePropertyChanged("Col");
                }
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
                    this.RaisePropertyChanged("Col");
                }
            }
        }

        public string BgColor
        {
            get;set;
        }

        public string ForeColor
        {
            get;set;
        }

        public event PropertyChangedEventHandler PropertyChanged;


        protected void RaisePropertyChanged(string propertyName)
        {
            var d = PropertyChanged;
            if (d != null)
                d(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
