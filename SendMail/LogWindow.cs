﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendMail
{
    public partial class LogWindow : Form
    {
        public LogWindow()
        {
            InitializeComponent();

            
        }

        private void LogTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        public void UpdateLog(string log)
        {
            logTextBox.Text = log;
        }
    }
}
