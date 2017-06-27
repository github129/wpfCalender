namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;
    using Calender.Entitey;

    /// <summary>
    /// SomeCalenderWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class SomeCalenderWindow : Window
    {

        private Option op = new Option();

        private CalenderData data = new CalenderData();

        private IList<SomeCalenderWindowViewModel> calender = new ObservableCollection<SomeCalenderWindowViewModel>();

        public SomeCalenderWindow()
        {
            this.InitializeComponent();
        }

        public void SomeCalenderControl(DateTime date, int n)
        {
            this.op.CalenderCreateCount = n;
            this.data.Date = date;
            var vm = new SomeCalenderWindowViewModel();
            vm.SetSomeCalender(this.data, this.op);
            this.DataContext = vm;
        }
    }
}
