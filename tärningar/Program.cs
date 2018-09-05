using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tärningar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("vill du slå tärningar? ");
            string str = Console.ReadLine();
            while (str != "no")
            {
                if (str == "yes")
                {
                    Random rnd = new Random();

                    int NUM1 = rnd.Next(1, 7);
                    int NUM2 = rnd.Next(1, 7);

                    Console.WriteLine(NUM1);
                    Console.WriteLine(NUM2);

                }

                else if (str == "no")
                {
                    return;
                }
                Console.Write("vill du slå igen?");
                str = Console.ReadLine();
            }
        }
    }
}
