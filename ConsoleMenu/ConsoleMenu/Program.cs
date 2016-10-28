using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ConsoleMenu
{
	class MainClass
	{
		public static void Main(string[] args)
		{

            Generator.GetInstance();
            MenuGen main = new MenuGen("Menu Principal");
			MenuGen student_listing = new MenuGen("Liste des Etudiants");
			foreach (var item in Generator.List_of_students_by_year)
			{
				student_listing.AddLink(new MenuAuto(item.Key, Generator.List_of_students_by_year[item.Key]));
			}
			main.AddLink(student_listing);
			MenuAuto teacher_listing = new MenuAuto("Liste des Professeurs",Generator.List_of_teachers);
			main.AddLink(teacher_listing);
			MenuGen activities_listing = new MenuGen("Liste des Activitées");
			foreach (var item in Generator.List_of_Activities_by_year)
			{
				activities_listing.AddLink(new MenuAuto(item.Key, Generator.List_of_Activities_by_year[item.Key]));
			}
			main.AddLink(activities_listing);
            main.Display();
		}
	}
}
