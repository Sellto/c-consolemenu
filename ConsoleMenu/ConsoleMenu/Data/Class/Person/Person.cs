using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu
{
    

	public class Person : DataToMenu
    {
        public string lastname, firstname;
        public Person(string last, string first)
        {
            lastname = last;
            firstname = first;
        }

        //Properties
        public string Firstname
        {
            get { return firstname; }
        }

        public string Lastname
        {
            get { return lastname; }
        }

        public override string Name
        {
            get
            {
                return lastname;
            }
        }



		//Needed For Navigation!
		//function needed when a item of a class can be display into a menu
		public override string DisplayInfo()
		{
			return base.DisplayInfo();
		}

		public override void Show()
		{
			base.Show();
		}
	}
}
