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
    using System.Windows.Navigation;
    using System.Windows.Shapes;

    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.UserContorol();
        }

        private void UserContorol()
        {
            var create = new CreateCalender();
            var data = create.Create();
            string[] cal = create.Calender(data.CalenderLastDay, data.FastDate);
            string[] date = create.CalenderDate;

            string[] calender = date.Concat(cal).ToArray();

            this.DataContext = data;

            this.listBox.ItemsSource = calender;

        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }
    }
}
