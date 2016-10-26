using System;
using System.Collections.Generic;
namespace ConsoleMenu
{
	public class MenuGen : Menu
	{
		public MenuGen(string title) : base(title)
		{
		}
		public void AddLink(Menu gotomenu)
			{
			element.Add(new Link(gotomenu.Title, gotomenu));
			}
		public void AddAction(string name,DataToMenu item)
			{
			element.Add(new ElementofListing(name,item,this));
			}

	}
}
