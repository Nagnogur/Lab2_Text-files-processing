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
            var filePaths = Directory.GetFiles(@path, "*.csv");

            List<Student> rating = new List<Student>();
            int l = 0;
            foreach (string s in filePaths)
            {
                StreamReader reader = new StreamReader(File.OpenRead(@s));
                int n = Convert.ToInt32(reader.ReadLine());
                l += n;
                for (int i = 0; i < n; i++)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');
                    int[] grades = new int[5];
                    for (int j = 1; j < 6; j++)
                    {
                        grades[j - 1] = Convert.ToInt32(values[j]);
                    }
                    bool budget;
                    budget = values[6] == "FALSE" ? true : false; 
                    rating.Add(new Student(values[0], grades , budget));
                }
            }
            Student[] array = rating.ToArray();
            for (int i = 0; i < l; i++)
            {
                Console.WriteLine(array[i].LastName);
            }
            Console.ReadKey();
        }
    }
}
