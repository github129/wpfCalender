namespace WpfApp1
{
    using System;
    using System.Windows;
    using Calender.Entitey;

    /// <summary>
    /// CalenderMainDesign.xaml の相互作用ロジック
    /// </summary>
    public partial class CalenderMainDesign : Window
    {
        private CalenderData data = new CalenderData();

        public CalenderData Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        public CalenderMainDesign()
        {
            InitializeComponent();
        }

        public void UserContorol(DateTime date)
        {
            this.Data.Date = date;
            var option = new Option();
            var vm = new CalenderWindowViewModel();
            vm.SetOneCalender(this.Data, option);
            this.DataContext = vm;
        }
    }
}
