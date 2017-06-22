namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CreateCalender
    {

        private List<string> calender = new List<string>();

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

        public void Date()
        {
            this.calenderDate.Add("日");
            this.calenderDate.Add("月");
            this.calenderDate.Add("火");
            this.calenderDate.Add("水");
            this.calenderDate.Add("木");
            this.calenderDate.Add("金");
            this.calenderDate.Add("土");
        }

        public List<string> Calender(int lastday, int fastDate)
        {
            int day = 1;
            for (int i = 0; i < lastday + fastDate; i++)
            {
                if (i < fastDate)
                {
                    this.calender.Add(" ");
                    continue;
                }

                this.calender.Add(day.ToString());
                day++;
            }

            return calender;
        }
    }
}
