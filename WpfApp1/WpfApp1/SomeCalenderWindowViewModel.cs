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

    public class SomeCalenderWindowViewModel : CommonCalenderCreate, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private IList<CalenderCreateEntity> calenderEntitys = new ObservableCollection<CalenderCreateEntity>();

        public IList<CalenderCreateEntity> CalenderEntitys
        {
            get
            {
                return this.calenderEntitys;
            }

            set
            {
                if (this.calenderEntitys != value)
                {
                    this.calenderEntitys = value;
                    this.RaisePropertyChanged("CalenderEntitys");
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
        /// <param name="data">カレンダーデータクラス</param>
        /// <param name="op">オプションクラス</param>
        public void SetSomeCalender(CalenderData data, Option op)
        {
            data.Date = data.Date.AddMonths(-1);
            for (int i = 0; i < op.CalenderCreateCount; i++)
            {
                var calEntity = this.SetCalender(data, op);
                this.calenderEntitys.Add(calEntity);
                data.Date = data.Date.AddMonths(1);
            }

            this.ChangeWeekText(op.DatePriontChangeFlg);
            this.ChangeColorTextColor(op.TodayColorChangeFlg);
        }
    }
}

