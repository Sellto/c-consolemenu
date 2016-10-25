using System;
using System.Collections.Generic;
namespace ConsoleMenu
{
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
				element.Add(new ElementofListing(item.DisplayInfo(),item,this));
			}
			
		}
	}
}
