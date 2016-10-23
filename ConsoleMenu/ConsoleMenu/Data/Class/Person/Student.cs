﻿using System;
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
            //bulletin = new Bulletin();
            this.year = year;
            this.id = (id == "0") ? GenID() : id;
        }

        //properties
        public string Id
        {
            get { return id; }
        }

        public string Year
        {
            get { return year; }
        }


        //functions
        public string GenID()
        {
            return "TEST";
        }


        /*public bool CheckYear(string y){
         * bool valid = true;
         * return valid*/

        public List<Activity> GenListofActivities()
        {
            List<Activity>  Listofact = new List<Activity>();
            foreach (Activity activity in Generator.List_of_activities)
            {
                if (activity.Code.Split('-')[0] == year)
                {
                    Listofact.Add(activity);
                }
				return Listofact;
            }

            return Listofact;
        }



		//Needed For Navigation!
		public override void Show()
		{
			base.Show();
			Console.WriteLine("Under Construct");

		}

        public override string DisplayInfo()
        {
            return string.Format("{0} - {1}"+" "+"{2}", id, Lastname, Firstname);

        }

    }
}
