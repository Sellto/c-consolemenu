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
		public virtual void Action()
		{
			Console.WriteLine("Pas d'Action");
		}

	}
}
