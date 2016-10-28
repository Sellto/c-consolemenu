﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu
{
	public class Teacher : Person
    {
        private string trigram;
        private int salary;

        public Teacher(string last, string first, string tri, int sal) :
            base(last, first)
        {
            trigram = tri;
            salary = sal;
            //GenListofActivities();
        }


        //Properties
        public string Trigram
        {
            get { return trigram; }
            set { trigram = value; }
        }

        public int Salary
        {
            get { return salary; }
            set { salary = value; }
        }



        //functions
        public bool CheckTrigram(string tri)
        {
            bool valid = true;
            foreach(Teacher teacher in Generator.List_of_teachers)
            {
                if(teacher.Trigram == tri)
                {
                    valid = false;
                    break;
                }
            }
            return valid;
        }




		//Needed For Navigation!
		public override void Show()
		{
            Console.WriteLine("--- Informations Générales ---");
            Console.WriteLine("Nom        :" + this.Lastname);
            Console.WriteLine("Prénom     :" + this.Firstname);
            Console.WriteLine("Salaire    :" + this.salary);
            Console.WriteLine("\t");
            Console.WriteLine("--- Listes des Cours ---\n");
            foreach (Activity activity in Generator.List_of_activities)
            {
                if (activity.Teacher.Trigram == trigram)
                {
                    Console.WriteLine("\t" + activity.DisplayInfo());
                }
            }
        }



		public override string DisplayInfo()
		{
			return string.Format("{0} - {1}" + " " + "{2}", trigram, Lastname, Firstname);
		}
    }
}
