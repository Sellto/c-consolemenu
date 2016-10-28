using System;
namespace ConsoleMenu
{
	public class ElementOfMenu
	{
		private string name;
		public ElementOfMenu(string name)
		{
			this.name = name;
		}


		public string Name
		{
			get {return name;}
		}

		//Action() is a function that a subclass must have.
		//it defines what launch the selected item
		public virtual void Action()
		{
		}

	}
}
