using System;
namespace ConsoleMenu
{
	public class DataToMenu
	{
        public virtual string Name { get; set; }

        public virtual Activity Activity { get; set; }
		public virtual string DisplayInfo() { return "";}
		public virtual void  Show() { }
	}
}
