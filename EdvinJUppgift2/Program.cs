using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdvinJUppgift2
{
    class Program
    {
        static void Main(string[] args)
        {
            Array();
        }

        static void Array()
        {
            Console.Write("Hur många rader?: ");
            int Rader = Convert.ToInt32(Console.ReadLine());
            Console.Write("Hur många kolumer: ");
            int Kolumer = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= Rader; i++)
            {
                Console.Write(i + " | ");
            }
            Console.WriteLine("");
            for (int j = 1; j <= Kolumer; j++)
            {
                Console.WriteLine(j);
                Console.WriteLine("");
            }
            for (int da = 1; da < Rader; da++)
            {
                int[] da = new int[] { Rader };
            }

            Console.Write(da);

        }
    }
}
