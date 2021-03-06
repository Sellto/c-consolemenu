﻿using System.Collections.Generic;

namespace ConsoleMenu
{
	//MenuAuto = Autogenerated menu from a listing of item.
	public class MenuAuto : Menu
	{
		private List<DataToMenu> listing;
		public MenuAuto(string title, List<DataToMenu> listing ) : base(title)
		{
			this.listing = listing;
			this.LoadListing();

		}
		public void LoadListing()
		{
			element.Clear();
            element.Add(new AddNew(listing, this));
            foreach (DataToMenu item in listing)
			{
				//All of listing of DataToMenu Item called "FirstItem"
				//This Item is used in the Action() method of the Class AddNew to know the SubClass of DataToMenu to Add
				//We Hide this item in the menu
				//How is displayed the item is defined in function DisplayInfo() of the DataToMenu's function
				if (item.Name != "FirstItem")
                {
                    element.Add(new ElementofListing(item.DisplayInfo(), item, this));
                }
                
			}
			
		}
	}
}
