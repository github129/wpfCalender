﻿namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CalenderData
    {
        private DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 01);

        private List<string> list = new List<string>();

        private int fastDate;

        private int calenderLastDay;

        public int FastDate
        {
            get { return this.fastDate; }
            set { this.fastDate = value; }
        }

        public int CalenderLastDay
        {
            get { return this.calenderLastDay; }
            set { this.calenderLastDay = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { this.date = value; }
        }

        public List<string> List
        {
            get;
            set;
        }

        private string calenderDate;

        public string CalenderDate
        {
            get { return this.calenderDate; }
            set { this.calenderDate = value; }
        }

        private int col;

        public int Col
        {
            get { return col; }
            set { col = value; }
        }

        private int row;

        public int Row
        {
            get { return row; }
            set { row = value; }
        }


        private int day;

        public int Day
        {
            get { return day; }
            set { day = value; }
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
            FastDate = (int)dt.DayOfWeek;
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
