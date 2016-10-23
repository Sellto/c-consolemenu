using System;
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

        public Teacher(string first, string last, string tri, int sal) :
            base(first, last)
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
			base.Show();
			foreach (Activity activity in Generator.List_of_activities)
			{
				try
				{
					if (activity.Teacher.Trigram.ToUpper() == trigram.ToUpper())
					{
						Console.WriteLine(string.Format("Cours: {0}\tCode: {1}\tCrédits: {2}",
							activity.Name, activity.Code, activity.Ects));
					}
				}
				catch
				{ 
				}
			}
		}



		public override string DisplayInfo()
		{
			return string.Format("{0} - {1}" + " " + "{2}", trigram, Lastname, Firstname);
		}
    }
}
