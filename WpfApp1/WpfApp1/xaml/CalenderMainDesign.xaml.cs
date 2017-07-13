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

        private Option op = new Option();

        public CalenderData Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        public Option Op
        {
            get { return this.op; }
            set { this.op = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CalenderMainDesign"/> class.
        /// 初期化処理
        /// </summary>
        public CalenderMainDesign()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 実行メソッド
        /// </summary>
        /// <param name="date">DaateTime　入力された年月日</param>
        public void UserContorol(DateTime date)
        {
            this.Data.Date = date;
            this.op = new Option();
            var vm = new CalenderWindowViewModel();
            vm.SetOneCalender(this.Data, op);
            this.DataContext = vm;
        }

        /// <summary>
        /// 曜日の始まり選択クリック時の処理
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">イベントデータ</param>
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)this.weekChangeCheck.IsChecked)
            {
                this.Op.IsDatePrintChange = false;
            }
            else
            {
                this.Op.IsDatePrintChange = true;
            }

            ((CalenderWindowViewModel)this.DataContext).UpdataCalender(this.op);
        }

        /// <summary>
        /// 当日の背景色選択時の処理
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">イベントデータ</param>
        private void TodayColorChange_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)this.TodayColorChange.IsChecked)
            {
                this.Op.IsTodayColorChange = false;
            }
            else
            {
                this.Op.IsTodayColorChange = true;
            }

            ((CalenderWindowViewModel)this.DataContext).ColorChangeEvent(this.op);
        }
    }
}
