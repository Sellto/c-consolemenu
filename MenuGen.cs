using System;
namespace ConsoleMenu
{
	public class MenuGen : Menu
	{
		public MenuGen(string menuID, string title) : base(menuID, title)
		{
		}
		public void AddLink(Menu gotomenu)
			{
			element.Add(new Link(gotomenu.Title, gotomenu));
			}
		public void AddAction(string name)
			{
				element.Add(new ElementOfMenu(name));
			}

	}
}
