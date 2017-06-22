namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CreateCalender
    {

        private string[] calender = new string[38];

        private string[] calenderDate = { "日", "月", "火", "水", "木", "金", "土" };

        public string[] CalenderDate
        {
            get { return this.calenderDate; }
        }

        public CalenderData Create()
        {
            CalenderData date = new CalenderData();
            date.Update();
            return date;
        }

        public string[] Calender(int lastday, int fastDate)
        {
            int day = 1;
            for (int i = fastDate; i < lastday + fastDate; i++, day++)
            {
                calender[i] = day.ToString();
            }

            return calender;
        }
    }
}
