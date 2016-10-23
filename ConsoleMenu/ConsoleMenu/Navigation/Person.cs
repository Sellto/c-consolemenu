using System;
namespace ConsoleMenu
{
	public class Person
	{
		private string firstname,lastname;
		public Person(string firstname, string lastname)
		{
			this.firstname = firstname;
			this.lastname = lastname;
		}

		public string Displayname()
		{
			return lastname + firstname;
		}
	}
}
