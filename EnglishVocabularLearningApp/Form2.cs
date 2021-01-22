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

    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        bool sesayari = true;
        bool arkaplanmuzik = true;
        public Form2(bool sesayari,bool arkaplanmuzik)
        {
            this.sesayari = sesayari;
            this.arkaplanmuzik = arkaplanmuzik;
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            exitmenu2 exitmenu = new exitmenu2();
            exitmenu.Show();
        }

        
        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            timer1.Enabled = true;
            this.TopMost = true;
            label1.Text = "gundelik";
            
            //Form1 form1 = new Form1(sesayari,arkaplanmuzik);
            //form1.kategori = label1.Text;
            //form1.Show();
            //this.Hide();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            timer1.Enabled = true;
            this.TopMost = true;
            label1.Text = "akademik";
            //Form1 form1 = new Form1(sesayari, arkaplanmuzik);
            //form1.kategori = label1.Text;
            //form1.Show();
            //this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4(sesayari,arkaplanmuzik);
            this.Hide();
            frm4.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            timer1.Enabled = true;
            this.TopMost = true;
            label1.Text = "esyalar";
            //Form1 form1 = new Form1(sesayari, arkaplanmuzik);
            //form1.kategori = label1.Text;
            //form1.Show();
            //this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            timer1.Enabled = true;
            this.TopMost = true;
            label1.Text = "hayvanlar";
            //Form1 form1 = new Form1(sesayari, arkaplanmuzik);
            //form1.kategori = label1.Text;
            //form1.Show();
            //this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            timer1.Enabled = true;
            this.TopMost = true;
            label1.Text = "ulkeler";
            //Form1 form1 = new Form1(sesayari, arkaplanmuzik);
            //form1.kategori = label1.Text;
            //form1.Show();
            //this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            timer1.Enabled = true;
            this.TopMost = true;
            label1.Text = "yiyecekicecek";
            //Form1 form1 = new Form1(sesayari, arkaplanmuzik);
            //form1.kategori = label1.Text;
            //form1.Show();
            //this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5(sesayari,arkaplanmuzik);
            
            frm5.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sesayari ses = new sesayari(sesayari,arkaplanmuzik);
            ses.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        int sayac = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            pictureBox2.Visible = true;
            if (sayac==2)
            {

                Form1 form1 = new Form1(sesayari, arkaplanmuzik);

                form1.kategori = label1.Text;
                form1.Show();
                
            }
            if (sayac==3)
            {
                this.Hide();
                timer1.Enabled = false;
                this.TopMost = false;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Cursor = new Cursor(Application.StartupPath + "\\newcur.cur");
            this.Cursor = Cursor.Current;


            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
        }
    }
}
