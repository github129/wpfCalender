// <copyright file="CalenderEventArgs.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CustomEventArgs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Calender.Entitey;
    using WpfApp1;

    /// <summary>
    /// カスタムArgsクラス
    /// </summary>
    public class CalenderEventArgs : EventArgs
    {
        /// <summary>
        /// オプションクラス
        /// </summary>
        private Option option;

        /// <summary>
        /// カレンダーデータクラス
        /// </summary>
        private CalenderData data;

        /// <summary>
        /// Gets or sets オプションクラスを扱うプロパティ
        /// </summary>
        public Option Option
        {
            get { return this.option; }
            set { this.option = value; }
        }

        /// <summary>
        /// Gets or sets カレンダーデータクラスを扱うプロパティ
        /// </summary>
        public CalenderData Data
        {
            get { return this.data; }
            set { this.data = value; }
        }
    }
}
