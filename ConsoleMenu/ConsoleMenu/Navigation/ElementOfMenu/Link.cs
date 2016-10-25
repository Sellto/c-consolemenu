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
		public override void Action()
		{
			menu.Display();
		}
	}
}
