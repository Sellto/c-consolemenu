using System;
namespace ConsoleMenu
{

	//Abstract Class to reunite all the classes whose element may be included into a menu
	public class DataToMenu
	{
        public virtual string Name { get; set; }
        public virtual Activity Activity { get; set; }
		public virtual string DisplayInfo() { return "";}
		public virtual void  Show() { }
	}
}
