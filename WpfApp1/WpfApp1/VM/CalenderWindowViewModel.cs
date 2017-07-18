// <copyright file="CalenderWindowViewModel.cs" company="PlaceholderCompany">
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
    /// カレンダーの処理をするVMクラス
    /// </summary>
    public class CalenderWindowViewModel : CommonCalenderCreate
    {
        /// <summary>
        /// カレンダーの情報クラス
        /// </summary>
        private CalenderCreateEntity entity;

        private IList<CalenderWindowViewModel> vms = new ObservableCollection<CalenderWindowViewModel>();

        /// <summary>
        /// Gets or sets カレンダー情報プロパティ
        /// </summary>
        public CalenderCreateEntity Entity
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
        public IList<CalenderWindowViewModel> Vms
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
        /// カレンダーを作成するメソッド
        /// </summary>
        /// <param name="calData">カレンダーデータクラス</param>
        /// <param name="option">オプションクラス</param>
        public void SetOneCalender(CalenderData calData, Option option)
        {
            this.Entity = this.SetCalender(calData, option);
            this.ChangeWeekText(option.IsDatePrintChange);
            this.ChangeColorTextColor(option.IsTodayColorChange);
            this.Entity.UpdateEvent();
            calData.Date = calData.Date.AddMonths(1);
        }

        public void FarstCreate()
        {
            this.Vms = new ObservableCollection<CalenderWindowViewModel>();
        }

        /// <summary>
        /// カレンダーを上書きする処理
        /// </summary>
        /// <param name="op">オプションクラス</param>
        public void UpdataCalender(Option op)
        {
            this.Args.Option = op;
            this.Entity.OnCalenderUpDate(this.Args);
        }

        /// <summary>
        /// 当日の色を変更する処理
        /// </summary>
        /// <param name="op">オプションクラス</param>
        public void ColorChangeEvent(Option op)
        {
            this.Args.Option = op;
            this.Entity.OnTodayColorChange(this.Args);
        }
    }
}
