namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MainWindowData : INotifyPropertyChanged
    {

        private int month;

        public int Month
        {
            get
            {
                return this.month;
            }

            set
            {
                if (this.month != value)
                {
                    this.month = value;
                    this.RaisePropertyChanged("Month");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// プロパティを書き換変わったかどうかを判断するメソッド
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        protected void RaisePropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
