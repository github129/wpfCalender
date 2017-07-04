// <copyright file="CalenderConverter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CalenderConverter
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Data;

    /// <summary>
    /// コンバータークラス
    /// </summary>
    public class CalenderConverter : IValueConverter
    {
        /// <summary>
        /// 実行メソッド（vm⇒v）
        /// </summary>
        /// <param name="value">bool型</param>
        /// <param name="targetType">Button</param>
        /// <param name="parameter">paramerer</param>
        /// <param name="culture">culture</param>
        /// <returns>Visiblityのパラメーター</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Hidden;
            }

            throw new NotImplementedException();
        }

        /// <summary>
        /// 実行メソッド（v⇒vm）
        /// </summary>
        /// <param name="value">object</param>
        /// <param name="targetType">targetType</param>
        /// <param name="parameter">parameter</param>
        /// <param name="culture">culture</param>
        /// <returns>return</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
