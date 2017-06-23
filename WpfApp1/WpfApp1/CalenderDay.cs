// <copyright file="CalenderDay.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// カレンダーの日付を使うクラス
    /// </summary>
    public class CalenderDay
    {
        /// <summary>
        /// Gets or sets grid coulm
        /// </summary>
        public int Col { get; set; }

        /// <summary>
        /// Gets or sets grid Row
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// Gets or sets 日付
        /// </summary>
        public string Day { get; set; }
    }
}
