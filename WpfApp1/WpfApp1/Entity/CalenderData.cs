// <copyright file="CalenderData.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// カレンダーのデータを扱うクラス
    /// </summary>
    public class CalenderData
    {
        /// <summary>
        /// 年月日　デフォルトは現在
        /// </summary>
        private DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

        /// <summary>
        /// 最初の曜日
        /// </summary>
        private int fastDate;

        /// <summary>
        /// 最終日
        /// </summary>
        private int calenderLastDay;

        /// <summary>
        /// Gets or sets 最初の曜日を扱うプロパティ
        /// </summary>
        public int FastDate
        {
            get { return this.fastDate; }
            set { this.fastDate = value; }
        }

        /// <summary>
        /// Gets or sets 最終日を扱うプロパティ
        /// </summary>
        public int CalenderLastDay
        {
            get { return this.calenderLastDay; }
            set { this.calenderLastDay = value; }
        }

        /// <summary>
        /// Gets or sets 年月日を扱うプロパティ
        /// </summary>
        public DateTime Date
        {
            get { return this.date; }
            set { this.date = value; }
        }

        /// <summary>
        /// Gets or sets 入力された年月日の保存用プロパティ
        /// </summary>
        public DateTime InputDate
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets 上書き用の年月日プロパティ
        /// </summary>
        public DateTime UpDataDate
        {
            get; set;
        }

        /// <summary>
        /// 年月日を更新するメソッド
        /// </summary>
        /// <param name="date">日</param>
        /// <param name="weekStartFlg"> 曜日が日曜始まりか月曜始まりかを判断するフラグ</param>
        public void Update()
        {
            this.FastDateCreate();
            this.LastDay();
        }

        /// <summary>
        /// 最初の曜日を求めるメソッド
        /// </summary>
        /// <param name="weekStartFlg"> 曜日が日曜始まりか月曜始まりかを判断するフラグ</param>
        public void FastDateCreate()
        {
            var fastDay = 1;
            var dt = new DateTime(this.date.Year, this.date.Month, fastDay);
            this.FastDate = (int)dt.DayOfWeek;
        }

        /// <summary>
        /// 最終日を求めるメソッド
        /// </summary>
        public void LastDay()
        {
            this.CalenderLastDay = DateTime.DaysInMonth(this.date.Year, this.date.Month);
        }
    }
}
