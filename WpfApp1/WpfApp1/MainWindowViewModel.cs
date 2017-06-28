// <copyright file="MainWindowViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.ComponentModel;
    using Calender.Entitey;
    using System.Collections.ObjectModel;

    /// <summary>
    /// MainWindowのVMクラス
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// 日付
        /// </summary>
        private DateTime date;

        /// <summary>
        /// 入力年
        /// </summary>
        private string inputYear = DateTime.Now.Year.ToString();

        /// <summary>
        /// 入力月
        /// </summary>
        private string inputMonth = DateTime.Now.Month.ToString();

        /// <summary>
        /// カレンダーの作成数
        /// </summary>
        private string makeCalenderCount = "1";

        public event PropertyChangedEventHandler PropertyChanged;


        /// <summary>
        /// Gets or sets 年月日を扱うプロパティ
        /// </summary>
        public DateTime Date
        {
            get
            {
                return this.date;
            }

            set
            {
                if (this.date != value)
                {
                    this.date = value;
                    this.RaisePropertyChanged("Date");
                }
            }
        }

        public string InputYear
        {
            get
            {
                return this.inputYear;
            }

            set
            {
                if (this.inputYear != value)
                {
                    this.inputYear = value;
                    this.RaisePropertyChanged("InputYear");
                }
            }
        }

        public string InputMonth
        {
            get
            {
                return this.inputMonth;
            }

            set
            {
                if (this.inputMonth != value)
                {
                    this.inputMonth= value;
                    this.RaisePropertyChanged("InputMonth");
                }
            }
        }

        public string MakeCalenderCount
        {
            get { return this.makeCalenderCount; }

            set
            {
                if (this.makeCalenderCount != value)
                {
                    this.makeCalenderCount = value;
                    this.RaisePropertyChanged("MakeCalenderCount");
                }
            }
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            var d = PropertyChanged;
            if (d != null)
                d(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
