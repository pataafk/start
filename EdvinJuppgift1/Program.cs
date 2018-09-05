using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdvinJuppgift1
{
    class Program
    {
        static void Main(string[] args)
        {
            Volym();
        }

        static void Volym()
        {
            Console.Write("Höjden: ");
            double Vo = Convert.ToDouble(Console.ReadLine());
            Console.Write("Radie: ");
            double Ly = Convert.ToDouble(Console.ReadLine());
            double M = 3.14;

            double Volymsum = M * (Ly*Ly) * Vo;
            Console.WriteLine("Volymen: " + Volymsum);

            Console.Write("Densitet: ");
            double str = Convert.ToDouble(Console.ReadLine());
            double Vsum = str * Volymsum;
            Console.WriteLine("Vikt: " + Vsum);
            Console.Write("Priset: ");
            double Pris = Convert.ToDouble(Console.ReadLine());
            Console.Write("Antal: ");
            double antal = Convert.ToDouble(Console.ReadLine());
            double antalpris = Vsum * Pris * antal;
            Console.WriteLine("Totala prise: " + antalpris);

        }

    }
}
