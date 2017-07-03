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
        private IList<CalenderCreateEntity> calenderEntitys;

        /// <summary>
        /// カレンダーを１年戻すアイコン
        /// </summary>
        private bool goBackYearIcon = true;

        /// <summary>
        /// goBackYearIconの表示用アイコン
        /// 0なら表示させない
        /// </summary>
        private int backYearCount;

        /// <summary>
        /// カレンダーを１年進めるアイコン
        /// </summary>
        private bool goNextYearIcon = true;

        /// <summary>
        /// goNextYearIconの表示用カウント
        /// ０なら表示させない
        /// </summary>
        private int nextYearCount;

        /// <summary>
        /// カレンダー上部の年テキスト
        /// </summary>
        private DateTime topDateText;

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets カレンダー用のアイコンを扱うプロパティ
        /// </summary>
        public bool GoBackYearIcon
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
        /// Gets or sets a value indicating whether gets or sets カレンダー用のアイコンを扱うプロパティ
        /// </summary>
        public bool GoNextYearIcon
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
        /// Gets or sets カレンダー上部のテキストを扱うプロパティ
        /// </summary>
        public DateTime TopDateText
        {
            get
            {
                return this.topDateText;
            }

            set
            {
                if (this.topDateText != value)
                {
                    this.topDateText = value;
                    this.RaisePropertyChanged("TopDateText");
                }
            }
        }

        /// <summary>
        /// Gets or sets 前年に移動できる回数を扱うプロパティ
        /// </summary>
        public int BackYearCount
        {
            get { return this.backYearCount; }
            set { this.backYearCount = value; }
        }

        /// <summary>
        /// Gets or sets 来年移動できる回数を扱うプロパティ
        /// </summary>
        public int NextYearCount
        {
            get { return this.nextYearCount; }
            set { this.nextYearCount = value; }
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
            this.BackYearCount = 1;
            this.NextYearCount = 0;
            for (int i = 0; i < op.CalenderCreateCount; i++)
            {
                var calEntity = this.SetCalender(data, op);
                this.calenderEntitys.Add(calEntity);
                data.Date = data.Date.AddMonths(1);
            }

            this.ChangeWeekText(op.DatePriontChangeFlg);
            this.ChangeColorTextColor(op.TodayColorChangeFlg);

            // カレンダーの年を移動するアイコン表示の確認
            if (data.InputDate.Month > 1 || !op.InputCreateountFlg)
            {
                this.GoBackYearIcon = false;
                this.BackYearCount--;
            }

            // nextYearCountの計算
            var nowYearCount = this.CalenderEntitys.Count - (12 - data.InputDate.AddMonths(-1).Month + 1);
            if (data.InputDate.AddMonths(op.CalenderCreateCount - 1).Year > data.InputDate.Year)
            {
                for (; nowYearCount > 0; this.NextYearCount++)
                {
                    nowYearCount -= 12;
                }
            }

            if (this.NextYearCount < 1)
            {
                this.GoNextYearIcon = false;
            }

            this.ChangeFilter(data);
        }

        /// <summary>
        /// カレンダーを上書きする処理
        /// </summary>
        /// <param name="data">カレンダーデータクラス</param>
        /// <param name="op">オプションクラス</param>
        public void UpdataCalender(CalenderData data, Option op)
        {
            for (int i = 0; i < op.CalenderCreateCount; i++)
            {
                this.CalenderEntitys[i] = this.SetCalender(data, op);
                data.Date = data.Date.AddMonths(1);
            }
        }

        /// <summary>
        /// 指定された年度のみを表示するためのフィルタ
        /// </summary>
        /// <param name="date">Datetime 入力情報を「+-1」年した年月日</param>
        public void ChangeFilter(CalenderData data)
        {
            data.UpDataDate = data.UpDataDate;
            if (this.BackYearCount > 0)
            {
                this.GoBackYearIcon = true;
            }
            else
            {
                this.GoBackYearIcon = false;
            }

            if (this.NextYearCount > 0)
            {
                this.GoNextYearIcon = true;
            }
            else
            {
                this.GoNextYearIcon = false;
            }

            this.TopDateText = data.UpDataDate;
            var collectionView = CollectionViewSource.GetDefaultView(this.calenderEntitys);
            collectionView.Filter = (x) =>
            {
                var nowYear = (CalenderCreateEntity)x;
                return nowYear.Date.Year == data.UpDataDate.Year;
            };
        }
    }
}