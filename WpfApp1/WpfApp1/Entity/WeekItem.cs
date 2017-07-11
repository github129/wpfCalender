// <copyright file="WeekItem.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Calender.Entitey
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 曜日情報を扱うクラス
    /// </summary>
    public class WeekItem : INotifyPropertyChanged
    {
        /// <summary>
        /// 曜日
        /// </summary>
        private string title;

        /// <summary>
        /// 横の位置
        /// </summary>
        private int col;

        /// <inheritdoc/>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets 曜日プロパティ
        /// </summary>
        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                if (this.title != value)
                {
                    this.title = value;
                    this.RaisePropertyChanged("Title");
                }
            }
        }

        /// <summary>
        /// Gets or sets 曜日プロパティ
        /// </summary>
        public int Col
        {
            get
            {
                return this.col;
            }

            set
            {
                if (this.col != value)
                {
                    this.col = value;
                    this.RaisePropertyChanged("Col");
                }
            }
        }

        /// <summary>
        /// 情報切り替え用のインターフェース
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        protected void RaisePropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
