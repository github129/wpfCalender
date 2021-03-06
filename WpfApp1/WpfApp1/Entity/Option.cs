﻿// <copyright file="Option.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Calender.Entitey
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// オプションを保持しているクラス
    /// </summary>
    public class Option
    {
        /// <summary>
        /// 曜日の始まり判断用
        /// </summary>
        private bool isDatePrintChange = true;

        /// <summary>
        /// bgColor判断用
        /// </summary>
        private bool isTodayColorChange = true;

        /// <summary>
        /// 入力年月
        /// </summary>
        private DateTime inputDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

        /// <summary>
        /// Gets or sets 入力された年月日
        /// </summary>
        public DateTime InputDate
        {
            get { return this.inputDate; }
            set { this.inputDate = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether 曜日の変更用のプロパティ
        /// </summary>
        public bool IsDatePrintChange
        {
            get { return this.isDatePrintChange; }
            set { this.isDatePrintChange = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether bgColor変更用のプロパティ
        /// </summary>
        public bool IsTodayColorChange
        {
            get { return this.isTodayColorChange; }
            set { this.isTodayColorChange = value; }
        }
    }
}