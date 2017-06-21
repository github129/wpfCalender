namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CalenderData
    {
        private DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 01);

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


        /// <summary>
        /// 最初の曜日を求めるメソッド
        /// </summary>
        /// <param name="weekStartFlg"> 曜日が日曜始まりか月曜始まりかを判断するフラグ</param>
        /// <returns>fastDate 最初の曜日</returns>
        public int FastDateCreate(bool weekStartFlg)
        {
            var fastDay = 1;
            var dt = new DateTime(this.date.Year, this.date.Month, fastDay);

            var fastDate = (int)dt.DayOfWeek;
            return fastDate;
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
