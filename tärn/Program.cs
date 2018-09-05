using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tärn
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("vill du slå tärningar? ");
            string str = Console.ReadLine();
            
            while (str != "nej")
            {
                if (str == "ja")
                {
                    Random rnd = new Random();

                    Console.Write("hur många trärningar?");
                    int sdt = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < sdt; i++)
                    {
                        
                        int NUM1 = rnd.Next(1, 7);

                        Console.WriteLine(NUM1);
                    }
                }
                else if (str == "nej")
                {
                    return;
                }
                Console.Write("vill du slå igen?");
                str = Console.ReadLine();
            }

        }
    }
}
