﻿// <copyright file="MainWindowViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Calender.Entitey;

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
        private int inputMonth = DateTime.Now.Month;

        /// <summary>
        /// カレンダーの作成数
        /// </summary>
        private string makeCalenderCount = "1";

        /// <inheritdoc/>
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

        /// <summary>
        /// Gets or sets 入力年用のプロパティ
        /// </summary>
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

        /// <summary>
        /// Gets or sets 入力月用のプロパティ
        /// </summary>
        public int InputMonth
        {
            get
            {
                return this.inputMonth;
            }

            set
            {
                if (this.inputMonth != value)
                {
                    this.inputMonth = value;
                    this.RaisePropertyChanged("InputMonth");
                }
            }
        }

        /// <summary>
        /// Gets or sets カレンダーを作成する個数
        /// </summary>
        public string MakeCalenderCount
        {
            get
            {
                return this.makeCalenderCount;
            }

            set
            {
                if (this.makeCalenderCount != value)
                {
                    this.makeCalenderCount = value;
                    this.RaisePropertyChanged("MakeCalenderCount");
                }
            }
        }

        /// <summary>
        /// 検索ボタンが押されたときのイベント処理メソッド
        /// </summary>
        /// <param name="data">カレンダーデータクラス</param>
        public void SearchButtonPushEvent(CalenderData data)
        {
            var op = new Option();

            // 年の確認
            if (this.InputYear.Length == 0)
            {
                this.InputYear = DateTime.Now.Year.ToString();
            }

            this.inputMonth = 1;
            this.Date = new DateTime(int.Parse(this.InputYear), this.InputMonth, 1);
            data.Date = this.Date;
            data.InputDate = this.Date;
            var frame = new MainFrame();
            frame.UserContorol(data, op);
            frame.Show();
        }

        /// <summary>
        /// プロパティを書き換変わったかどうかを判断するメソッド
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        protected void RaisePropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
