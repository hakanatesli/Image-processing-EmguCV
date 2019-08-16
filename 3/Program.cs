using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace g171210002_ödev3
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Motor
    {
        public string motor { get; set; }
    }

    class KontakAnahtari : Motor
    {
        public bool kontakanahtari { get; set; }
    }

    class ElektronikBeyin : KontakAnahtari
    {
        Sinyal sinyal = new Sinyal();
        Far far = new Far();
        Tekerlek tekerlek = new Tekerlek();
        GazPedali gazpedali = new GazPedali();
        FrenPedali frenpedali = new FrenPedali();
        public void elektronik_fonksiyon()
        {
            if (kontakanahtari == false)
            {
                sinyal.sinyal = "";
                sinyal.sinyal_fonksiyon();
                far.far = "";
                far.far_fonksiyon();
            }
            else
            {
                sinyal.sinyal = "";
                sinyal.sinyal_fonksiyon();
                far.far = "";
                far.far_fonksiyon();
                tekerlek.donus = 0;
                tekerlek.tekerlek_fonksiyon();
                frenpedali.frenpedali();
                gazpedali.gazpedali();

            }
        }
    }


    class Sinyal : SinyalKumandaKolu
    {

    }
    class SinyalKumandaKolu : ElektronikBeyin
    {
        public string sinyal { get; set; }
        public string sinyal_fonksiyon()
        {
            if (sinyal == "sağ" || sinyal == "SAĞ")
            {
                return sinyal + "a sinyal";
            }
            else if (sinyal == "sol" || sinyal == "SOL")
            {
                return sinyal + "a sinyal";
            }
            else
            {
                sinyal = "Sinyal yok.";
                return sinyal;
            }
        }
    }


    class Far : FarKumandaKolu
    {

    }
    class FarKumandaKolu : ElektronikBeyin
    {
        public string far { get; set; }
        public string far_fonksiyon()
        {
            if (far == "Kısa far" || far == "KISA FAR" || far == "kısa far" || far == "Uzun far" || far == "UZUN FAR" || far == "uzun far")
            {
                return far;
            }
            else
            {
                far = "Açık değil";
                return far;
            }
        }
    }



    class Tekerlek : Direksiyon
    {

    }
    class Direksiyon : ElektronikBeyin
    {
        public int donus { get; set; }
        private int tekerlekler = 0;

        public int tekerlek_fonksiyon()
        {
            if (kontakanahtari == true)
            {
                if (tekerlekler <= 45 && tekerlekler >= -45)
                {
                    if (donus == 1)
                    {
                        if (tekerlekler == -45)
                        {
                            return tekerlekler;
                        }
                        tekerlekler -= 5;
                        donus = 0;
                        return tekerlekler;
                    }
                    else if (donus == 3)
                    {
                        if (tekerlekler == 45)
                        {
                            return tekerlekler;
                        }
                        tekerlekler += 5;
                        donus = 0;
                        return tekerlekler;
                    }
                }
                return tekerlekler;
            }
            return tekerlekler;
        }
    }


    class HizGöstergesi : ElektronikBeyin
    {
        public bool pedal { get; set; }
        public int hiz = 0;
    }
    class GazPedali : HizGöstergesi
    {
        public int gazpedali()
        {
            if (kontakanahtari == true)
            {
                if (hiz >= 0 && hiz <= 220)
                {
                    if (motor == "dizel" || motor == "DİZEL" || motor == "Dizel")
                    {
                        if (pedal == true)
                        {
                            hiz += 8;
                            if (hiz > 220)
                            {
                                hiz = 220;
                            }
                            return hiz;
                        }
                    }
                    else if (motor == "benzin" || motor == "BENZİN" || motor == "Benzin")
                    {
                        if (pedal == true)
                        {
                            hiz += 10;
                            if (hiz > 220)
                            {
                                hiz = 220;
                            }
                            return hiz;
                        }
                    }
                }
                return hiz;
            }
            return hiz;
        }
    }
    class FrenPedali : HizGöstergesi
    {
        public int frenpedali()
        {
            if (kontakanahtari == true)
            {
                if (hiz >= 0 && hiz <= 220)
                {
                    if (pedal == false)
                    {
                        hiz -= 10;
                        if (hiz < 0)
                        {
                            hiz = 0;
                        }
                        return hiz;
                    }
                }
                return hiz;
            }
            return hiz;
        }
    }
}

}
