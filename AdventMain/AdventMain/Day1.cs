using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventMain
{
    internal class Day1
    {
        public static void solution1()
        {
            string text = File.ReadAllText(Program.inputLocation + "1.txt");

            List<string> caloies = text.Split("\n\n").ToList();
            foreach (string word in caloies) {
                Console.WriteLine(word);
                Console.WriteLine("");
            }

        }
    }
}
