// <copyright file="MainFrameViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Calender.Entitey;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;

    /// <summary>
    /// カレンダーメインフレーム用VMクラス
    /// </summary>
    public class MainFrameViewModel : ViewModelBase
    {
        /// <summary>
        /// CalenderWindowViewModel情報
        /// </summary>
        private OneCalenderPageControlViewModel calVm;

        /// <summary>
        /// someCalenderWindowViewModel 情報
        /// </summary>
        private SomeCalenderWindowViewModel somVm;

        /// <summary>
        /// カレンダーデータクラス
        /// </summary>
        private CalenderData data;

        /// <summary>
        /// オプションクラス
        /// </summary>
        private Option op;

        /// <summary>
        /// 現在のviewModel情報
        /// </summary>
        private ViewModelBase currentPage;

        /// <summary>
        /// Gets or sets currentPage要のプロパティ
        /// </summary>
        public ViewModelBase CurrentPage
        {
            get
            {
                return this.currentPage;
            }

            set
            {
                if (this.currentPage != value)
                {
                    this.currentPage = value;
                    this.RaisePropertyChanged("CurrentPage");
                }
            }
        }

        /// <summary>
        /// Gets or sets calenderWindowViewModel用のプロパティ
        /// </summary>
        public OneCalenderPageControlViewModel CalVm
        {
            get
            {
                return this.calVm;
            }

            set
            {
                if (this.calVm != value)
                {
                    this.calVm = value;
                    this.RaisePropertyChanged("CalVm");
                }
            }
        }

        /// <summary>
        /// Gets or sets someCalenderWindowViewModel用のプロパティ
        /// </summary>
        public SomeCalenderWindowViewModel SomVm
        {
            get
            {
                return this.somVm;
            }

            set
            {
                if (this.somVm != value)
                {
                    this.somVm = value;
                    this.RaisePropertyChanged("SomVm");
                }
            }
        }

        /// <summary>
        /// Gets or sets オプションクラスを扱うプロパティ
        /// </summary>
        public Option Op
        {
            get { return this.op; }
            set { this.op = value; }
        }

        /// <summary>
        /// Gets or sets カレンダーデータクラスを扱うプロパティ
        /// </summary>
        public CalenderData Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        /// <summary>
        /// VMを作成するmethod
        /// </summary>
        /// <param name="data">カレンダーデータクラス</param>
        /// <param name="op">オプションクラス</param>
        public void CreateControl(CalenderData data, Option op)
        {
            this.data = data;
            this.op = op;
            this.calVm = new OneCalenderPageControlViewModel();
            this.somVm = new SomeCalenderWindowViewModel();
            var vmList = new List<OneCalenderPageControlViewModel>();
            for (var i = 0; i < 12; i++)
            {
                this.calVm = new OneCalenderPageControlViewModel();
                this.calVm.SetOneCalender(this.data, this.op);

                // var imgApi = new ImgAPI();
                // this.calVm.Entity.ImgUrl = imgApi.GetImg();
                vmList.Add(this.calVm);
            }

            vmList[0].Img = "Resources/January.jpg";
            vmList[1].Img = "Resources/February.jpg";
            vmList[2].Img = "Resources/March.jpg";
            vmList[3].Img = "Resources/April.jpg";
            vmList[4].Img = "Resources/May.jpg";
            vmList[5].Img = "Resources/June.jpg";
            vmList[6].Img = "Resources/July.jpg";
            vmList[7].Img = "Resources/August.jpg";
            vmList[8].Img = "Resources/September.jpg";
            vmList[9].Img = "Resources/October.jpg";
            vmList[10].Img = "Resources/November.jpg";
            vmList[11].Img = "Resources/December.jpg";

            this.data.Date = this.data.InputDate;
            this.calVm.Vms = vmList;
            this.somVm.SetSomeCalender(this.data, this.op);
            this.CreatePage(this.calVm, this.somVm);
        }

        /// <summary>
        /// 初めに表示するページの設定
        /// </summary>
        /// <param name="calVm">OneCalenderPageControlViewModel</param>
        /// <param name="somVm">SomeCalenderWindowViewModel</param>
        public void CreatePage(OneCalenderPageControlViewModel calVm, SomeCalenderWindowViewModel somVm)
        {
            this.SomVm = somVm;
            this.CalVm = calVm;
            this.CurrentPage = this.CalVm;
        }

        /// <summary>
        /// VMを登録するメソッド
        /// </summary>
        /// <param name="somVm">SomeCalenderWindowViewModel 1画面に複数表示する</param>
        /// <param name="calVm">OneCalenderPageControlViewModel 1画面に１つ表示する</param>
        public void TogglePageEvent()
        {
            this.TogglePage();
        }

        /// <summary>
        /// 現在のページのVMを切り替えるメソッド
        /// </summary>
        private void TogglePage()
        {
            if (this.CurrentPage is SomeCalenderWindowViewModel)
            {
                this.CalVm.IsWeekChange = SingleCalenderEventControl.Instance.IsWeekChange;
                this.CalVm.IsTodayColor = SingleCalenderEventControl.Instance.IsTodayColor;
                this.CurrentPage = this.CalVm;
            }
            else if (this.CurrentPage is OneCalenderPageControlViewModel)
            {
                this.SomVm.IsWeekChange = SingleCalenderEventControl.Instance.IsWeekChange;
                this.SomVm.IsTodayColor = SingleCalenderEventControl.Instance.IsTodayColor;
                this.CurrentPage = this.SomVm;
            }
        }
    }
}
