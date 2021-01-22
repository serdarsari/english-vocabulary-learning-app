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
    public partial class sesayari : Form
    {
        public sesayari()
        {
            InitializeComponent();
        }
        bool sesayarii = true;
        bool arkaplanmuzik = true;
        public sesayari(bool sesayari,bool arkaplanmuzik)
        {
            sesayarii = sesayari;
            this.arkaplanmuzik = arkaplanmuzik;
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            sesayarii = false;
            button1.Visible = false;
            button2.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2(sesayarii,arkaplanmuzik);
            frm2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sesayarii = true;
            button1.Visible = true;
            button2.Visible = false;
        }

        private void sesayari_Load(object sender, EventArgs e)
        {
            this.Cursor = new Cursor(Application.StartupPath + "\\newcur.cur");
            this.Cursor = Cursor.Current;


            if (sesayarii)
            {
                button2.Visible = false;
                button1.Visible = true;
            }
            else
            {
                button1.Visible = false;
                button2.Visible = true;
            }
            if (arkaplanmuzik)
            {
                button4.Visible = false;
                button5.Visible = true;
            }
            else
            {
                button4.Visible = true;
                button5.Visible = false;
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            arkaplanmuzik = true;
            Form3 frm3 = new Form3();
            frm3.MuzikAc();
            button4.Visible = false;
            button5.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            arkaplanmuzik = false;
            Form3 frm3 = new Form3();
            frm3.MuzikKapa();
            button5.Visible = false;
            button4.Visible = true;
        }
        
    }
}
