namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class UserInput
    {

        public void UpdateDate(string year, string date)
        {
            CalenderData data = new CalenderData();
            DateTime dt = new DateTime(int.Parse(year), int.Parse(date), 1);
            data.Date = dt;
        }
    }
}
