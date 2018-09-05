using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spel_struktur
{
    class Program
    {
        //globala deklarrationer

        static int Spelarex;
        static int Spelarey;



        /// <summary>
        /// ett spel (syns inte i monogame)
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Initialize();
            while (true)
            {
                Uppdate();
                Draw();
            }
        }

        /// <summary>
        /// initerar värden i början av programmet
        /// </summary>
        static void Initialize()
        {
            Spelarex = 1;
            Spelarey = 1;
        }

        /// <summary>
        /// innehåller programmets logik
        /// </summary>
        static void Uppdate()
        {
            // läs in tangenttryckningar
            var key = Console.ReadKey();

            // styrning

            switch(key.Key)
            {
                case ConsoleKey.LeftArrow:
                    Spelarex -= 1;

                    break;
            }
        }

        /// <summary>
        /// ritar ut på bildskärmen
        /// </summary>
        static void Draw()
        {
            //ränsa skärm
            Console.Clear();

            //rita bana med 10 tecken bredd och 8 tecken höjd

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 9;x++)
                {
                    Console.Write("#");
                    if (x==Spelarex && y == Spelarey)
                    {
                        Console.Write("@");
                    }
                }
                Console.WriteLine("");
            }

        }
    }
}
