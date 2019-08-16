using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace G171210002_proje
{
    class Ucgen : Sekil
    {
        private int kenar;
        private int bitisY;
        int y, x;
        SolidBrush firca;
        Point[] okunanNoktalar;
        Point nokta1, nokta2, nokta3;

        public override void Ciz(Graphics cizimAraci,SolidBrush icrengi)
        {
            firca = icrengi;
            nokta1 = new Point(X, Y);
            nokta2 = new Point(X + (kenar / 2), bitisY);
            nokta3 = new Point(X - (kenar / 2), bitisY);
            
            if (kenar != 0 && kenar > 0)
            {
                if (nokta2.X < 765 && nokta3.X>1)
                {
                    cizimAraci.FillPolygon(firca, new Point[] { nokta1, nokta2, nokta3 });
                    cizimAraci.DrawPolygon(Pens.Blue, new Point[] { nokta1, nokta2, nokta3 });
                }
                else if (nokta2.X == 765||nokta3.X==1)
                {
                    y = nokta2.Y;
                    if (nokta2.X == 765) x = nokta3.X;
                    else x = nokta2.X;
                }
                else if(nokta2.X>765)
                {
                    cizimAraci.FillPolygon(firca, new Point[] { new Point(X, Y), new Point(764, y), new Point(x, y) });
                    cizimAraci.DrawPolygon(Pens.Blue, new Point[] { new Point(X, Y), new Point(764, y), new Point(x, y) });
                }
                else if (nokta3.X < 1)
                {
                    cizimAraci.FillPolygon(firca, new Point[] { new Point(X, Y), new Point(x, y), new Point(1, y) });
                    cizimAraci.DrawPolygon(Pens.Blue, new Point[] { new Point(X, Y), new Point(x, y), new Point(1, y) });
                }
            }
        }

        public override void Ciz(Graphics cizimAraci)
        {
            if (kenar != 0 && kenar > 0)
            {
                if (nokta2.X < 765 && nokta3.X > 1)
                {
                    cizimAraci.FillPolygon(firca, new Point[] { nokta1, nokta2, nokta3 });
                    cizimAraci.DrawPolygon(Pens.Blue, new Point[] { nokta1, nokta2, nokta3 });
                }
                else if (nokta2.X == 765 || nokta3.X == 1)
                {
                    y = nokta2.Y;
                    if (nokta2.X == 765) x = nokta3.X;
                    else x = nokta2.X;
                }
                else if (nokta2.X > 765)
                {
                    cizimAraci.FillPolygon(firca, new Point[] { new Point(X, Y), new Point(764, y), new Point(x, y) });
                    cizimAraci.DrawPolygon(Pens.Blue, new Point[] { new Point(X, Y), new Point(764, y), new Point(x, y) });
                }
                else if (nokta3.X < 1)
                {
                    cizimAraci.FillPolygon(firca, new Point[] { new Point(X, Y), new Point(x, y), new Point(1, y) });
                    cizimAraci.DrawPolygon(Pens.Blue, new Point[] { new Point(X, Y), new Point(x, y), new Point(1, y) });
                }
            }
        }

        public override void BitisAta(int bx, int by)
        {
            if (by > 445)
            {
                by = 444;
                kenar = by - Y;
                bitisY = by;
            }
            else
            {
                kenar = by - Y;
                bitisY = by;
            }
        }

        public override string Yazmaislemi()
        {
            if (firca.Color == Color.FromArgb(255, 128, 0))
            {
                return "ucgen" + " " + nokta1.ToString() + " " + nokta2.ToString() + " " + nokta3.ToString() + " Color [A=255,R=255,G=128,B=0]";
            }
            else if (firca.Color == Color.FromArgb(64, 0, 0))
            {
                return "ucgen" + " " + nokta1.ToString() + " " + nokta2.ToString() + " " + nokta3.ToString() + " Color [A=255,R=64,G=0,B=0]";
            }
            string yaz = "ucgen" + " " + nokta1.ToString() + " " + nokta2.ToString() + " " + nokta3.ToString() + " " + firca.Color;
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
            k.DrawPolygon(Pens.Blue,okunanNoktalar);
        }
    }
}
