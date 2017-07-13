// <copyright file="MainWindowViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Calender.Entitey;

    /// <summary>
    /// MainWindowのVMクラス
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// 日付
        /// </summary>
        private DateTime date;

        /// <summary>
        /// 入力年
        /// </summary>
        private string inputYear = DateTime.Now.Year.ToString();

        /// <summary>
        /// 入力月
        /// </summary>
        private int inputMonth = DateTime.Now.Month;

        /// <summary>
        /// カレンダーの作成数
        /// </summary>
        private string makeCalenderCount = "1";

        /// <inheritdoc/>
        public event PropertyChangedEventHandler PropertyChanged;

        private IList<MainWindowData> mainDataList = new ObservableCollection<MainWindowData>();

        /// <summary>
        /// Gets or sets 年月日を扱うプロパティ
        /// </summary>
        public DateTime Date
        {
            get
            {
                return this.date;
            }

            set
            {
                if (this.date != value)
                {
                    this.date = value;
                    this.RaisePropertyChanged("Date");
                }
            }
        }

        /// <summary>
        /// Gets or sets 入力年用のプロパティ
        /// </summary>
        public string InputYear
        {
            get
            {
                return this.inputYear;
            }

            set
            {
                if (this.inputYear != value)
                {
                    this.inputYear = value;
                    this.RaisePropertyChanged("InputYear");
                }
            }
        }

        /// <summary>
        /// Gets or sets 入力月用のプロパティ
        /// </summary>
        public int InputMonth
        {
            get
            {
                return this.inputMonth;
            }

            set
            {
                if (this.inputMonth != value)
                {
                    this.inputMonth = value;
                    this.RaisePropertyChanged("InputMonth");
                }
            }
        }

        /// <summary>
        /// Gets or sets カレンダーを作成する個数
        /// </summary>
        public string MakeCalenderCount
        {
            get
            {
                return this.makeCalenderCount;
            }

            set
            {
                if (this.makeCalenderCount != value)
                {
                    this.makeCalenderCount = value;
                    this.RaisePropertyChanged("MakeCalenderCount");
                }
            }
        }

        /// <summary>
        /// メインデータクラスを扱うプロパティ
        /// </summary>
        public IList<MainWindowData> MainDataList
        {
            get { return this.mainDataList; }
            set { this.mainDataList = value; }
        }

        /// <summary>
        /// 検索ボタンが押されたときのイベント処理メソッド
        /// </summary>
        /// <param name="data">カレンダーデータクラス</param>
        public void SearchButtonPushEvent(CalenderData data)
        {
            var op = new Option();
            var inputCreateountFlg = true;
            var window = new CalenderMainDesign();
            var someWindow = new SomeCalenderWindow();

            // 年の確認
            if (this.InputYear.Length == 0)
            {
                this.InputYear = DateTime.Now.Year.ToString();
            }

            this.inputMonth = 1;
            op.CalenderCreateCount = 1;
            //// 作成個数の確認
            // if (this.MakeCalenderCount.Length == 0 && this.InputYear.Length == 0)
            // {
            //    inputCreateountFlg = false;
            //    op.CalenderCreateCount = 1;
            // }
            // else if (this.MakeCalenderCount.Length == 0 && this.InputYear.Length > 0 && this.InputMonth == 0)
            // {
            //    inputCreateountFlg = false;
            //    op.CalenderCreateCount = 12;
            // }
            // else if (this.MakeCalenderCount.Length > 0)
            // {
            //    op.CalenderCreateCount = int.Parse(this.MakeCalenderCount);
            // }

            //// 月の確認
            // if (this.InputMonth == 0 && this.InputYear.Length == 0)
            // {
            //    this.InputMonth = DateTime.Now.Month;
            // }
            // else if (this.InputMonth == 0 && this.InputYear.Length != 0 && this.MakeCalenderCount.Length == 0)
            // {
            //    this.InputMonth = 1;
            // }

            this.Date = new DateTime(int.Parse(this.InputYear), this.InputMonth , 1);

            if (op.CalenderCreateCount > 1)
            {
                someWindow.SomeCalenderControl(this.Date, op.CalenderCreateCount, inputCreateountFlg);
                someWindow.Show();
            }
            else
            {
                window.UserContorol(this.Date);
                window.Show();
            }
        }

        /// <summary>
        /// 月のcombobox作成用
        /// </summary>
        public void MonthListCreate()
        {
            for (var i = 0; i < 12; i++)
            {
                var mainData = new MainWindowData();
                mainData.Month = i + 1;
                this.MainDataList.Add(mainData);
            }
        }

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
