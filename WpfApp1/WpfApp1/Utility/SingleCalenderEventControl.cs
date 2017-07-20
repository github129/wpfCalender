// <copyright file="SingleCalenderEventControl.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Calender.Entitey;
    using CustomEventArgs;

    /// <summary>
    /// イベントハンドラーの設定
    /// </summary>
    /// <param name="sender">クラス情報</param>
    /// <param name="e">イベント情報</param>
    public delegate void SomeCalenderEventHandler(object sender, CalenderEventArgs e);

    /// <summary>
    /// イベントハンドラーの設定
    /// </summary>
    /// <param name="sender">呼び出し元のクラス</param>
    /// <param name="e">イベント情報</param>
    public delegate void SomeCalenderColorChangeEventHandler(object sender, CalenderEventArgs e);

    /// <summary>
    /// カレンダーのイベントを扱うクラス
    /// </summary>
    public class SingleCalenderEventControl
    {
        /// <summary>
        /// このクラスのインスタンス
        /// </summary>
        private static SingleCalenderEventControl instance = new SingleCalenderEventControl();

        /// <summary>
        /// EventArgsクラス
        /// </summary>
        private CalenderEventArgs args = new CalenderEventArgs();

        /// <summary>
        /// 当日色変更がチェック済みかの判断
        /// </summary>
        private bool isTodayColor = true;

        /// <summary>
        /// 開始曜日が変更済みかの判断
        /// </summary>
        private bool isWeekChange = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="SingleCalenderEventControl"/> class.
        /// シングルトン
        /// </summary>
        private SingleCalenderEventControl()
        {
        }

        /// <summary>
        /// 日付更新イベント
        /// </summary>
        public event SomeCalenderEventHandler CalenderUpdate;

        /// <summary>
        /// 当日の色更新イベント
        /// </summary>
        public event SomeCalenderColorChangeEventHandler TodayColorChenge;

        /// <summary>
        /// Gets インスタンスを扱うプロパティ
        /// </summary>
        public static SingleCalenderEventControl Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// Gets or sets argsを扱うプロパティ
        /// </summary>
        public CalenderEventArgs Args
        {
            get { return this.args; }
            set { this.args = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether 当日色判断用のプロパティ
        /// </summary>
        public bool IsTodayColor
        {
            get { return this.isTodayColor; }
            set { this.isTodayColor = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether 開始曜日判断用のプロパティ
        /// </summary>
        public bool IsWeekChange
        {
            get { return this.isWeekChange; }
            set { this.isWeekChange = value; }
        }

        /// <summary>
        /// 日付更新イベント起動
        /// </summary>
        /// <param name="e">イベント情報</param>
        public virtual void OnCalenderUpDate(CalenderEventArgs e)
        {
            if (this.CalenderUpdate != null)
            {
                this.CalenderUpdate(this, e);
            }
        }

        /// <summary>
        /// 当日の背景色更新イベント起動
        /// </summary>
        /// <param name="e">イベント情報</param>
        public virtual void OnTodayColorChange(CalenderEventArgs e)
        {
            if (this.TodayColorChenge != null)
            {
                this.TodayColorChenge(this, e);
            }
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
