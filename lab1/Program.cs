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
            int numberBudget = 0;

            foreach (string s in filePaths)
            {
                StreamReader reader = new StreamReader(File.OpenRead(@s));
                int n = Convert.ToInt32(reader.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');
                    int[] grades = new int[5];
                    double avarage = 0;
                    for (int j = 1; j < 6; j++)
                    {
                        grades[j - 1] = Convert.ToInt32(values[j]);
                        avarage += grades[j - 1];
                    }
                    bool budget;

                    if (values[6] == "FALSE")
                    {
                        budget = true;
                        numberBudget++;
                    }
                    else
                    {
                        budget = false;
                    }

                    rating.Add(new Student(values[0], grades , budget));
                }
            }

            rating.Sort((x, y) => y.AvarageGrade.CompareTo(x.AvarageGrade));
            Student[] student = rating.ToArray();
            int num = 0, ind = 0;
            double minBudget = 0;
            numberBudget = (int)(numberBudget * 0.4);
            String[] table = new string[numberBudget + 1];
            while (num <= numberBudget)
            {
                if (num == numberBudget)
                {
                    minBudget = student[ind].AvarageGrade;
                }
                if (student[ind].Budget)
                {
                    table[num] = Convert.ToString(student[ind].LastName) + ";" + Convert.ToString(Math.Round(student[ind].AvarageGrade, 3));
                    num++;
                }
                ind++;
            }
            Console.WriteLine(Math.Round(minBudget, 3));
            File.WriteAllLines(@"rating.csv", table, Encoding.Default);
            Console.ReadKey();
        }
    }
}
