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

    public class CalenderWindowViewModel : INotifyPropertyChanged
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
        /// 曜日の入った配列 sFlgがtureの場合
        /// </summary>
        private static readonly string[] DateListS = { "日", "月", "火", "水", "木", "金", "土" };

        /// <summary>
        /// 曜日の入った配列　sFlgがfalseの場合
        /// </summary>
        private static readonly string[] DateListM = { "月", "火", "水", "木", "金", "土", "日" };

        /// <summary>
        /// インターフェースの実行
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets カレンダーの日付リストを扱うプロパティ
        /// </summary>
        public IList<CalenderDay> CalenderDays
        {
            get { return this.dayList; }
            set { this.dayList = value; }
        }

        /// <summary>
        /// Gets or sets カレンダーの曜日リストを扱うプロパティ
        /// </summary>
        public IList<WeekItem> CalenderWeekItems
        {
            get { return this.weekItems; }
            set { this.weekItems = value; }
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
                if (this.date != value)
                {
                    this.date = value;
                    this.RaisePropertyChanged("Date");
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
        /// カレンダーを作成するメソッド
        /// </summary>
        /// <param name="calData">カレンダーデータクラス</param>
        /// <param name="option">オプションクラス</param>
        public void SetCalender(CalenderData calData, Option option)
        {
            // 日付データの作成
            calData.LastDay();
            calData.FastDateCreate();
            this.Date = calData.Date;
            var col = calData.FastDate;
            if (!option.DatePriontChangeFlg && col > 0)
            {
                col--;
            }
            else if (!option.DatePriontChangeFlg && col == 0)
            {
                col = 6;
            }

            var row = 0;
            for (var i = 0; i < calData.CalenderLastDay; i++)
            {
                var day = new CalenderDay();
                day.Day = (i + 1).ToString();
                day.Row = row;
                day.Col = col;
                this.dayList.Add(day);
                col++;
                if (col > 6)
                {
                    row++;
                    col = 0;
                }
            }

            // 曜日タイトルの作成
            var week = DateListS;
            if (!option.DatePriontChangeFlg)
            {
                week = DateListM;
            }

            foreach (string s in week)
            {
                var weekItem = new WeekItem();
                weekItem.Title = s;
                this.weekItems.Add(weekItem);
            }
        }
    }
}
