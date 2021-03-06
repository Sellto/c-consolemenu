﻿using System;
using System.Collections.Generic;


namespace ConsoleMenu
{
	//Post-Condition : The First Menu Created Will Be the MainMenu!
	public class Menu
	{
		private static List<Menu> allofmenu = new List<Menu>();
		private string title;
		private int maxY;
		protected List<ElementOfMenu> element = new List<ElementOfMenu>();

		public Menu(string title)
		{
			this.title = title;
			allofmenu.Add(this);
		}
		public string Title
		{
			get { return title; }
		}


		// The function Display() defined how the navigation works
		public void Display()
		{
			int positiony = 0;
			bool selection = false;
			Console.CursorVisible = false;
            try
            {
                if ((this.Title != allofmenu[0].Title) && (element[element.Count - 1].Name != allofmenu[0].Title))
                {
                    //Add a link to First Menu created in last position to the screen.
					element.Add(new ElementOfMenu(allofmenu[0].Title));
                }
            }
            catch
            {
            }
			while (!selection)
			{
				Console.SetCursorPosition(0, 0);
				Console.WriteLine(" --------- " + title + " ---------- ");
				for (int i = 0; i < element.Count; i++)
				{
					if (i == positiony)
					{
						//Color of Selected Item
						Console.BackgroundColor = ConsoleColor.White;
						Console.ForegroundColor = ConsoleColor.Black;
					}
					Console.Write("- " + element[i].Name);
					for (int j = 0; j < ((Console.WindowWidth-4) - element[i].Name.Length); j++)
					{
						Console.Write(" ");
					}
					Console.WriteLine(" ");
					Console.ResetColor();
				}
				maxY = Console.CursorTop-2;
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
					//Clear Screen Without use Console.Clear() method.
					//Real clear,no scrollDown in console prompt
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
					//Back to First Menu Created
					allofmenu[0].Display();
				}
				else
				{
					//Launch the action of the selected item
					element[positiony].Action();
				}

			}
		}
	}
}
