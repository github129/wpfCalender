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

    public class CalenderWindowViewModel : CommonCalenderCreate
    {

        private CalenderCreateEntity data;

        public CalenderCreateEntity Data
        {
            get { return this.data; }

            set
            {
                if (this.data != value)
                {
                    this.data = value;
                    this.RaisePropertyChanged("Data");
                }
            }
        }

        /// <summary>
        /// カレンダーを作成するメソッド
        /// </summary>
        /// <param name="calData">カレンダーデータクラス</param>
        /// <param name="option">オプションクラス</param>
        public void SetOneCalender(CalenderData calData, Option option)
        {
            this.Data = this.SetCalender(calData,option);
            this.ChangeWeekText(option.DatePriontChangeFlg);
            this.ChangeColorTextColor(option.TodayColorChangeFlg);
        }
    }
}
