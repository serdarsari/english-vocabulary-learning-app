﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishVocabularLearningApp
{
    public partial class kategorifinish : Form
    {
        public kategorifinish()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kategorifinish_Load(object sender, EventArgs e)
        {
            this.Cursor = new Cursor(Application.StartupPath + "\\newcur.cur");
            this.Cursor = Cursor.Current;
        }

        
    }
}
