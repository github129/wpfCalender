// <copyright file="OneCalenderPageControlViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Calender.Entitey;

    /// <summary>
    /// カレンダーの処理をするVMクラス
    /// </summary>
    public class OneCalenderPageControlViewModel : CommonCalenderCreate
    {
        /// <summary>
        /// カレンダーの情報クラス
        /// </summary>
        private CalenderCreateEntity entity;

        /// <summary>
        /// 画像のpath
        /// </summary>
        private string img;

        /// <summary>
        /// 当日色変更の判断
        /// </summary>
        private bool isTodayColor = true;

        /// <summary>
        /// 週開始の曜日変更の判断
        /// </summary>
        private bool isWeekChange = true;

        /// <summary>
        /// OneCalenderPageControlViewModelのリスト
        /// </summary>
        private IList<OneCalenderPageControlViewModel> vms = new ObservableCollection<OneCalenderPageControlViewModel>();

        /// <summary>
        /// Gets or sets カレンダー情報プロパティ
        /// </summary>
        public new CalenderCreateEntity Entity
        {
            get
            {
                return this.entity;
            }

            set
            {
                if (this.entity != value)
                {
                    this.entity = value;
                    this.RaisePropertyChanged("Entity");
                }
            }
        }

        /// <summary>
        /// Gets or sets カレンダー情報プロパティ
        /// </summary>
        public IList<OneCalenderPageControlViewModel> Vms
        {
            get
            {
                return this.vms;
            }

            set
            {
                if (this.vms != value)
                {
                    this.vms = value;
                    this.RaisePropertyChanged("Vms");
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets 当日の色を扱うプロパティ
        /// </summary>
        public bool IsTodayColor
        {
            get
            {
                return this.isTodayColor;
            }

            set
            {
                if (this.isTodayColor != value)
                {
                    this.isTodayColor = value;
                    this.RaisePropertyChanged("IsTodayColor");
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets 週始まりの曜日を扱うプロパティ
        /// </summary>
        public bool IsWeekChange
        {
            get
            {
                return this.isWeekChange;
            }

            set
            {
                if (this.isWeekChange != value)
                {
                    this.isWeekChange = value;
                    this.RaisePropertyChanged("IsWeekChange");
                }
            }
        }

        /// <summary>
        /// Sets imgを扱うプロパティ
        /// </summary>
        public string Img
        {
            private get
            {
                return this.img;
            }

            set
            {
                this.img = value;
            }
        }

        /// <summary>
        /// カレンダーを作成するメソッド
        /// </summary>
        /// <param name="calData">カレンダーデータクラス</param>
        /// <param name="option">オプションクラス</param>
        public void SetOneCalender(CalenderData calData, Option option)
        {
            this.Entity = this.SetCalender(calData, option);
            this.ChangeWeekText(option.IsDatePrintChange);
            this.ChangeColorTextColor(option.IsTodayColorChange);
            calData.Date = calData.Date.AddMonths(1);
        }

        /// <summary>
        /// 最初に作る時の処理
        /// </summary>
        public void FarstCreate()
        {
            this.Vms = new ObservableCollection<OneCalenderPageControlViewModel>();
        }
    }
}
