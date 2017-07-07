// <copyright file="CalenderCreateEntity.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows.Media;
    using Calender.Entitey;
    using CustomEventArgs;

    /// <summary>
    /// カレンダー情報をすべて保持しているクラス
    /// </summary>
    public class CalenderCreateEntity : INotifyPropertyChanged
    {
        /// <summary>
        /// 日付クラスの情報が入ったリスト
        /// </summary>
        private IList<CalenderDay> dayList = new ObservableCollection<CalenderDay>();

        /// <summary>
        /// 曜日クラスの情報が入ったリスト
        /// </summary>
        private IList<WeekItem> weekItems = new ObservableCollection<WeekItem>();

        /// <summary>
        /// 日付
        /// </summary>
        private DateTime date;

        /// <summary>
        /// ビヘイビア用キーName
        /// </summary>
        private string monthKeyName = "Month";

        private string stringMonth;

        /// <summary>
        /// 曜日の入った配列 sFlgがtureの場合
        /// </summary>
        private static readonly string[] DateListS = { "日", "月", "火", "水", "木", "金", "土" };

        /// <summary>
        /// 曜日の入った配列　sFlgがfalseの場合
        /// </summary>
        private static readonly string[] DateListM = { "月", "火", "水", "木", "金", "土", "日" };

        /// <summary>
        /// インターフェース
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets カレンダーの日付リストを扱うプロパティ
        /// </summary>
        public IList<CalenderDay> CalenderDays
        {
            get
            {
                return this.dayList;
            }

            set
            {
                if (this.dayList != value)
                {
                    this.dayList = value;
                    this.RaisePropertyChanged("CalenderDays");
                }
            }
        }

        /// <summary>
        /// Gets or sets カレンダーの曜日リストを扱うプロパティ
        /// </summary>
        public IList<WeekItem> CalenderWeekItems
        {
            get
            {
                return this.weekItems;
            }

            set
            {
                this.weekItems = value;
            }
        }

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
                this.date = value;
            }
        }

        /// <summary>
        /// Gets or sets keyNameを扱うプロパティ
        /// </summary>
        public string MonthKeyName
        {
            get { return this.monthKeyName; }
            set { this.monthKeyName = value; }
        }

        /// <summary>
        /// Gets or sets string型のmonthを扱うプロパティ
        /// </summary>
        public string StringMonth
        {
            get
            {
                return this.stringMonth;
            }

            set
            {
                if (this.stringMonth != value)
                {
                    this.stringMonth = value;
                    this.RaisePropertyChanged("StringMonth");
                }
            }
        }

        /// <summary>
        /// カレンダーの日付を書き換えるメソッド
        /// </summary>
        /// <param name="sender">呼び出し元のクラス</param>
        /// <param name="e">イベント情報</param>
        public void DayListUpdate(object sender, CalenderEventArgs e)
        {
            var col = 0;
            var row = 0;
            if (!e.Option.IsDatePrintChange)
            {
                if (this.CalenderDays[0].Col > 0)
                {
                    col = this.CalenderDays[0].Col - 1;
                }
                else
                {
                    col = 6;
                }
            }
            else
            {
                if (this.CalenderDays[0].Col < 6)
                {
                    col = this.CalenderDays[0].Col + 1;
                }
            }

            for (int i = 0; i < this.CalenderDays.Count; i++)
            {
                this.CalenderDays[i].Col = col;
                this.CalenderDays[i].Row = row;
                col++;
                if (col > 6)
                {
                    col = 0;
                    row++;
                }
            }
        }

        /// <summary>
        /// カレンダーを変更するイベント
        /// </summary>
        /// <param name="sender">呼び出し元のクラス</param>
        /// <param name="e">イベント情報</param>
        public void WeekChange(object sender, CalenderEventArgs e)
        {
            // 曜日タイトルの作成
            var week = DateListS;
            if (!e.Option.IsDatePrintChange)
            {
                week = DateListM;
            }

            int count = 0;
            int col = 0;
            foreach (string s in week)
            {
                var weekItem = new WeekItem();
                weekItem.Title = s;
                weekItem.Col = col;
                col++;
                this.CalenderWeekItems[count] = weekItem;
                count++;
            }
        }

        /// <summary>
        /// 当日の色を変えるメソッド
        /// </summary>
        /// <param name="sender">呼び出し元のクラス情報</param>
        /// <param name="e">イベント情報</param>
        public void TodayColorChange(object sender, CalenderEventArgs e)
        {
            for (int i = 0; i < this.CalenderDays.Count; i++)
            {
                if (e.Option.IsTodayColorChange && i == DateTime.Now.Day && this.date.Year == DateTime.Now.Year && this.date.Month == DateTime.Now.Month)
                {
                    this.dayList[i].BgColor = new SolidColorBrush(Colors.Khaki);
                }
                else if (!e.Option.IsTodayColorChange && i == DateTime.Now.Day && this.date.Year == DateTime.Now.Year && this.date.Month == DateTime.Now.Month)
                {
                    this.dayList[i].BgColor = new SolidColorBrush(Colors.White);
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
