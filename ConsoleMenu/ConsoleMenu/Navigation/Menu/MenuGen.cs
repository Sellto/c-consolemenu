using System;
using System.Collections.Generic;
namespace ConsoleMenu
{

	//MenuGen = to create manually the menu
	public class MenuGen : Menu
	{
		public MenuGen(string title) : base(title)
		{
		}

		//add an item into the menu whose action is to refer to another menu.
		public void AddLink(Menu gotomenu)
			{
			element.Add(new Link(gotomenu.Title, gotomenu));
			}


		//add an item into the menu whose action is the function Action() of the item.
		public void AddAction(string name,DataToMenu item)
			{
			element.Add(new ElementofListing(name,item,this));
			}
	}
}
