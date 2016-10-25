using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu
{
	public class Student : Person
	{
        private string id, year;
        private Bulletin bulletin;



        public Student(string first, string last, string year, string id="0") :
            base(first, last)
        {           
            this.year = year;
            this.id = (id == "0") ? Generator.GenID() : id;
            bulletin = new Bulletin(this.id, year);
        }

        //Properties
        public string Id
        {
            get { return id; }
        }

        public string Year
        {
            get { return year; }
        }


        //Functions

        public List<Activity> SearchActivities()
        {
            List<Activity>  Listofact = new List<Activity>();
            foreach (Activity activity in Generator.List_of_activities)
            {
                if (activity.Code.Split('_')[0] == year)
                {
                    Listofact.Add(activity);
                }
            }

            return Listofact;
        }



		//Needed For Navigation!


        public override string DisplayInfo()
        {
            return string.Format("{0} - {1}"+" "+"{2}", id, Lastname, Firstname);

        }

		public override void Show()
		{
			base.Show();
			foreach (string act_title in bulletin.SearchActivities())
			{
				Console.WriteLine("\t" + act_title);
			}
			Console.WriteLine();
			bulletin.DisplayBulletin();
			//Console.WriteLine("Under Construct");
		}
    }
}
