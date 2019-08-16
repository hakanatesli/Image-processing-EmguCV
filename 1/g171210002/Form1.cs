using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.UI;

namespace g171210002
{
    public partial class Form1 : Form
    {
        Image<Bgr, byte> alinanresim;
        Image<Gray, byte> griresim;
        public Form1()
        {
            InitializeComponent();
        }
        public static string DosyaAdiGetir()
        {
            OpenFileDialog dosyaacma = new OpenFileDialog();
            dosyaacma.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" + "All files(*.*) | *.* ";
            if (dosyaacma.ShowDialog() == DialogResult.OK)
                return dosyaacma.FileName;
            else
                return "";
        }
        private void EKLE_Click(object sender, EventArgs e)
        {
            alinanresim = new Image<Bgr, byte>(DosyaAdiGetir());
            if (alinanresim == null)
            {
                MessageBox.Show("resim alınamadı.");
                return;
            }
            ımageBox1.Image = alinanresim;
            ımageBox1.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Everything;
        }

        private void GRİ_Click(object sender, EventArgs e)
        {
            griresim = alinanresim.Convert<Gray, byte>();
            panAndZoomPictureBox1.Image = griresim.Bitmap;
        }

        private void BİNARY_Click(object sender, EventArgs e)
        {
            int threshold = 70;
            Image<Gray, byte> binary = griresim.ThresholdBinary(new Gray(threshold), new Gray(255));
            ımageBox2.Image = binary;
        }

        private void HİSTOGRAM_Click(object sender, EventArgs e)
        {
            DenseHistogram hist = new DenseHistogram(256, new RangeF(0, 255));
            hist.Calculate(new Image<Gray, byte>[] { alinanresim[0] }, false, null);
            Mat m = new Mat();
            hist.CopyTo(m);
            histogramBox1.AddHistogram("Blue Channel Histogram", Color.Blue, m, 256, new float[] { 0, 256 });
            histogramBox1.Refresh();
        }
    }
}
