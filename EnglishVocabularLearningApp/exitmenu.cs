﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace EnglishVocabularLearningApp
{
    public partial class exitmenu : Form
    {
        public exitmenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exitmenu_Load(object sender, EventArgs e)
        {
            this.Cursor = new Cursor(Application.StartupPath + "\\newcur.cur");
            this.Cursor = Cursor.Current;

            this.TopMost = true;
        }
    }
}