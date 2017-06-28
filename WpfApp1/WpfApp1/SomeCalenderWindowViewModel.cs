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

    /// <summary>
    /// カレンダーを複数作るクラス
    /// </summary>
    public class SomeCalenderWindowViewModel : CommonCalenderCreate
    {
        /// <summary>
        /// カレンダー情報を保持しているリスト
        /// </summary>
        private IList<CalenderCreateEntity> calenderEntitys = new ObservableCollection<CalenderCreateEntity>();

        /// <summary>
        /// カレンダーを１年戻すアイコン
        /// </summary>
        private string goBackYearIcon = "Visible";

        /// <summary>
        /// カレンダーを１年進めるアイコン
        /// </summary>
        private string goNextYearIcon = "Visible";

        /// <summary>
        /// Gets or sets カレンダー用のアイコンを扱うプロパティ
        /// </summary>
        public string GoBackYearIcon
        {
            get
            {
                return this.goBackYearIcon;
            }

            set
            {
                if (this.goBackYearIcon != value)
                {
                    this.goBackYearIcon = value;
                    this.RaisePropertyChanged("GoBackYearIcon");
                }
            }
        }

        /// <summary>
        /// Gets or sets カレンダー用のアイコンを扱うプロパティ
        /// </summary>
        public string GoNextYearIcon
        {
            get
            {
                return this.goNextYearIcon;
            }

            set
            {
                if (this.goNextYearIcon != value)
                {
                    this.goNextYearIcon = value;
                    this.RaisePropertyChanged("GoNextYearIcon");
                }
            }
        }

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
        /// カレンダーを作成するメソッド
        /// </summary>
        /// <param name="data">カレンダーデータクラス</param>
        /// <param name="op">オプションクラス</param>
        public void SetSomeCalender(CalenderData data, Option op)
        {
            data.Date = data.Date.AddMonths(-1);
            for (int i = 0; i < op.CalenderCreateCount; i++)
            {
                var calEntity = this.SetCalender(data, op);
                this.calenderEntitys.Add(calEntity);
                data.Date = data.Date.AddMonths(1);
            }

            this.ChangeWeekText(op.DatePriontChangeFlg);
            this.ChangeColorTextColor(op.TodayColorChangeFlg);
            this.ChangeFilter(data.InputDate, data.Date);
        }

        /// <summary>
        /// 指定された年度のみを表示するためのフィルタ
        /// </summary>
        /// <param name="date">Datetime 指定年月日</param>
        /// <param name="bifoDate">Datetime 更新前の年月日</param>
        public void ChangeFilter(DateTime date,DateTime bifoDate)
        {
            var collectionView = CollectionViewSource.GetDefaultView(this.calenderEntitys);
            collectionView.Filter = (x) =>
            {
                var nowYear = (CalenderCreateEntity)x;
                return nowYear.Date.Year == date.Year;
            };

            this.GoNextYearIcon = "Visible";
            this.GoBackYearIcon = "Visible";

            if (collectionView.IsEmpty)
            {
                if (date < bifoDate)
                {
                    this.GoNextYearIcon = "Visible";
                    this.GoBackYearIcon = "Hidden";
                }
                else
                {
                    this.GoNextYearIcon = "Hidden";
                    this.GoBackYearIcon = "Visible";
                }
            }
        }
    }
}