using System;

namespace tenger_gyak_2022_11_11
{
    class Program
    {
        const int SOROK_SZAMA = 20;
        const int OSZLOPOK_SZAMA = 60;
        const char TENGER_JEL = '*';
        const char SZIGET_JEL = 'O';
        const char HAJO_JEL = '█';

        static void Hajo(char[,] terkep, int kx, int ky)
        { 
            //hajófej
            terkep[kx, ky] = HAJO_JEL;
            //hajótest
            terkep[kx + 1, ky] = HAJO_JEL;
            terkep[kx + 2, ky] = HAJO_JEL;
            terkep[kx + 1, ky + 1] = HAJO_JEL;
            terkep[kx + 2, ky + 1] = HAJO_JEL;
            terkep[kx + 1, ky - 1] = HAJO_JEL;
            terkep[kx + 2, ky - 1] = HAJO_JEL;

        }

        static void Main(string[] args)
        {
            
            /*
            char[,] tenger = new char[SOROK_SZAMA, OSZLOPOK_SZAMA];
            */
            //todo Itt majd be kell kérni a játékostól a pálya méretét - Ezt Zoli intézi majd
            
            int sziget_szelen = 0;
            char[,] tenger = new char[SOROK_SZAMA, OSZLOPOK_SZAMA];

            for (int sorIndex = 0; sorIndex < tenger.GetLength(0); sorIndex++)
            {
                for (int oszlopIndex = 0; oszlopIndex < tenger.GetLength(1); oszlopIndex++)
                { 
                    tenger[sorIndex, oszlopIndex] = TENGER_JEL;
                }
            }
            int sziget_darab = 0;
            bool van_szomszedos_sziget_BOOL = false;
            Random vel = new Random();
            for (int i = 0; i < 50; i++)
            {
                int random_sor = vel.Next(tenger.GetLength(0));
                int random_oszlop = vel.Next(tenger.GetLength(1));
                if (random_sor == 0 || random_sor == 19)
                {
                    sziget_szelen += 1;
                }
                else if (random_oszlop == 0 || random_oszlop == 59)
                {
                    sziget_szelen += 1;
                }
                else if ((random_sor == 0 || random_sor == 19) && ((random_oszlop == 0 || random_oszlop == 59)))
                {
                    sziget_szelen += 1;
                }

                tenger[random_sor, random_oszlop] = SZIGET_JEL;
                sziget_darab += 1;
                //szomszedos szigetek számolása
                try
                {
                    if (tenger[random_sor + 1, random_oszlop] == SZIGET_JEL)
                    {
                        van_szomszedos_sziget_BOOL = true;
                        break;
                        
                    }
                    else if (tenger[random_sor - 1, random_oszlop] == SZIGET_JEL)
                    {
                        van_szomszedos_sziget_BOOL = true;
                        break;

                    }
                    else if (tenger[random_sor, random_oszlop + 1] == SZIGET_JEL)
                    {
                        van_szomszedos_sziget_BOOL = true;
                        break;
                    }
                    else if (tenger[random_sor, random_oszlop - 1] == SZIGET_JEL)
                    {
                        van_szomszedos_sziget_BOOL = true;
                        break;
                    }
                }
                catch
                {
                    continue;
                }

                }

            string van_szomszedos_sziget_STRING = "";
            if (van_szomszedos_sziget_BOOL == true)
            {
                van_szomszedos_sziget_STRING = "VAN";
            }
            else if (van_szomszedos_sziget_BOOL == false)
            {
                van_szomszedos_sziget_STRING = "NINCS";
            }

            Hajo(tenger, 5, 5);
            Megjelenit(tenger);

            

            

            //1) Hány sziget van a tengeren?
            Console.WriteLine("Ennyi sziget van a tengeren: " + sziget_darab);

            //2) Hány sziget van a tenger szélén?
            Console.WriteLine("Ennyi sziget van a tenger szélén: " + sziget_szelen);

            //3) Van-e olyan sziget, ami mellett közvetlenül másik sziget is van?
            Console.WriteLine("Van két teljesen szomszédos sziget? : " + van_szomszedos_sziget_STRING);
            //4) Van-e olyan sziget, ami mellett közvetlenül másik sziget is van?
           

        }

        static void Megjelenit(char[,] terkep)
        {
            Console.Clear();
            for (int sorIndex = 0; sorIndex < terkep.GetLength(0); sorIndex++)
            {
                for (int oszlopIndex = 0; oszlopIndex < terkep.GetLength(1); oszlopIndex++)
                {
                    Console.Write(terkep[sorIndex, oszlopIndex]);
                }
                Console.WriteLine();
            }
        }
    }
}
