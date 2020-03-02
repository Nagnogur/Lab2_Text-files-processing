using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            Console.WriteLine(path);
            var filePaths = Directory.GetFiles(@path, "*.csv");
            foreach (string s in filePaths)
            {
                Console.WriteLine(s);
            }
            Console.ReadKey();
        }
    }
}
