namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CreateCalender
    {

        private List<string> calenderDate = new List<string>();

        public List<string> CalenderDate
        {
            get { return this.calenderDate; }
        }

        public CalenderData Create()
        {
            CalenderData date = new CalenderData();
            date.Update();
            return date;
        }

        public List<CalenderData> Date()
        {
            var date = new List<CalenderData>
            {
                new CalenderData { Row = 0, Col = 0, CalenderDate = "日" },
                new CalenderData { Row = 0, Col = 1, CalenderDate = "月" },
                new CalenderData { Row = 0, Col = 2, CalenderDate = "火" },
                new CalenderData { Row = 0, Col = 3, CalenderDate = "水" },
                new CalenderData { Row = 0, Col = 4, CalenderDate = "木" },
                new CalenderData { Row = 0, Col = 5, CalenderDate = "金" },
                new CalenderData { Row = 0, Col = 6, CalenderDate = "土" },
            };

            return date;
        }

        public List<CalenderData> Calender(int lastday, int fastDate)
        {
            int day = 1;
            var calender = new List<CalenderData>();

            for (int r = 1; r < 7; r++)
            {
                if (r == 1)
                {
                    for (int c = fastDate; c < 7; c++)
                    {
                        calender = new List<CalenderData>()
                    {
                        new CalenderData { Row = r, Col = c, Day = day },
                    };
                        day++;
                    }
                }
                else
                {
                    for (int c = fastDate; c < 7; c++)
                    {
                        calender = new List<CalenderData>()
                    {
                        new CalenderData { Row = r, Col = c, Day = day },
                    };
                        day++;
                    }
                }
            }

            return calender;
        }
    }
}
