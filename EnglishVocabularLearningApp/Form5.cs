using System;
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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        bool okunusu = true;
        bool arkaplanmuzik = true;
        public Form5(bool okunusu,bool arkaplanmuzik)
        {
            this.okunusu = okunusu;
            this.arkaplanmuzik = arkaplanmuzik;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2(okunusu,arkaplanmuzik);
            
            frm2.Show();
            this.Hide();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.Cursor = new Cursor(Application.StartupPath + "\\newcur.cur");
            this.Cursor = Cursor.Current;
        }

        
    }
}
