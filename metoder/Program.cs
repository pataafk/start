using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metoder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Da);
            int tal = Dosomthing(5);
            Console.WriteLine(tal);
            Console.ReadKey();
        }
        private static int Da = 0;

        static int Dosomthing(int i)
        {
            Console.WriteLine("hallå" + i);

            return 10;
        }
        
    }
}
