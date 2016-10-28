using System;
namespace ConsoleMenu
{
	public class Link : ElementOfMenu
	{
		private Menu menu;
		public Link(string name, Menu gotomenu) : base(name)
		{
			this.menu = gotomenu;
		}

		//the action of this "ElementOfMenu" is to refer to another menu and display it.
		public override void Action()
		{
			menu.Display();
		}
	}
}
