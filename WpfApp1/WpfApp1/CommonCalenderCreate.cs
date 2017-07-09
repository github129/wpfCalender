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
    using System.Windows.Media;
    using Calender.Entitey;
    using CustomEventArgs;

    /// <summary>
    /// DayのPath用enum
    /// </summary>
    internal enum DayPath
    {
        Day1, Day2, Day3, Day4, Day5, Day6, Day7, Day8, Day9, Day10,
        Day11, Day12, Day13, Day14, Day15, Day16, Day17, Day18, Day19, Day20,
        Day21, Day22, Day23, Day24, Day25, Day26, Day27, Day28, Day29, Day30, Day31
    }

    /// <summary>
    /// イベントハンドラーの設定
    /// </summary>
    /// <param name="sender">クラス情報</param>
    /// <param name="e">イベント情報</param>
    public delegate void SomeCalenderEventHandler(object sender, CalenderEventArgs e);

    /// <summary>
    /// イベントハンドラーの設定
    /// </summary>
    /// <param name="sender">呼び出し元のクラス</param>
    /// <param name="e">イベント情報</param>
    public delegate void SomeCalenderColorChangeEventHandler(object sender, CalenderEventArgs e);

    /// <summary>
    /// カレンダーを１つ作成するクラス
    /// </summary>
    public class CommonCalenderCreate : INotifyPropertyChanged
    {
        /// <summary>
        /// EventArgsクラス
        /// </summary>
        private CalenderEventArgs args = new CalenderEventArgs();

        /// <summary>
        /// 日付更新イベント
        /// </summary>
        public event SomeCalenderEventHandler CalenderUpdate;

        /// <summary>
        /// 当日の色更新イベント
        /// </summary>
        public event SomeCalenderColorChangeEventHandler TodayColorChenge;

        /// <summary>
        /// 日付更新イベント起動
        /// </summary>
        /// <param name="e">イベント情報</param>
        protected virtual void OnCalenderUpDate(CalenderEventArgs e)
        {
            if (this.CalenderUpdate != null)
            {
                this.CalenderUpdate(this, e);
            }
        }

        /// <summary>
        /// 当日の背景色更新イベント起動
        /// </summary>
        /// <param name="e">イベント情報</param>
        protected virtual void OnTodayColorChange(CalenderEventArgs e)
        {
            if (this.TodayColorChenge != null)
            {
                this.TodayColorChenge(this, e);
            }
        }

        /// <summary>
        /// カレンダーDayクラス
        /// </summary>
        private CalenderDay calenderDay;

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
        private Brush todayTextColor = new SolidColorBrush(Colors.Khaki);

        private int sunColorNumber = 0;

        private int satColorNumber = 6;

        /// <inheritdoc/>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets argsを扱うプロパティ
        /// </summary>
        public CalenderEventArgs Args
        {
            get { return this.args; }
            set { this.args = value; }
        }

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
        public Brush TodayTextColor
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

        //public int DayPathProp
        //{
        //   // get { return DayPath.; }
        //}

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
                this.TodayTextColor = new SolidColorBrush(Colors.Black);
            }
            else
            {
                this.TodayTextColor = new SolidColorBrush(Colors.Khaki);
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
                    day.ForeColor = new SolidColorBrush(Colors.Red);
                }
                else if (col == this.satColorNumber)
                {
                    day.ForeColor = new SolidColorBrush(Colors.SlateBlue);
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
                    this.calenderDay.BgColor = new SolidColorBrush(Colors.Khaki);
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
            this.entity.StringMonth = calData.Date.Month.ToString();
            this.entity.StringYear = calData.Date.Year.ToString();
            this.option = paramOption;

            var col = this.DateSwitch(this.option.IsDatePrintChange,  calData.FastDate);

            var row = 0;
            this.DaysCreate(this.entity, calData, col, row, this.option);

            var dateCol = 0;

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
                weekItem.Col = dateCol;
                dateCol++;
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
