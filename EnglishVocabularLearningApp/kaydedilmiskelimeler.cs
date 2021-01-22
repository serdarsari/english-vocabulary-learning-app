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
using System.Globalization;

namespace EnglishVocabularLearningApp
{
    public partial class kaydedilmiskelimeler : Form
    {
        public kaydedilmiskelimeler()
        {
            InitializeComponent();
        }
        public int elemansayisi;

        public void ElemanKontrol()
        {
            elemansayisi = listBox1.Items.Count;
        }
        public void ElemanVar()
        {
            label1.Visible = false;
            listBox1.Visible = true;
            listBox2.Visible = true;
        }
        public void ElemanYok()
        {
            label1.Visible = true;
            listBox1.Visible = false;
            listBox2.Visible = false;
        }
        bool ulkeisimleri = false;
        public void UlkeIsımleri(bool girdi)
        {
            ulkeisimleri = girdi;
        }
        public bool kontrol = false;

        public bool kirksekizoldu = false;

        CultureInfo ci = new CultureInfo("tr-TR", false);
        public void KelimeEkle(string eng,string tr)
        {
            
            if (listBox3.Items.Count+listBox1.Items.Count!=48)
            {
                if (listBox1.Items.Count != 24 && listBox1.Items.Count < 24)
                {
                    yirmidortoldu = false;
                    if (!listBox1.Items.Contains(eng))
                    {
                        listBox1.Items.Add(eng);
                        if (ulkeisimleri)
                        {
                            listBox2.Items.Add(ci.TextInfo.ToTitleCase(tr));    //burada baş harflerni büyütüyorum ülkelerin... büyük i ingilizcede olmadığı için bu şekilde hallettim.
                        }
                        else
                        {
                            listBox2.Items.Add(tr);
                        }
                        
                        kontrol = false;
                    }
                    else
                    {
                        kontrol = true;
                    }
                }

                if (listBox1.Items.Count >= 24&&listBox3.Items.Count<24)
                {
                    yirmidortoldu = true;
                    if (!listBox3.Items.Contains(eng))
                    {
                        listBox3.Items.Add(eng);
                        if (ulkeisimleri)
                        {
                            listBox2.Items.Add(ci.TextInfo.ToTitleCase(tr));
                        }
                        else
                        {
                            listBox4.Items.Add(tr);
                        }
                        
                        kontrol = false;
                    }
                    else
                    {
                        kontrol = true;
                    }
                }
                
                
            }
            else
            {
                kirksekizoldu = true;
            }

            
            //if (!(listBox1.Items.Contains(eng + "\t" + tr) || listBox1.Items.Contains(eng + "\t\t" + tr)))
            //{
            //    if (eng.Length > 9)
            //    {
            //        listBox1.Items.Add(eng + "\t" + tr);
            //    }
            //    else
            //    {
            //        listBox1.Items.Add(eng + "\t\t" + tr);
            //    }
            //    kontrol = false;
            //}
            //else if ((listBox1.Items.Contains(eng + "\t" + tr) || listBox1.Items.Contains(eng + "\t\t" + tr)))
            //{
            //    kontrol = true;
            //}


        }

        private void kaydedilmiskelimeler_Load(object sender, EventArgs e)
        {
            this.Cursor = new Cursor(Application.StartupPath + "\\newcur.cur");
            this.Cursor = Cursor.Current;


            StreamReader sr = new StreamReader(@"ingilizce.txt");
            while (!sr.EndOfStream)
            {
                listBox1.Items.Add(sr.ReadLine());
            }
            sr.Close();

            StreamReader sr2 = new StreamReader(@"turkce.txt");
            while (!sr2.EndOfStream)
            {
                listBox2.Items.Add(sr2.ReadLine());
            }
            sr2.Close();


            StreamReader srr = new StreamReader(@"ingilizce2.txt");
            while (!srr.EndOfStream)
            {
                listBox3.Items.Add(srr.ReadLine());
            }
            srr.Close();

            StreamReader srr2 = new StreamReader(@"turkce2.txt");
            while (!srr2.EndOfStream)
            {
                listBox4.Items.Add(srr2.ReadLine());
            }
            srr2.Close();


            ElemanKontrol();
            if (elemansayisi!=0)
            {
                ElemanVar();
            }
            else
            {
                ElemanYok();
            }


            pictureBox1.Visible = false;
            pictureBox1.Enabled = false;
            button4.Visible = false;
            button5.Visible = false;

            pictureBox2.Visible = false;
            pictureBox2.Enabled = false;
            button6.Visible = false;

            label2.Visible = false;
            label1.Visible = false;

            if (listBox1.Items.Count>0)
            {
                label2.Visible = false;
            }


            listBox3.Visible = false;
            listBox4.Visible = false;


            if (listBox1.Items.Count>0)
            {
                label3.Visible = true;
            }
            else
            {
                label3.Visible = false;
            }
            
            label4.Visible = false;

        }
        

        public void SiraKontrol()
        {
            if (listBox1.Items.Count>0)
            {
                label3.Visible = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                listBox2.SetSelected(i, false);
                listBox1.SetSelected(i, false);
            }

            //Kaydet();
            this.Hide();
        }
        int index;

        public bool yirmidortoldu = false;
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                pictureBox2.Visible = true;
                button6.Visible = true;
            }
            if (listBox3.Items.Count == 0&&yirmidortoldu)
            {
                pictureBox2.Visible = true;
                button6.Visible = true;
            }

            if (listBox2.Items.Count != 0)
            {
                while (listBox2.SelectedItems.Count > 0)
                {
                    index = listBox2.SelectedIndex;
                    listBox2.Items.Remove(listBox2.SelectedItems[0]);
                    listBox1.SetSelected(index, true);
                    listBox1.Items.Remove(listBox1.SelectedItems[0]);
                }
            }

            if (listBox1.Items.Count != 0)
            {
                while (listBox1.SelectedItems.Count > 0)
                {
                    index = listBox1.SelectedIndex;
                    listBox1.Items.Remove(listBox1.SelectedItems[0]);
                    listBox2.SetSelected(index, true);
                    listBox2.Items.Remove(listBox2.SelectedItems[0]);
                }
            }


            if (listBox4.Items.Count != 0)
            {
                while (listBox4.SelectedItems.Count > 0)
                {
                    yirmidortoldu = false;
                    index = listBox4.SelectedIndex;
                    listBox4.Items.Remove(listBox4.SelectedItems[0]);
                    listBox3.SetSelected(index, true);
                    listBox3.Items.Remove(listBox3.SelectedItems[0]);
                }
            }

            if (listBox3.Items.Count != 0)
            {
                while (listBox3.SelectedItems.Count > 0)
                {
                    yirmidortoldu = false;
                    index = listBox3.SelectedIndex;
                    listBox3.Items.Remove(listBox3.SelectedItems[0]);
                    listBox4.SetSelected(index, true);
                    listBox4.Items.Remove(listBox4.SelectedItems[0]);
                }
            }


            if (listBox1.Items.Count+listBox3.Items.Count!=48)
            {
                kirksekizoldu = false;
            }
            if (listBox1.Items.Count + listBox3.Items.Count == 48)
            {
                kirksekizoldu = true;
            }


            if (listBox1.Items.Count==0)
            {
                label2.Visible = true;


                label3.Visible = false;
                label4.Visible = false;

            }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;

            if (listBox1.Items.Count > 0||listBox3.Items.Count>0)
            {
                pictureBox1.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
            }
            else
            {
                pictureBox2.Visible = true;
                button6.Visible = true;
            }
        }
        

        private void button5_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;

            pictureBox1.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            button6.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            button2.Enabled = true;

            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            yirmidortoldu = false;
            kirksekizoldu = false;
            
            button4.Visible = false;
            button5.Visible = false;
            pictureBox1.Visible = false;
            label1.Visible = true;


            label3.Visible = false;
            label4.Visible = false;
            
            
        }

        public void Kaydet()
        {
            StreamWriter sw = new StreamWriter(@"ingilizce.txt");
            if (listBox1.Items.Count > 0)
            {
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    listBox1.SetSelected(i, true);
                }

                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    sw.WriteLine(listBox1.SelectedItems[i]);
                }
            }

            sw.Close();

            StreamWriter sw2 = new StreamWriter(@"turkce.txt");
            if (listBox2.Items.Count > 0)
            {
                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    listBox2.SetSelected(i, true);
                }

                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    sw2.WriteLine(listBox2.SelectedItems[i]);
                }
            }
            sw2.Close();


            StreamWriter sww = new StreamWriter(@"ingilizce2.txt");
            if (listBox3.Items.Count > 0)
            {
                for (int i = 0; i < listBox3.Items.Count; i++)
                {
                    listBox3.SetSelected(i, true);
                }

                for (int i = 0; i < listBox3.Items.Count; i++)
                {
                    sww.WriteLine(listBox3.SelectedItems[i]);
                }
            }

            sww.Close();

            StreamWriter sww2 = new StreamWriter(@"turkce2.txt");
            if (listBox4.Items.Count > 0)
            {
                for (int i = 0; i < listBox4.Items.Count; i++)
                {
                    listBox4.SetSelected(i, true);
                }

                for (int i = 0; i < listBox4.Items.Count; i++)
                {
                    sww2.WriteLine(listBox4.SelectedItems[i]);
                }
            }
            sww2.Close();
        }

        private void kaydedilmiskelimeler_FormClosing(object sender, FormClosingEventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"ingilizce.txt");
            if (listBox1.Items.Count > 0)
            {
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    listBox1.SetSelected(i, true);
                }

                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    sw.WriteLine(listBox1.SelectedItems[i]);
                }
            }

            sw.Close();

            StreamWriter sw2 = new StreamWriter(@"turkce.txt");
            if (listBox2.Items.Count > 0)
            {
                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    listBox2.SetSelected(i, true);
                }

                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    sw2.WriteLine(listBox2.SelectedItems[i]);
                }
            }
            sw2.Close();


            StreamWriter sww = new StreamWriter(@"ingilizce2.txt");
            if (listBox3.Items.Count > 0)
            {
                for (int i = 0; i < listBox3.Items.Count; i++)
                {
                    listBox3.SetSelected(i, true);
                }

                for (int i = 0; i < listBox3.Items.Count; i++)
                {
                    sww.WriteLine(listBox3.SelectedItems[i]);
                }
            }

            sww.Close();

            StreamWriter sww2 = new StreamWriter(@"turkce2.txt");
            if (listBox4.Items.Count > 0)
            {
                for (int i = 0; i < listBox4.Items.Count; i++)
                {
                    listBox4.SetSelected(i, true);
                }

                for (int i = 0; i < listBox4.Items.Count; i++)
                {
                    sww2.WriteLine(listBox4.SelectedItems[i]);
                }
            }
            sww2.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count>0)
            {
                label3.Visible = true;
                label4.Visible = false;
            }
            else
            {
                label3.Visible = false;
                label4.Visible = false;
            }
            
            if (listBox1.Items.Count>0)
            {
                label1.Visible = false;
                label2.Visible = false;
                listBox1.Visible = true;
                listBox2.Visible = true;
                listBox3.Visible = false;
                listBox4.Visible = false;
            }
            else
            {
                listBox3.Visible = false;
                listBox4.Visible = false;
                label1.Visible = true;
                label2.Visible = false;
            }

            for (int i = 0; i < listBox3.Items.Count; i++)
            {
                listBox3.SetSelected(i, false);
                listBox4.SetSelected(i, false);
            }


        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (listBox3.Items.Count>0)
            {
                label3.Visible = false;
                label4.Visible = true;
            }
            else
            {
                label3.Visible = false;
                label4.Visible = false;
            }
            
            
            if (listBox3.Items.Count>0)
            {
                label1.Visible = false;
                listBox3.Visible = true;
                listBox4.Visible = true;
                listBox1.Visible = false;
                listBox2.Visible = false;
            }
            else
            {
                listBox1.Visible = false;
                listBox2.Visible = false;
                label1.Visible = false;
                label2.Visible = true;
            }

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                listBox2.SetSelected(i, false);
                listBox1.SetSelected(i, false);
            }
            
        }
        
    }
}
