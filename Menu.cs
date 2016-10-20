using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleMenu
{
	public class Menu
	{
		private static List<Menu> allofmenu = new List<Menu>();
		private string title;
		private string menuID;
		private int maxY;
		protected List<ElementOfMenu> element = new List<ElementOfMenu>();

		public Menu(string menuID, string title)
		{
			this.title = title;
			this.menuID = menuID;
			allofmenu.Add(this);
		}
		public string Title
		{
			get { return title; }
		}
		public string MenuID
		{
			get { return menuID; }
		}

		public void Display()
		{
			int positiony = 0;
			bool selection = false;
			Console.CursorVisible = false;
			if (this.Title != allofmenu[0].Title)
			{ 
				element.Add(new ElementOfMenu(allofmenu[0].Title));
			}
			while (!selection)
			{
				Console.SetCursorPosition(0, 0);
				Console.WriteLine(" --- " + title + " --- ");
				for (int i = 0; i < element.Count; i++)
				{
					if (i == positiony)
					{
						Console.BackgroundColor = ConsoleColor.Black;
						Console.ForegroundColor = ConsoleColor.White;
					}
					Console.Write(element[i].Name);
					for (int j = 0; j < ((Console.WindowWidth - 1) - element[i].Name.Length); j++)
					{
						Console.Write(" ");
					}
					Console.WriteLine(" ");
					Console.ResetColor();
				}
				maxY = Console.CursorTop - element.Count - 2;
				var k = Console.ReadKey();
				if ((k.Key == ConsoleKey.DownArrow) && (positiony < maxY))
				{
					positiony++;
				}
				if ((k.Key == ConsoleKey.UpArrow) && (positiony != 0))
				{
					positiony--;
				}
				if (k.Key == ConsoleKey.Enter)
				{
					selection = true;
					Console.SetCursorPosition(0, 0);
					for (int i = 0; i < Console.WindowHeight; i++)
					{
						for (int j = 0; j < Console.WindowWidth; j++)
						{
							Console.Write(" ");
						}
					}
					Console.SetCursorPosition(0, 0);
				}
			}
			{
				if (allofmenu[0].Title == element[positiony].Name)
				{
					allofmenu[0].Display();
				}
				else
				{
					element[positiony].Action();
				}

			}
		}
	}
}
