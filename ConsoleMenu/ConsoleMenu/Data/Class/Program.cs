using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu
{
    class Program
    {

        static void Main(string[] args)
        {
            Generator gen = Generator.GetInstance();
            foreach(Student student in Generator.List_of_students)
            {
                student.DisplayInfo();
            }

            Console.ReadKey();


        }
    }
}
