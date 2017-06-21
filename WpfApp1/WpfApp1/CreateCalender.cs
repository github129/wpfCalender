namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CreateCalender
    {

        private string[][] calender = new string[7][];

        private string[] calenderX = new string[7];

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

        public string[][] Calender(int lastday, int fastDate)
        {
            int day = 1;
            for (int y = 0; y < 7; y++)
            {
                if (y == 0)
                {
                    for (int x = fastDate; x < 7; x++, day++)
                    {
                        calenderX[x] = day.ToString();
                    }
                }
                else
                {
                    for (int x = 0; x < 7; x++, day++)
                    {
                        if (day > lastday)
                        {
                            break;
                        }
                        calenderX[x] = day.ToString();
                    }
                }
                calender[y] = calenderX;
                calenderX = new string[7];

            }

            return calender;
        }
    }
}
