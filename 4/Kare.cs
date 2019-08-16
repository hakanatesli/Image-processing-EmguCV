using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace G171210002_proje
{
    class Kare : Sekil
    {
        private int widhtX;
        private int widhtY;
        SolidBrush firca;
        public int okunankareX;
        public int okunankareY;
        public int okunankareWidht;

        public Kare()
        {
            widhtX = 0;
            widhtY = 0;
        }

        public override void Ciz(Graphics cizimAraci,SolidBrush icrengi)
        {
            firca = icrengi;
            if (widhtX != 0)
            {
                cizimAraci.FillRectangle(firca, new Rectangle(X , Y, widhtX, widhtY));
                cizimAraci.DrawRectangle(Pens.Blue, X, Y, widhtX, widhtY);
            }
        }
        public override void Ciz(Graphics cizimAraci)
        {
            if (widhtX != 0)
            {
                cizimAraci.FillRectangle(firca, new Rectangle(X, Y, widhtX, widhtY));
                cizimAraci.DrawRectangle(Pens.Blue, X, Y, widhtX, widhtY);
            }
        }

        public override void BitisAta(int bx, int by)
        {
            if (bx > 765)
            {
                bx = 764;
                widhtX = bx - X;
                widhtY = by - Y;
            }
            else if (by > 445)
            {
                by = 444;
                widhtY = by - Y;
                widhtX = bx - X;
            }
            else
            {
                widhtX = bx - X;
                widhtY = by - Y;
            }
        }

        public override string Yazmaislemi()
        {
            int yazmaX = X;
            int yazmaY = Y;
            int yazmaWidht = widhtX;
            if (firca.Color == Color.FromArgb(255, 128, 0))
            {
                return "kare" + " " + yazmaX.ToString() + " " + yazmaY.ToString() + " " + yazmaWidht.ToString() + " Color [A=255,R=255,G=128,B=0]";
            }
            else if (firca.Color == Color.FromArgb(64, 0, 0))
            {
                return "kare" + " " + yazmaX.ToString() + " " + yazmaY.ToString() + " " + yazmaWidht.ToString() + " Color [A=255,R=64,G=0,B=0]";
            }
            string yaz = "kare" + " " + yazmaX.ToString() + " " + yazmaY.ToString() + " " + yazmaWidht.ToString() + " " + firca.Color;
            return yaz;
        }

        public override void OkunanCiz(Graphics k, SolidBrush f, int x, int y, int z)
        {
            okunankareWidht = z;
            okunankareX = x;
            okunankareY = y;
            k.FillRectangle(f, x, y, z, z);
            k.DrawRectangle(Pens.Blue, x, y, z, z);
        }

        public override void ListeCiz(Graphics k, SolidBrush f)
        {
            k.FillRectangle(f, okunankareX,okunankareY,okunankareWidht,okunankareWidht);
            k.DrawRectangle(Pens.Blue, okunankareX, okunankareY, okunankareWidht, okunankareWidht);
        }
    }
}
