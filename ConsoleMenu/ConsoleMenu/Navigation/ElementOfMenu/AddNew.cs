using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace ConsoleMenu
{
	public class AddNew : ElementOfMenu
	{
		private MenuAuto menu;
		private List<DataToMenu> listing;
		public AddNew(List<DataToMenu> listing, MenuAuto menu) : base("Ajouter")
		{
			this.listing = listing;
			this.menu = menu;
		}
		public override void Action()
		{
			if (listing[0].GetType() == typeof(Student))
			{
				Console.Write("Nom : ");
				string lastname = Console.ReadLine();
				Console.Write("Prénom : ");
				string firstname = Console.ReadLine();
				listing.Add(new Student(firstname, lastname, menu.Title));
                Generator.List_of_students[menu.Title] = listing;
				File.AppendAllText(Path.Combine(Environment.CurrentDirectory, "..\\..\\Data\\Files\\Students.txt"), Environment.NewLine+lastname+":"+firstname+":"+menu.Title+":"+Generator.Current_id.ToString());
			}
			if (listing[0].GetType() == typeof(Teacher))
			{
				Console.Write("Nom : ");
				string lastname = Console.ReadLine();
				Console.Write("Prénom : ");
				string firstname = Console.ReadLine();
				Console.Write("Trigramme : ");
				string teacherid = Console.ReadLine();
				Console.Write("Salaire : ");
				int salary = Int32.Parse(Console.ReadLine());
				listing.Add(new Teacher(firstname,lastname,teacherid,salary));
                Generator.List_of_teachers = listing;
				File.AppendAllText(Path.Combine(Environment.CurrentDirectory, "..\\..\\Data\\Files\\Teachers.txt"), Environment.NewLine + lastname + ":" + firstname + ":" + teacherid+ ":" + salary);
			}
			if (listing[0].GetType() == typeof(Activity))
			{
				Console.Write("Intitulé : ");
				string name = Console.ReadLine();
				Console.Write("Professeur(Trigramme) : ");
				string teacherid = Console.ReadLine().ToUpper();
				Teacher tea = null;
				foreach (Teacher teacher in Generator.List_of_teachers)
				{
					if (teacherid == teacher.Trigram.ToUpper())
					{
						tea = teacher;
						tea.Trigram = tea.Trigram.ToUpper();
						break;
					}
				}
                if (tea == null)
                {
                    Console.WriteLine("Ce Trigramme n'est associé à aucun professeur \n");
                    Console.ReadLine();
                }
                else
                {
                    Console.Write("ECTS : ");
                    int ects = Int32.Parse(Console.ReadLine());
                    listing.Add(new Activity(name, tea, ects));
                    Generator.List_of_activities = listing;
                    File.AppendAllText(Path.Combine(Environment.CurrentDirectory, "..\\..\\Data\\Files\\Activities.txt"), Environment.NewLine + name + ":" + teacherid + ":" + ects + "0");
                }
				
			}
			menu.LoadListing();
			menu.Display();
		}
	}
}
