using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace G171210002_proje
{
    class Renk
    {
        SolidBrush icrengi;
        public void KirmiziAta()
        {
            icrengi = new SolidBrush(Color.Red);
        }
        public void MaviAta()
        {
            icrengi = new SolidBrush(Color.Blue);
        }
        public void SariAta()
        {
            icrengi = new SolidBrush(Color.Yellow);
        }
        public void SiyahAta()
        {
            icrengi = new SolidBrush(Color.Black);
        }
        public void KahverengiAta()
        {
            icrengi = new SolidBrush(Color.FromArgb(128,64,0));
        }
        public void YesilAta()
        {
            icrengi = new SolidBrush(Color.Green);
        }
        public void AquaAta()
        {
            icrengi = new SolidBrush(Color.Aqua);
        }
        public void GriAta()
        {
            icrengi = new SolidBrush(Color.Gray);
        }
        public void TuruncuAta()
        {
            icrengi = new SolidBrush(Color.FromArgb(255,128,0));
        }
        public void AcıkKahveAta()
        {
            icrengi = new SolidBrush(Color.FromArgb(128,64,64));
        }
        public void KoyuyesilAta()
        {
            icrengi = new SolidBrush(Color.FromArgb(0,64,64));
        }
        public void PembeAta()
        {
            icrengi = new SolidBrush(Color.Fuchsia);
        }
        public void AcıkpembeAta()
        {
            icrengi = new SolidBrush(Color.FromArgb(255,128,128));
        }
        public void LacivertAta()
        {
            icrengi = new SolidBrush(Color.FromArgb(0,0,64));
        }
        public void AcıkyesilAta()
        {
            icrengi = new SolidBrush(Color.Lime);
        }
        public void TurkuazAta()
        {
            icrengi = new SolidBrush(Color.FromArgb(192,192,0));
        }

    }
}
