using Calender.Entitey;
using FlickrAPI;
using System;
using System.Collections.Generic;
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

namespace WpfApp1
{
    /// <summary>
    /// MainFrame.xaml の相互作用ロジック
    /// </summary>
    public partial class MainFrame : Window
    {
        private CalenderData data;

        private Option op;

        private MainFrameViewModel mainFrame = new MainFrameViewModel();

        private CalenderWindowViewModel calVm;

        private SomeCalenderWindowViewModel somVm;

        public MainFrame()
        {
            InitializeComponent();
        }

        public void UserContorol(CalenderData data, Option op)
        {
            this.data = data;
            this.op = op;
            this.calVm = new CalenderWindowViewModel();
            this.somVm = new SomeCalenderWindowViewModel();
            var vmList = new List<CalenderWindowViewModel>();
            for (var i = 0; i < 12; i++)
            {
                this.calVm = new CalenderWindowViewModel();
                this.calVm.SetOneCalender(this.data, this.op);
                //var imgApi = new ImgAPI();
                //this.calVm.Entity.ImgUrl = imgApi.GetImg();
                vmList.Add(this.calVm);
            }
            this.data.Date = this.data.InputDate;
            this.calVm.Vms = vmList;
            this.somVm.SetSomeCalender(this.data, this.op);
            this.mainFrame.CreatePage(calVm);
            this.DataContext = this.calVm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.mainFrame.TogglePageEvent(this.somVm, this.calVm);
        }
    }
}
