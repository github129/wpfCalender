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
        /// 曜日始まりのラベル
        /// </summary>
        private string startText = "日曜始まり";

        private string changeTextColor = "Khaki";

        /// <summary>
        /// インターフェースの実行
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
                if (this.weekItems != value)
                {
                    this.weekItems = value;
                    this.RaisePropertyChanged("CalenderWeekItems");
                }
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
                if (this.date != value)
                {
                    this.date = value;
                    this.RaisePropertyChanged("Date");
                }
            }
        }

        /// <summary>
        /// Gets or sets ラベル
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

        public string ChangeTextColor
        {
            get
            {
                return this.changeTextColor;
            }

            set
            {
                if (this.changeTextColor != value)
                {
                    this.changeTextColor = value;
                    this.RaisePropertyChanged("ChangeTextColor");
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
            var sunColorNumber = 0;
            var satColorNumber = 6;
            if (!option.DatePriontChangeFlg && col > 0)
            {
                col--;
                sunColorNumber = 6;
                satColorNumber--;
            }
            else if (!option.DatePriontChangeFlg && col == 0)
            {
                col = 6;
                sunColorNumber = 6;
                satColorNumber--;
            }

            var row = 0;
            for (var i = 0; i < calData.CalenderLastDay; i++)
            {
                var day = new CalenderDay();
                day.Day = (i + 1).ToString();
                day.Row = row;
                day.Col = col;

                // 曜日の色を変える処理
                if (col == sunColorNumber)
                {
                    day.ForeColor = "red";
                    day.BgColor = "Tomato";
                }
                else if (col == satColorNumber)
                {
                    day.ForeColor = "SlateBlue";
                    day.BgColor = "SkyBlue";
                }

                // 当日かどうかの判断
                if (option.TodayColorChangeFlg && i == DateTime.Now.Day && calData.Date.Year == DateTime.Now.Year && calData.Date.Month == DateTime.Now.Month)
                {
                    day.BgColor = "Khaki";
                }

                this.dayList.Add(day);
                col++;
                if (col > 6)
                {
                    row++;
                    col = 0;
                }
            }

            if (option.TodayColorChangeFlg)
            {
                this.ChangeTextColor = "Khaki";
            }
            else
            {
                this.ChangeTextColor = "Black";
            }

            // 曜日タイトルの作成
            var week = DateListS;
            if (!option.DatePriontChangeFlg)
            {
                week = DateListM;
                this.StartText = "月曜始まり";
            }
            else
            {
                this.StartText = "日曜始まり";
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
