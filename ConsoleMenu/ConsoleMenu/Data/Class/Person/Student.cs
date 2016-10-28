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
        public Student(string last, string first, string year, string id="0") :base(last, first)
        {           
            this.year = year;
            this.id = (id == "0") ? Generator.GenID() : id;
            bulletin = new Bulletin(this.id, this.year);
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



		//Needed For Navigation!
		//function needed when a item of a class can be display into a menu
        public override string DisplayInfo()
        {
            return string.Format("{0} - {1}"+" "+"{2}", id, Lastname, Firstname);

        }

		public override void Show()
		{
			base.Show();
			Console.WriteLine();
			bulletin.DisplayBulletin();
		}
    }
}
