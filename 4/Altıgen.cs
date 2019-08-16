using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace G171210002_proje
{
    class Altigen : Sekil
    {
        private int cap;
        private int yaricap;
        private int bitisX;
        private int bitisY;
        SolidBrush firca;
        Point[] okunanNoktalar = null;
        Point nokta1;
        Point nokta2;
        Point nokta3;
        Point nokta4;
        Point nokta5;
        Point nokta6;

        public override void Ciz(Graphics cizimAraci,SolidBrush icrengi)
        {
            nokta1 = new Point(X + cap, Y);
            nokta2 = new Point(X + yaricap, Y - cap);
            nokta3 = new Point(X - yaricap, Y - cap);
            nokta4 = new Point(X - cap, Y);
            nokta5 = new Point(X - yaricap, Y + cap);
            nokta6 = new Point(X + yaricap, Y + cap);
            firca = icrengi;
            if (cap != 0 && bitisX > X)
            {
                if (nokta2.Y <= 0)
                {
                    bitisY = 0;
                    cap = Y-bitisY;
                    yaricap = cap / 2;
                    cizimAraci.FillPolygon(firca, new Point[] { nokta1, nokta2, nokta3, nokta4, nokta5, nokta6 });
                    cizimAraci.DrawPolygon(Pens.Green, new Point[] { nokta1, nokta2, nokta3, nokta4, nokta5, nokta6 });
                }
                if (nokta6.Y > 445)
                {
                    bitisY = 444;
                    cap = bitisY - Y;
                    yaricap = cap / 2;
                    cizimAraci.FillPolygon(firca, new Point[] { nokta1, nokta2, nokta3, nokta4, nokta5, nokta6 });
                    cizimAraci.DrawPolygon(Pens.Green, new Point[] { nokta1, nokta2, nokta3, nokta4, nokta5, nokta6 });
                }
                if (nokta4.X <= 0)
                {
                    cizimAraci.FillPolygon(firca, new Point[] { nokta1, nokta2, nokta3, nokta4, nokta5, nokta6 });
                    cizimAraci.DrawPolygon(Pens.Green, new Point[] { nokta1, nokta2, nokta3, nokta4, nokta5, nokta6 });
                }
                else
                {
                    cizimAraci.FillPolygon(firca, new Point[] { nokta1, nokta2, nokta3, nokta4, nokta5, nokta6 });
                    cizimAraci.DrawPolygon(Pens.Green, new Point[] { nokta1, nokta2, nokta3, nokta4, nokta5, nokta6 });
                }
            }
        }

        public override void Ciz(Graphics cizimAraci)
        {
            if (cap != 0 && bitisX > X)
            {
                cizimAraci.FillPolygon(firca, new Point[] { nokta1, nokta2, nokta3, nokta4, nokta5, nokta6 });
                cizimAraci.DrawPolygon(Pens.Green, new Point[] { nokta1, nokta2, nokta3, nokta4, nokta5, nokta6 });
            }
        }

        public override void BitisAta(int bx, int by)
        {
            if (bx > 765)
            {
                bx = 764;
                cap = bx - X;
                yaricap = cap / 2;
                bitisX = bx;
                bitisY = by;
            }
            else
            {
                cap = bx - X;
                yaricap = cap / 2;
                bitisX = bx;
                bitisY = by;
            }
        }

        public override string Yazmaislemi()
        {
            if (firca.Color == Color.FromArgb(255, 128, 0))
            {
                return "altigen" + " " + nokta1.ToString() + " " + nokta2.ToString() + " " + nokta3.ToString() + " " + nokta4.ToString() + " " + nokta5.ToString() + " " + nokta6.ToString() + " Color [A=255,R=255,G=128,B=0]";
            }
            else if (firca.Color == Color.FromArgb(64, 0, 0))
            {
                return "altigen" + " " + nokta1.ToString() + " " + nokta2.ToString() + " " + nokta3.ToString() + " " + nokta4.ToString() + " " + nokta5.ToString() + " " + nokta6.ToString() + " Color [A=255,R=64,G=0,B=0]";
            }
            string yaz = "altigen" + " " + nokta1.ToString() + " " + nokta2.ToString() + " " + nokta3.ToString()+" "+nokta4.ToString() + " " + nokta5.ToString() + " " + nokta6.ToString() + " " + firca.Color;
            return yaz;
        }

        public override void OkunanCiz(Graphics k, SolidBrush f, Point[] n)
        {
            okunanNoktalar = n;
            k.FillPolygon(f, n);
            k.DrawPolygon(Pens.Blue, n);
        }

        public override void ListeCiz(Graphics k, SolidBrush f)
        {

            k.FillPolygon(f, okunanNoktalar);
            k.DrawPolygon(Pens.Blue, okunanNoktalar);
        }
    }
}
