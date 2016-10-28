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



        //Functions
        public string DisplayName()
        {
            return string.Format("Nom: {0}\tPrenom: {1}", lastname, firstname);
        }
		public override string DisplayInfo()
		{
			return this.DisplayName();
		}

		public override void Show()
		{
			Console.WriteLine(" --- " + lastname + " " + firstname + " --- \n");
		}


	}
}
