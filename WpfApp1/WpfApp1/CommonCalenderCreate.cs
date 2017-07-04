// <copyright file="CommonCalenderCreate.cs" company="PlaceholderCompany">
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
    /// カレンダーを１つ作成するクラス
    /// </summary>
    public class CommonCalenderCreate : INotifyPropertyChanged
    {
        /// <summary>
        /// カレンダーDayクラス
        /// </summary>
        private CalenderDay calenderDay;

        /// <summary>
        /// カレンダーデータクラス
        /// </summary>
        private CalenderData data;

        /// <summary>
        /// カレンダー情報クラス
        /// </summary>
        private CalenderCreateEntity entity;

        /// <summary>
        /// オプションクラス
        /// </summary>
        private Option option;

        /// <summary>
        /// 曜日の入った配列 sFlgがtureの場合
        /// </summary>
        private static readonly string[] DateListS = { "日", "月", "火", "水", "木", "金", "土" };

        /// <summary>
        /// 曜日の入った配列　sFlgがfalseの場合
        /// </summary>
        private static readonly string[] DateListM = { "月", "火", "水", "木", "金", "土", "日" };

        /// <summary>
        /// 曜日始まりのラベル
        /// </summary>
        private string startText = "日曜始まり";

        /// <summary>
        /// 当日の色を変えるテキストのカラー
        /// </summary>
        private string todayTextColor = "Khaki";

        private int sunColorNumber = 0;

        private int satColorNumber = 6;

        /// <inheritdoc/>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets ラベルを扱うプロパティ
        /// </summary>
        public string StartText
        {
            get
            {
                return this.startText;
            }

            set
            {
                if (this.startText != value)
                {
                    this.startText = value;
                    this.RaisePropertyChanged("StartText");
                }
            }
        }

        /// <summary>
        /// Gets or sets 色を変えるためのプロパティ
        /// </summary>
        public string TodayTextColor
        {
            get
            {
                return this.todayTextColor;
            }

            set
            {
                if (this.todayTextColor != value)
                {
                    this.todayTextColor = value;
                    this.RaisePropertyChanged("TodayTextColor");
                }
            }
        }

        /// <summary>
        /// Gets or sets カレンダー情報クラス用プロパティ
        /// </summary>
        public CalenderCreateEntity Entity
        {
            get { return this.entity; }
            set { this.entity = value; }
        }

        /// <summary>
        /// 曜日のチェックラベルの変更用メソッド
        /// </summary>
        /// <param name="week">オプションクラスの曜日の判断</param>
        public void ChangeWeekText(bool week)
        {
            if (!week)
            {
                this.StartText = "月曜始まり";
            }
            else
            {
                this.StartText = "日曜始まり";
            }
        }

        /// <summary>
        /// 当日のBG色を変えるメソッド
        /// </summary>
        /// <param name="color">オプションクラスのvgcolorの判断</param>
        public void ChangeColorTextColor(bool color)
        {
            if (!color)
            {
                this.TodayTextColor = "Black";
            }
            else
            {
                this.TodayTextColor = "Khaki";
            }
        }

        /// <summary>
        /// 開始位置を変更するメソッド
        /// </summary>
        /// <param name="flg">日曜始まりか月曜始まりか</param>
        /// <param name="col">横の位置</param>
        /// <returns>startDate 開始位置</returns>
        public int DateSwitch(bool flg, int col)
        {
            int startDate = col;
            if (!flg && col > 0)
            {
                startDate--;
                this.sunColorNumber = 6;
                this.satColorNumber = 5;
            }
            else if (!flg && col == 0)
            {
                startDate = 6;
                this.sunColorNumber = 6;
                this.satColorNumber = 5;
            }

            return startDate;
        }

        /// <summary>
        /// 日付をクラスに追加するメソッド
        /// </summary>
        /// <param name="day">Dayクラス</param>
        /// <param name="today">日付</param>
        /// <param name="col">横の位置</param>
        /// <param name="row">縦の位置</param>
        public void DayCreate(CalenderDay day, int today, int col, int row)
        {
                day.Day = (today + 1).ToString();
                day.Row = row;
                day.Col = col;
        }

        /// <summary>
        /// 曜日の色を変更するメソッド
        /// </summary>
        /// <param name="col">横の位置</param>
        /// <param name="day">Dayクラス</param>
        public void DateColorChange(int col, CalenderDay day)
        {
                if (col == this.sunColorNumber)
                {
                    day.ForeColor = "red";
                    day.BgColor = "Tomato";
                }
                else if (col == this.satColorNumber)
                {
                    day.ForeColor = "SlateBlue";
                    day.BgColor = "SkyBlue";
                }
        }

        /// <summary>
        /// 日付をリストにするクラス
        /// </summary>
        /// <param name="entity">Entityクラス</param>
        /// <param name="data">Dataクラス</param>
        /// <param name="col">横の位置</param>
        /// <param name="row">縦の位置</param>
        /// <param name="option">Optionクラス</param>
        public void DaysCreate(CalenderCreateEntity entity, CalenderData data, int col, int row, Option option)
        {
            for (var i = 0; i < data.CalenderLastDay; i++)
            {
                this.calenderDay = new CalenderDay();
                this.DayCreate(this.calenderDay, i, col, row);

                // 曜日の色を変える処理
                this.DateColorChange(col, this.calenderDay);

                // 当日かどうかの判断
                if (option.IsTodayColorChange && i == DateTime.Now.Day && data.Date.Year == DateTime.Now.Year && data.Date.Month == DateTime.Now.Month)
                {
                    this.calenderDay.BgColor = "Khaki";
                }

                entity.CalenderDays.Add(this.calenderDay);
                col++;
                if (col > 6)
                {
                    row++;
                    col = 0;
                }
            }
        }

        /// <summary>
        /// カレンダーを１つ作成するメソッド
        /// </summary>
        /// <param name="calData">カレンダーデータクラス</param>
        /// <param name="paramOption">オプションクラス</param>
        /// <returns>CalenderEntity カレンダーの情報</returns>
        public CalenderCreateEntity SetCalender(CalenderData calData, Option paramOption)
        {
            // 日付データの作成
            this.entity = new CalenderCreateEntity();
            this.sunColorNumber = 0;
            this.satColorNumber = 6;

            calData.LastDay();
            calData.FastDateCreate();
            this.entity.Date = calData.Date;
            this.option = paramOption;

            var col = this.DateSwitch(this.option.IsDatePrintChange,  calData.FastDate);

            var row = 0;
            this.DaysCreate(this.entity, calData, col, row, this.option);

            // 曜日タイトルの作成
            var week = DateListS;
            if (!this.option.IsDatePrintChange)
            {
                week = DateListM;
            }

            foreach (string s in week)
            {
                var weekItem = new WeekItem();
                weekItem.Title = s;
                this.entity.CalenderWeekItems.Add(weekItem);
            }

            return this.entity;
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
