using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spel_struktur
{
    class Program
    {
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

        }

        /// <summary>
        /// innehåller programmets logik
        /// </summary>
        static void Uppdate()
        {

        }

        /// <summary>
        /// ritar ut på bildskärmen
        /// </summary>
        static void Draw()
        {

        }
    }
}
