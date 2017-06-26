namespace WpfApp1
{
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
    using Calender.Entitey;

    /// <summary>
    /// CalenderWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class CalenderWindow : Window
    {
        public CalenderWindow()
        {
            InitializeComponent();
        }

        public void UserContorol(MainWindowViewModel mainVm)
        {
            var calD = new CalenderData();
            calD.Date = mainVm.Date;
            var option = new Option();
            var calVm = new CalenderWindowViewModel();
            calVm.SetCalender(calD, option);
            this.DataContext = calVm;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var op = new Option();
            CalenderData c = new CalenderData();
            if ((bool)this.weekChangeCheck.IsChecked)
            {
                op.DatePriontChangeFlg = false;
                this.aaa.Text = "false";
            }
            else
            {
                op.DatePriontChangeFlg = true;
                this.aaa.Text = "true";
            }

            ((CalenderWindowViewModel)this.DataContext).SetCalender( c,op);
        }
    }
}
