using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace G171210002_proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Sekil> sekiller = new List<Sekil>();
        SolidBrush[] renkdizi;
        int sekilSayisi = 0;
        bool cizimaktifmi = false;
        int maxSekilSayisi = 100;
        Sekil aktifSekil = null;
        Panel[] renk = new Panel[10];
        string aktifsekilstring;
        string[] Sekil;
        int txtsekilsayisi;
        private void Form1_Load(object sender, EventArgs e)
        {
            Sekil = new string[maxSekilSayisi];
            renkdizi = new SolidBrush[maxSekilSayisi];
            renkdizi[0] = new SolidBrush(Color.Red);

            DoubleBuffered = true;
            Text = "Deneme Uygulaması";
            Paint += AnaPencerem_Paint;

            //******************
            renk[0] = turuncu;
            renk[1] = mor;
            renk[2] = kahve;
            renk[3] = sari;
            renk[4] = siyah;
            renk[5] = beyaz;
            renk[6] = mavi;
            renk[7] = yesil;
            renk[8] = kirmizi;
            //******************

        }
        void AnaPencerem_Paint(object sender, PaintEventArgs e)
        {
            Graphics cizimAraci = e.Graphics;
            cizimAraci = pictureBox1.CreateGraphics();

            if (aktifSekil != null)
                aktifSekil.Ciz(cizimAraci, renkdizi[sekilSayisi]);
            
            for (int i =0; i < sekilSayisi; i++)
            {
                if(i<txtsekilsayisi) sekiller[i].ListeCiz(cizimAraci, renkdizi[i+1]);
                else sekiller[i].Ciz(cizimAraci);
            }
        }

        void AnaPencerem_MouseDown(object sender, MouseEventArgs e)
        {
            if (pictureBox14.BackColor == Color.Aqua)
            {
                aktifSekil = new Daire();
                aktifsekilstring = "daire";
            }
            else if (pictureBox11.BackColor == Color.Aqua)
            {
                aktifSekil = new Kare();
                aktifsekilstring = "kare";
            }
            else if (pictureBox12.BackColor == Color.Aqua)
            {
                aktifSekil = new Altigen();
                aktifsekilstring = "altigen";
            }
            else if (pictureBox13.BackColor == Color.Aqua)
            {
                aktifSekil = new Ucgen();
                aktifsekilstring = "ucgen";
            }
            
            cizimaktifmi = true;
            aktifSekil.X = e.X;
            aktifSekil.Y = e.Y;
            
            Invalidate();
        }
        
        void AnaPencerem_MouseMove(object sender, MouseEventArgs e)
        {
            if (cizimaktifmi)
            {
                aktifSekil.BitisAta(e.X, e.Y);
                Refresh();
                Invalidate();
            }
        }

        void AnaPencere_MouseUp(object sender, MouseEventArgs e)
        {
            cizimaktifmi = false;

            if (sekilSayisi != maxSekilSayisi - 1)
            {
                sekiller.Add(aktifSekil);
                Sekil[sekilSayisi] = aktifsekilstring;
            }
            sekilSayisi++;
            for (int i = 0; i < 9; i++)
            {
                if (renk[i].BackColor == Color.Aqua)
                {
                    renkdizi[sekilSayisi] = new SolidBrush(RenkBelirleme(renk[i]));
                }
            }
            Invalidate();
        }
               
        Color RenkBelirleme(Panel p)
        {
            if (p.Name == "kirmizi") return Color.Red;
            else if (p.Name == "mavi") return Color.Blue;
            else if (p.Name == "yesil") return Color.Green;
            else if (p.Name == "turuncu") return Color.FromArgb(255,128,0);
            else if (p.Name == "siyah") return Color.Black;
            else if (p.Name == "sari") return Color.Yellow;
            else if (p.Name == "mor") return Color.Purple;
            else if (p.Name == "kahve") return Color.FromArgb(64, 0, 0);
            else return Color.White;
        }

        Color okunanRenkBelirleme(string p)
        {
            if (p == "[Red]") return Color.Red;
            else if (p == "[Blue]") return Color.Blue;
            else if (p == "[Green]") return Color.Green;
            else if (p == "[A=255,R=255,G=128,B=0]") return Color.FromArgb(255, 128, 0);
            else if (p == "[Black]") return Color.Black;
            else if (p == "[Yellow]") return Color.Yellow;
            else if (p == "[Purple]") return Color.Purple;
            else if (p == "[A=255,R=64,G=0,B=0]") return Color.FromArgb(64, 0, 0);
            else return Color.White;
        } 

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            renkdizi[sekilSayisi] = new SolidBrush(Color.Red);
            kirmizi.BackColor = Color.Aqua;
            for(int i = 0; i < 8; i++)
            {
                if (renk[i].BackColor == Color.Aqua)
                {
                    renk[i].BackColor = Color.Transparent;
                }
            }
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            renkdizi[sekilSayisi] = new SolidBrush(Color.Blue);
            mavi.BackColor = Color.Aqua;
            for (int i = 0; i < 9; i++)
            {
                if (i != 6 && renk[i].BackColor == Color.Aqua)
                {
                    renk[i].BackColor = Color.Transparent;
                }
            }
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            renkdizi[sekilSayisi] = new SolidBrush(Color.Green);
            yesil.BackColor = Color.Aqua;
            for (int i = 0; i < 9; i++)
            {
                if (i != 7 && renk[i].BackColor == Color.Aqua)
                {
                    renk[i].BackColor = Color.Transparent;
                }
            }
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            renkdizi[sekilSayisi] = new SolidBrush(Color.FromArgb(255,128,0));
            turuncu.BackColor = Color.Aqua;
            for (int i = 0; i < 9; i++)
            {
                if (i != 0 && renk[i].BackColor == Color.Aqua)
                {
                    renk[i].BackColor = Color.Transparent;
                }
            }
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            renkdizi[sekilSayisi] = new SolidBrush(Color.Black);
            siyah.BackColor = Color.Aqua;
            for (int i = 0; i < 9; i++)
            {
                if (i != 4 && renk[i].BackColor == Color.Aqua)
                {
                    renk[i].BackColor = Color.Transparent;
                }
            }
        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            renkdizi[sekilSayisi] = new SolidBrush(Color.Yellow);
            sari.BackColor = Color.Aqua;
            for (int i = 0; i < 9; i++)
            {
                if (i != 3 && renk[i].BackColor == Color.Aqua)
                {
                    renk[i].BackColor = Color.Transparent;
                }
            }
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            renkdizi[sekilSayisi] = new SolidBrush(Color.Purple);
            mor.BackColor = Color.Aqua;
            for (int i = 0; i < 9; i++)
            {
                if (i != 1 && renk[i].BackColor == Color.Aqua)
                {
                    renk[i].BackColor = Color.Transparent;
                }
            }
        }
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            renkdizi[sekilSayisi] = new SolidBrush(Color.FromArgb(64,0,0));
            kahve.BackColor = Color.Aqua;
            for (int i = 0; i < 9; i++)
            {
                if (i != 2 && renk[i].BackColor == Color.Aqua)
                {
                    renk[i].BackColor = Color.Transparent;
                }
            }
        }
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            renkdizi[sekilSayisi] = new SolidBrush(Color.White);
            beyaz.BackColor = Color.Aqua;
            for (int i = 0; i < 9; i++)
            {
                if (i != 5 && renk[i].BackColor == Color.Aqua)
                {
                    renk[i].BackColor = Color.Transparent;
                }
            }
        }
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            pictureBox11.BackColor = Color.Aqua;
            pictureBox12.BackColor = Color.Transparent;
            pictureBox13.BackColor = Color.Transparent;
            pictureBox14.BackColor = Color.Transparent;
        }
        private void pictureBox14_Click(object sender, EventArgs e)
        {
            pictureBox11.BackColor = Color.Transparent;
            pictureBox12.BackColor = Color.Transparent;
            pictureBox13.BackColor = Color.Transparent;
            pictureBox14.BackColor = Color.Aqua;
        }
        private void pictureBox13_Click(object sender, EventArgs e)
        {
            pictureBox11.BackColor = Color.Transparent;
            pictureBox12.BackColor = Color.Transparent;
            pictureBox13.BackColor = Color.Aqua;
            pictureBox14.BackColor = Color.Transparent;
        }
        private void pictureBox12_Click(object sender, EventArgs e)
        {
            pictureBox11.BackColor = Color.Transparent;
            pictureBox12.BackColor = Color.Aqua;
            pictureBox13.BackColor = Color.Transparent;
            pictureBox14.BackColor = Color.Transparent;
        }
        

        private void panel14_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.FileName = "*";
                saveFileDialog1.Filter = "Yazı Dosyaları (*txt)|*.txt";
                saveFileDialog1.DefaultExt = "txt";
                saveFileDialog1.ShowDialog();
                StreamWriter yazmaislemi = new StreamWriter(saveFileDialog1.FileName);
                for (int i = 0; i < sekilSayisi; i++)
                {
                    if (Sekil[i] == "daire") yazmaislemi.WriteLine(sekiller[i].Yazmaislemi() + " " + sekilSayisi.ToString());
                    else if (Sekil[i] == "kare") yazmaislemi.WriteLine(sekiller[i].Yazmaislemi() + " " + sekilSayisi.ToString());
                    else if (Sekil[i] == "ucgen") yazmaislemi.WriteLine(sekiller[i].Yazmaislemi() + " " + sekilSayisi.ToString());
                    else if (Sekil[i] == "altigen") yazmaislemi.WriteLine(sekiller[i].Yazmaislemi() + " " + sekilSayisi.ToString());
                }
                yazmaislemi.Close();
            }
            catch(Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void panel13_Click(object sender, EventArgs e)
        {
            panel15.BackColor = Color.Aqua;
            Sekil okunanaktifsekil = null;
            Graphics cizimAraci1;
            cizimAraci1 = pictureBox1.CreateGraphics();
            string satir = "";
            openFileDialog1.FileName = "Okunacak Dosyayı Seçiniz";
            openFileDialog1.Filter = "Yazı Dosyaları (*txt)|*.txt";
            openFileDialog1.ShowDialog();
            StreamReader oku = new StreamReader(openFileDialog1.FileName);
            while (satir != null)
            {
                string[] yazi;
                satir = oku.ReadLine();
                if (satir == null) break;
                yazi = satir.Split(' ');
                if (satir != null && yazi[0] == "daire")
                {
                    sekilSayisi++;
                    int okunanX = Convert.ToInt32(yazi[1]);
                    int okunanY = Convert.ToInt32(yazi[2]);
                    int okunanCap = Convert.ToInt32(yazi[3]);
                    txtsekilsayisi = Convert.ToInt32(yazi[6]);
                    okunanaktifsekil = new Daire();
                    renkdizi[sekilSayisi] = new SolidBrush(okunanRenkBelirleme(yazi[5]));
                    okunanaktifsekil.OkunanCiz(cizimAraci1, renkdizi[sekilSayisi], okunanX, okunanY, okunanCap);
                    sekiller.Add(okunanaktifsekil);
                }

                else if (satir != null && yazi[0] == "kare")
                {
                    sekilSayisi++;
                    int okunanX = Convert.ToInt32(yazi[1]);
                    int okunanY = Convert.ToInt32(yazi[2]);
                    int okunanWidht = Convert.ToInt32(yazi[3]);
                    txtsekilsayisi = Convert.ToInt32(yazi[6]);
                    okunanaktifsekil = new Kare();
                    renkdizi[sekilSayisi] = new SolidBrush(okunanRenkBelirleme(yazi[5]));
                    okunanaktifsekil.OkunanCiz(cizimAraci1, renkdizi[sekilSayisi], okunanX, okunanY, okunanWidht);
                    sekiller.Add(okunanaktifsekil);
                }

                else if (satir != null && yazi[0] == "ucgen")
                {
                    sekilSayisi++;
                    string[] point;
                    Point[] noktalar = new Point[3];
                    txtsekilsayisi = Convert.ToInt32(yazi[6]);
                    for (int i = 1; i < 4; i++)
                    {
                        point = yazi[i].Split('=', '{', '}', ',');
                        noktalar[i - 1] = new Point(Convert.ToInt32(point[2]), Convert.ToInt32(point[4]));
                    }
                    okunanaktifsekil = new Ucgen();
                    renkdizi[sekilSayisi] = new SolidBrush(okunanRenkBelirleme(yazi[5]));
                    okunanaktifsekil.OkunanCiz(cizimAraci1, renkdizi[sekilSayisi], noktalar);
                    sekiller.Add(okunanaktifsekil);
                }

                else if (satir != null && yazi[0] == "altigen")
                {
                    sekilSayisi++;
                    string[] point;
                    Point[] noktalar = new Point[6];
                    txtsekilsayisi = Convert.ToInt32(yazi[9]);
                    for (int i = 1; i < 7; i++)
                    {
                        point = yazi[i].Split('=', '{', '}', ',');
                        noktalar[i - 1] = new Point(Convert.ToInt32(point[2]), Convert.ToInt32(point[4]));
                    }
                    okunanaktifsekil = new Altigen();
                    renkdizi[sekilSayisi] = new SolidBrush(okunanRenkBelirleme(yazi[8]));
                    okunanaktifsekil.OkunanCiz(cizimAraci1, renkdizi[sekilSayisi], noktalar);
                    sekiller.Add(okunanaktifsekil);
                }
            }
            oku.Close();
        }
    }
}
