using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace G171210002_proje
{
    class Sekil
    {
        private int x;
        private int y;

        public int X
        {
            get;
            set;
        }
        public int Y
        {
            get;
            set;
        }

        public virtual void BitisAta(int bx, int by)
        {

        }
     
        public virtual void Ciz(Graphics cizimAraci, SolidBrush icrengi)
        {

        }
        public virtual void Ciz(Graphics cizimAraci)
        {

        }

        public virtual void OkunanCiz(Graphics k, SolidBrush f,int x,int y,int z)
        {

        }

        public virtual void OkunanCiz(Graphics k, SolidBrush f, Point[] n)
        {
            
        }

        public virtual string Yazmaislemi()
        {
            return "";
        }

        public virtual void ListeCiz(Graphics k, SolidBrush f)
        {
            
        }
    }
}
