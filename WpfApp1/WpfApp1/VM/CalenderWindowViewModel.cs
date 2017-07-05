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
        /// カレンダーを作成するメソッド
        /// </summary>
        /// <param name="calData">カレンダーデータクラス</param>
        /// <param name="option">オプションクラス</param>
        public void SetOneCalender(CalenderData calData, Option option)
        {
            this.Entity = this.SetCalender(calData, option);
            this.ChangeWeekText(option.IsDatePrintChange);
            this.ChangeColorTextColor(option.IsTodayColorChange);
            this.CalenderUpdate += new SomeCalenderEventHandler(this.Entity.DayListUpdate);
            this.CalenderUpdate += new SomeCalenderEventHandler(this.Entity.WeekChange);
            this.TodayColorChenge += new SomeCalenderColorChangeEventHandler(this.Entity.TodayColorChange);
        }

        /// <summary>
        /// カレンダーを上書きする処理
        /// </summary>
        /// <param name="op">オプションクラス</param>
        public void UpdataCalender(Option op)
        {
            this.Args.Option = op;
            this.OnCalenderUpDate(this.Args);
        }

        /// <summary>
        /// 当日の色を変更する処理
        /// </summary>
        /// <param name="op">オプションクラス</param>
        public void ColorChangeEvent(Option op)
        {
            this.Args.Option = op;
            this.OnTodayColorChange(this.Args);
        }
    }
}
