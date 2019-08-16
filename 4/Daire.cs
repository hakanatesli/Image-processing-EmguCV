using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace G171210002_proje
{
    class Daire : Sekil
    {
        private int cap;
        private int yaricap;
        SolidBrush firca;

        int okumadaireX ;
        int okumadaireY ;
        int okumadaireCap ;
        public override void Ciz(Graphics cizimAraci,SolidBrush icrengi)
        {
            firca = icrengi;
            if (cap != 0 && cap > 0)
            {
                cizimAraci.FillEllipse(firca, X-yaricap , Y-yaricap , cap, cap);
                cizimAraci.DrawEllipse(Pens.Blue, X -yaricap, Y-yaricap , cap, cap);
            }
        }
        public override void Ciz(Graphics cizimAraci)
        {
            if (cap != 0 && cap > 0)
            {
                cizimAraci.FillEllipse(firca, X - yaricap, Y - yaricap, cap, cap);
                cizimAraci.DrawEllipse(Pens.Blue, X - yaricap, Y - yaricap, cap, cap);
            }
        }

        public override void BitisAta(int bx, int by)
        {
            cap = bx - X;
            yaricap = cap / 2;
            if (X + yaricap > 765)
            {
                yaricap = 765 - X;
                cap = yaricap * 2;
            }
            if (X - yaricap < 1)
            {
                yaricap = X - 1;
                cap = yaricap * 2;
            }
            if (Y + yaricap > 445)
            {
                yaricap = 445 - Y;
                cap = yaricap * 2;
            }
            if (Y - yaricap < 1)
            {
                yaricap = Y - 1;
                cap = yaricap * 2;
            }
        }

        public override string Yazmaislemi()
        {
            int yazmaX = X-yaricap;
            int yazmaY = Y-yaricap;
            int yazmaCap = cap;
            if(firca.Color==Color.FromArgb(255,128,0))
            {
                return "daire" + " " + yazmaX.ToString() + " " + yazmaY.ToString() + " " + yazmaCap.ToString() + " Color [A=255,R=255,G=128,B=0]";
            }
            else if(firca.Color == Color.FromArgb(64, 0, 0))
            {
                return "daire" + " " + yazmaX.ToString() + " " + yazmaY.ToString() + " " + yazmaCap.ToString() + " Color [A=255,R=64,G=0,B=0]";
            }
            string yaz = "daire" + " " + yazmaX.ToString() + " " + yazmaY.ToString() + " " + yazmaCap.ToString()+" "+firca.Color;
            return yaz;
        }

        public override void OkunanCiz(Graphics k, SolidBrush f,int x, int y, int z)
        {
            okumadaireX = x;
            okumadaireY = y;
            okumadaireCap = z;
            k.FillEllipse(f, x, y, z, z);
            k.DrawEllipse(Pens.Blue, x, y,z, z);
        }

        public override void ListeCiz(Graphics k, SolidBrush f)//
        {
            k.FillEllipse(f, okumadaireX-(okumadaireCap/2), okumadaireY - (okumadaireCap / 2), okumadaireCap, okumadaireCap);//
            k.DrawEllipse(Pens.Blue, okumadaireX - (okumadaireCap / 2), okumadaireY - (okumadaireCap / 2), okumadaireCap, okumadaireCap);//
        }
    }
}
