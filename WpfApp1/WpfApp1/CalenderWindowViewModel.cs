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

    public class CalenderWindowViewModel :CommonCalenderCreate
    {

        public CalenderCreateEntity Data
        {
            get;set;
        }

        /// <summary>
        /// カレンダーを作成するメソッド
        /// </summary>
        /// <param name="calData">カレンダーデータクラス</param>
        /// <param name="option">オプションクラス</param>
        public void SetOneCalender(CalenderData calData, Option option)
        {
            this.SetCalender(calData,option);
            this.ChangeWeekText(option.DatePriontChangeFlg);
            this.ChangeColorTextColor(option.TodayColorChangeFlg);
        }
    }
}
