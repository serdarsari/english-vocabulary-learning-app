using System;
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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        bool okunusu = true;
        bool arkaplanmuzik = true;
        public Form4(bool okunusu,bool arkaplanmuzik)
        {
            this.okunusu = okunusu;
            this.arkaplanmuzik = arkaplanmuzik;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2(okunusu,arkaplanmuzik);
            this.Hide();
            frm2.Show();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.Cursor = new Cursor(Application.StartupPath + "\\newcur.cur");
            this.Cursor = Cursor.Current;
        }
    }
}
