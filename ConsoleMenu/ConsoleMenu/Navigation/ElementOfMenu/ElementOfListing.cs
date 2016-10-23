using System;
using System.Collections.Generic;
namespace ConsoleMenu
{
	public class ElementofListing : ElementOfMenu
	{

		private DataToMenu item;
		private Menu menu;
		public ElementofListing(string name, DataToMenu item,Menu menu) : base(name)
		{
			this.item = item;
			this.menu = menu;
		}

		public override void Action()
		{
			item.Show();
			Console.ReadLine();
			menu.Display();
		}
	}
}
