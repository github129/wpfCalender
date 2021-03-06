﻿// <copyright file="CalenderCreateEntity.cs" company="PlaceholderCompany">
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
    using WpfApp1.Entity.WeekNumber;

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
        /// string型の月
        /// </summary>
        private string stringMonth;

        /// <summary>
        /// string型の年
        /// </summary>
        private string stringYear;

        /// <summary>
        /// Initializes a new instance of the <see cref="CalenderCreateEntity"/> class.
        /// コンストラクター　イベントを張る処理
        /// </summary>
        public CalenderCreateEntity()
        {
            SingleCalenderEventControl.Instance.CalenderUpdate += new SomeCalenderEventHandler(this.DayListUpdate);
            SingleCalenderEventControl.Instance.CalenderUpdate += new SomeCalenderEventHandler(this.WeekChange);
            SingleCalenderEventControl.Instance.TodayColorChenge += new SomeCalenderColorChangeEventHandler(this.TodayColorChange);
        }

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
        /// Gets or sets string型のmonthを扱うプロパティ
        /// </summary>
        public string StringYear
        {
            get
            {
                return this.stringYear;
            }

            set
            {
                if (this.stringYear != value)
                {
                    this.stringYear = value;
                    this.RaisePropertyChanged("StringYear");
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

        /// <summary>
        /// カレンダーの日付を書き換えるメソッド
        /// </summary>
        /// <param name="sender">呼び出し元のクラス</param>
        /// <param name="e">イベント情報</param>
        private void DayListUpdate(object sender, CalenderEventArgs e)
        {
            var col = 0;
            var row = 0;

            // 曜日のチェックが外れていた場合
            if (!e.Option.IsDatePrintChange)
            {
                if (this.CalenderDays[0].Col == 0)
                {
                    col = 6;
                }
                else
                {
                    col = this.CalenderDays[0].Col - 1;
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
                // Dayが未入力の場合（線の表示が必要の為、6*7で必ず作っている）
                if (this.CalenderDays[i].Day == null)
                {
                    break;
                }

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
        private void WeekChange(object sender, CalenderEventArgs e)
        {
            // 曜日タイトルの作成
            int dateCol = 0;
            if (!e.Option.IsDatePrintChange)
            {
                dateCol = 6;
            }

            var sun = new WeekTitleSun()
            {
                Col = dateCol,
            };
            this.CalenderWeekItems[0] = sun;
            dateCol++;

            if (dateCol > 6)
            {
                dateCol = 0;
            }

            var mon = new WeekTitleMon()
            {
                Col = dateCol,
            };
            this.CalenderWeekItems[1] = mon;
            dateCol++;

            var tue = new WeekTitleTue()
            {
                Col = dateCol,
            };
            this.CalenderWeekItems[2] = tue;
            dateCol++;

            var wen = new WeekTitleWen()
            {
                Col = dateCol,
            };
            this.CalenderWeekItems[3] = wen;
            dateCol++;

            var thu = new WeekTitleThu()
            {
                Col = dateCol,
            };
            this.CalenderWeekItems[4] = thu;
            dateCol++;

            var fri = new WeekTitleFri()
            {
                Col = dateCol,
            };
            this.CalenderWeekItems[5] = fri;
            dateCol++;

            var sat = new WeekTitleSat()
            {
                Col = dateCol,
            };
            this.CalenderWeekItems[6] = sat;
        }

        /// <summary>
        /// 当日の色を変えるメソッド
        /// </summary>
        /// <param name="sender">呼び出し元のクラス情報</param>
        /// <param name="e">イベント情報</param>
        private void TodayColorChange(object sender, CalenderEventArgs e)
        {
            for (int i = 0; i < this.CalenderDays.Count; i++)
            {
                // 当日色変更フラグがtrueでかつ当日だった時
                if (e.Option.IsTodayColorChange && this.dayList[i].Day != null && int.Parse(this.dayList[i].Day) == DateTime.Now.Day && this.date.Year == DateTime.Now.Year && this.date.Month == DateTime.Now.Month)
                {
                    this.dayList[i].IsToday = true;
                }

                // 当日変更フラグがfalseで当日だった時
                else if (!e.Option.IsTodayColorChange && this.dayList[i].Day != null && int.Parse(this.dayList[i].Day) == DateTime.Now.Day && this.date.Year == DateTime.Now.Year && this.date.Month == DateTime.Now.Month)
                {
                    this.dayList[i].IsToday = false;
                }
            }
        }
    }
}
