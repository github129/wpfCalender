namespace WpfApp1
{
    using Calender.Entitey;
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
    using System.Windows.Navigation;
    using System.Windows.Shapes;

    /// <summary>
    /// SomeCalenderPageControl.xaml の相互作用ロジック
    /// </summary>
    public partial class SomeCalenderPageControl : UserControl
    {
        /// <summary>
        /// SomeCalenderWindowViewModelクラス
        /// </summary>
        private SomeCalenderWindowViewModel vm = new SomeCalenderWindowViewModel();

        /// <summary>
        /// オプションクラス
        /// </summary>
        private Option op = new Option();

        /// <summary>
        /// カレンダーデータクラス
        /// </summary>
        private CalenderData data = new CalenderData();

        /// <summary>
        /// SomeCalenderWindowViewModelクラスが入ったリスト
        /// </summary>
        private IList<SomeCalenderWindowViewModel> calender = new ObservableCollection<SomeCalenderWindowViewModel>();

        public SomeCalenderPageControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 前年に戻るイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">イベント情報</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.vm.BackYearCount--;
            this.vm.NextYearCount++;
            this.data.UpDataDate = this.data.UpDataDate.AddYears(-1);
            this.vm.ChangeFilter(this.data);
        }

        /// <summary>
        /// 来年に進むイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">イベント情報</param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.vm.BackYearCount++;
            this.vm.NextYearCount--;
            this.data.UpDataDate = this.data.UpDataDate.AddYears(1);
            this.vm.ChangeFilter(this.data);
        }

        /// <summary>
        /// 始まりの曜日を変えるイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">イベント情報</param>
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)this.weekChangeCheck.IsChecked)
            {
                this.op.IsDatePrintChange = false;
            }
            else
            {
                this.op.IsDatePrintChange = true;
            }

            this.data.Date = this.data.InputDate.AddMonths(-1);
            ((SomeCalenderWindowViewModel)this.DataContext).UpdataCalender(this.op);
        }

        /// <summary>
        /// 当日のカラーを変更するイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">イベント情報</param>
        private void TodayColorChange_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)this.TodayColorChange.IsChecked)
            {
                this.op.IsTodayColorChange = false;
            }
            else
            {
                this.op.IsTodayColorChange = true;
            }
            this.data.Date = this.data.InputDate.AddMonths(-1);
            ((SomeCalenderWindowViewModel)this.DataContext).ColorChangeEvent(this.op);
        }
    }
}
