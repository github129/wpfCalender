﻿namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {

        public string Id { get; set; }

        private string[] listbox;

        public string[] ListBox
        {
            get { return listbox; }
            set { this.listbox = value; }
        }

    }
}