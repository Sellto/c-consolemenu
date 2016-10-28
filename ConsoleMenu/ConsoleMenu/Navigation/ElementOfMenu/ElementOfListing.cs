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
			Console.ReadKey();

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

			//back to Previous menu.
			menu.Display();
		}
	}
}
