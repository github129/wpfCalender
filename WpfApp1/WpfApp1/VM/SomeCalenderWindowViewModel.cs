// <copyright file="SomeCalenderWindowViewModel.cs" company="PlaceholderCompany">
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
    using System.Windows.Data;
    using Calender.Entitey;
    using CustomEventArgs;

    /// <summary>
    /// カレンダーを複数作るクラス
    /// </summary>
    public class SomeCalenderWindowViewModel : CommonCalenderCreate
    {
        private bool isTodayColor = true;

        private bool isWeekChange = true;

        /// <summary>
        /// カレンダー情報を保持しているリスト
        /// </summary>
        private IList<CalenderCreateEntity> calenderEntitys = new ObservableCollection<CalenderCreateEntity>();

        /// <summary>
        /// Gets or sets カレンダー情報用のプロパティ
        /// </summary>
        public IList<CalenderCreateEntity> CalenderEntitys
        {
            get
            {
                return this.calenderEntitys;
            }

            set
            {
                if (this.calenderEntitys != value)
                {
                    this.calenderEntitys = value;
                    this.RaisePropertyChanged("CalenderEntitys");
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

        public Option Op
        {
            get; set;
        }

        public CalenderData Data
        {
            get; set;
        }

        /// <summary>
        /// カレンダー情報を初めて作るときの処理
        /// </summary>
        /// <param name="data">カレンダーデータクラス</param>
        /// <param name="op">オプションクラス</param>
        public void CalenderEntitysNew(CalenderData data, Option op)
        {
            this.CalenderEntitys = new ObservableCollection<CalenderCreateEntity>();
            this.SetSomeCalender(data, op);
        }

        /// <summary>
        /// カレンダーを作成するメソッド
        /// </summary>
        /// <param name="data">カレンダーデータクラス</param>
        /// <param name="op">オプションクラス</param>
        public void SetSomeCalender(CalenderData data, Option op)
        {
            this.Op = op;
            for (int i = 0; i < op.CalenderCreateCount; i++)
            {
                var calEntity = this.SetCalender(data, op);
                calEntity.UpdateEvent();
                this.calenderEntitys.Add(calEntity);
                data.Date = data.Date.AddMonths(1);
            }

            this.ChangeWeekText(op.IsDatePrintChange);
            this.ChangeColorTextColor(op.IsTodayColorChange);
        }

    }
}