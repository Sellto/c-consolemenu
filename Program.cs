using System;
using System.Collections.Generic;
using System.Reflection;

namespace ConsoleMenu
{
	class MainClass
	{
		public static void Main(string[] args)
		{

			//Declaration de tout les menu.
			//Le premier menu sera consider comme le menu principale... un retour vers celui ci est automatiquement crée.
			MenuGen MainMenu = new MenuGen("newmenu","Menu Principale");
			MenuGen secondmenu = new MenuGen("secondmenu", "Test de Lien3");
			MenuGen thirdmenu = new MenuGen("thirdmenu", "Test de Lien2");

			//Ajout des Element de menu
			MainMenu.AddLink(secondmenu);
			MainMenu.AddLink(thirdmenu);
			secondmenu.AddLink(thirdmenu);
			thirdmenu.AddAction("Test");
			MainMenu.Display();
		}
	}
}
