using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> firstNames = new List<string>();
            firstNames.Add("name1");
            firstNames.Add("name2");
            firstNames.Add("name3");
            firstNames.Add("namen");

            Random randNum = new Random();
            int aRandomPos = randNum.Next(firstNames.Count);

            string currName = firstNames[aRandomPos];

            Console.WriteLine(currName);
        }
    }
}
