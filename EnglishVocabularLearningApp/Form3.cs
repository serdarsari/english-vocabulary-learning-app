using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace EnglishVocabularLearningApp
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        bool muzikkapa = false;
        public Form3(bool muzikkapa)
        {
            this.muzikkapa = muzikkapa;
            InitializeComponent();
        }
        SoundPlayer soundp = new SoundPlayer(@"backgroundmusic.wav");
        private void button1_Click(object sender, EventArgs e)
        {
            Form form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.Cursor = new Cursor(Application.StartupPath + "\\newcur.cur");
            this.Cursor = Cursor.Current;


            if (!muzikkapa)
            {
                soundp.PlayLooping();
            }
            
        }
        public void MuzikKapa()
        {
            soundp.Stop();
        }
        public void MuzikAc()
        {
            soundp.PlayLooping();
        }

        
    }
}
