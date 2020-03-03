using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Student
    {
        public string LastName;
        public int[] Grades = new int[5];
        public bool Budget;
        public double AvarageGrade;
        public Student(string lastName, int[] grades, bool budget)
        {
            LastName = lastName;
            int sum = 0;
            for (int i = 0; i < 5; i++)
            {
                Grades[i] = grades[i];
                sum += grades[i];
            }
            Budget = budget;
            AvarageGrade = sum / 5;
        }
    }
}
