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
    using WpfApp1.Entity.WeekNumber;

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

        /// <summary>
        /// 曜日のチェックラベルの変更用メソッド
        /// </summary>
        /// <param name="week">オプションクラスの曜日の判断</param>
        protected void ChangeWeekText(bool week)
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
        protected void ChangeColorTextColor(bool color)
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
        private int DateSwitch(bool flg, int col)
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
        private void DayCreate(CalenderDay day, int today, int col, int row)
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
        private void DateColorChange(int col, CalenderDay day)
        {
            // 日曜日か土曜日かの判断
            if (col == this.sunColorNumber)
            {
                day.ForeColor = (DateColor)3;
            }
                else if (col == this.satColorNumber)
            {
                day.ForeColor = (DateColor)2;
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
        private void DaysCreate(CalenderCreateEntity entity, CalenderData data, int col, int row, Option option)
        {
            var startPoint = col;

            for (var i = 0; i < data.CalenderLastDay; i++)
            {
                this.calenderDay = new CalenderDay();
                this.DayCreate(this.calenderDay, i, col, row);

                // 曜日の色を変える処理
                this.DateColorChange(col, this.calenderDay);

                // 当日かどうかの判断
                if (option.IsTodayColorChange && int.Parse(this.calenderDay.Day) == DateTime.Now.Day && data.Date.Year == DateTime.Now.Year && data.Date.Month == DateTime.Now.Month)
                {
                    this.calenderDay.IsToday = true;
                }

                entity.CalenderDays.Add(this.calenderDay);
                col++;
                if (col > 6)
                {
                    row++;
                    col = 0;
                }
            }

            // デザイン用にスペースを作る処理　必ず6*7で作る
            for (var x = 0; x < 7; x++)
            {
                this.calenderDay = new CalenderDay();
                this.calenderDay.Col = x;
                this.calenderDay.Row = 0;
                entity.CalenderDays.Add(this.calenderDay);
            }

            for (int y = row; y < 6; y++)
            {
                for (int x = col - 1; x < 7; x++)
                {
                    this.calenderDay = new CalenderDay();
                    this.calenderDay.Col = x;
                    this.calenderDay.Row = y;
                    entity.CalenderDays.Add(this.calenderDay);
                }

                col = 0;
            }
        }

        /// <summary>
        /// カレンダーを１つ作成するメソッド
        /// </summary>
        /// <param name="calData">カレンダーデータクラス</param>
        /// <param name="paramOption">オプションクラス</param>
        /// <returns>CalenderEntity カレンダーの情報</returns>
        protected CalenderCreateEntity SetCalender(CalenderData calData, Option paramOption)
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

            var sun = new WeekTitleSun();
            sun.Title = week[0];
            sun.Col = dateCol;
            this.entity.CalenderWeekItems.Add(sun);
            dateCol++;

            var mon = new WeekTitleMon();
            mon.Title = week[1];
            mon.Col = dateCol;
            this.entity.CalenderWeekItems.Add(mon);
            dateCol++;

            var tue = new WeekTitleTue();
            tue.Title = week[2];
            tue.Col = dateCol;
            this.entity.CalenderWeekItems.Add(tue);
            dateCol++;

            var wen = new WeekTitleWen();
            wen.Title = week[3];
            wen.Col = dateCol;
            this.entity.CalenderWeekItems.Add(wen);
            dateCol++;

            var thu = new WeekTitleThu();
            thu.Title = week[4];
            thu.Col = dateCol;
            this.entity.CalenderWeekItems.Add(thu);
            dateCol++;

            var fri = new WeekTitleFri();
            fri.Title = week[5];
            fri.Col = dateCol;
            this.entity.CalenderWeekItems.Add(fri);
            dateCol++;

            var sat = new WeekTitleSat();
            sat.Title = week[6];
            sat.Col = dateCol;
            this.entity.CalenderWeekItems.Add(sat);

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
