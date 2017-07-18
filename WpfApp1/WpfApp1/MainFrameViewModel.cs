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
        private CalenderWindowViewModel calVm;

        /// <summary>
        /// someCalenderWindowViewModel 情報
        /// </summary>
        private SomeCalenderWindowViewModel somVm;

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
        public CalenderWindowViewModel CalVm
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
        /// 初めに表示するページの設定
        /// </summary>
        /// <param name="calVm">CalenderWindowViewModel</param>
        public void CreatePage(CalenderWindowViewModel calVm)
        {
            this.CurrentPage = calVm;
        }

        /// <summary>
        /// VMを登録するメソッド
        /// </summary>
        /// <param name="somVm">SomeCalenderWindowViewModel 1画面に複数表示する</param>
        /// <param name="calVm">CalenderWindowViewModel 1画面に１つ表示する</param>
        public void TogglePageEvent(SomeCalenderWindowViewModel somVm, CalenderWindowViewModel calVm)
        {
            this.SomVm = somVm;
            this.CalVm = calVm;
            this.TogglePage();
        }

        /// <summary>
        /// 現在のページのVMを切り替えるメソッド
        /// </summary>
        private void TogglePage()
        {
            if (this.CurrentPage == this.SomVm)
            {
                this.CurrentPage = this.CalVm;
            }
            else if (this.CurrentPage == this.CalVm)
            {
                this.CurrentPage = this.SomVm;
            }
        }
    }
}
