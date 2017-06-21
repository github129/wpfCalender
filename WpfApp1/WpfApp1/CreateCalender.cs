namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CreateCalender
    {

        private string[,] calender = new string[7, 7];

        public CalenderData Create()
        {
            CalenderData date = new CalenderData();
            date.Update();
            return date;
        }

        public string[,] Calender(int lastday, int fastDate)
        {
            int day = 1;
            for (int y = 0; y < 7; y++)
            {
                for (int x =0; x < 7; x++)
                {
                    if (day > lastday)
                    {
                        break;
                    }
                    calender[y, x] = day.ToString();
                    day++;
                }
            }

            return calender;
        }
    }
}
