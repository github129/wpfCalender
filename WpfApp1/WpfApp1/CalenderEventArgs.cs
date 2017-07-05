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
        public Option option;

        public CalenderData data;

        public IList<DateTime> dateTimes = new List<DateTime>();

        public int listNumber;
    }
}
