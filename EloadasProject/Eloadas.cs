using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloadasProject
{
    public class Eloadas
    {

        bool[,] foglalasok;

        public Eloadas(int sorokSzama, int helyekSzama)
        {
            if (sorokSzama < 1 || helyekSzama < 1)
            {
                throw new ArgumentException("A foglalási számoknak 0-nál nagyobbnak kell lennie.");
            }
            foglalasok =  new bool[sorokSzama,helyekSzama];
        }

        public bool Lefoglal()
        {
            bool foglalt = false;

            for (int i = 0; i < foglalasok.GetLength(0); i++)
            {
                for (int j = 0; j < foglalasok.GetLength(1); j++)
                {
                    if (this.foglalasok[i,j] == false)
                    {
                        this.foglalasok[i, j] = true;
                        foglalt = true;
                    }
                }
            }
            return foglalt;
        }

        public int SzabadHelyek
        {
           get {
                int szabad = 0;

                for (int i = 0; i < foglalasok.GetLength(0); i++)
                {
                    for (int j = 0; j < foglalasok.GetLength(1); j++)
                    {
                        if (this.foglalasok[i, j] == false)
                        {
                            szabad++;
                        }
                    }
                }
                return szabad;
            }

        }


        public bool Teli { get => SzabadHelyek < 1; }

        public bool Foglalt(int sorSzam, int helySzam)
        {
            if (sorSzam == 0 || helySzam== 0)
            {
                throw new ArgumentException("A foglalási számoknak 0-nál nagyobbnak kell lennie.");
            }
            return foglalasok[sorSzam-1, helySzam-1];
        }

    }
}
