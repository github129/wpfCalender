// <copyright file="CalenderCreateEntity.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Calender.Entitey;
    using System.ComponentModel;

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
        /// イベントハンドラー
        /// </summary>
        /// <param name="sender">呼び出し元のクラス</param>
        /// <param name="e">イベントデータを含まないイベント</param>
        public void StartHandler(SomeCalenderWindowViewModel vm)
        {
            vm.CalenderUpdate += new EventHandler(this.DayListUpdate);
        }

        public void DayListUpdate(object sender, EventArgs e)
        {
            var col = 0;
            var row = 0;
            if (this.CalenderDays[0].Col > 0)
            {
                col = this.CalenderDays[0].Col - 1;
            }
            else
            {
                col = 6;
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
        /// 情報切り替え用のインターフェース
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        protected void RaisePropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
