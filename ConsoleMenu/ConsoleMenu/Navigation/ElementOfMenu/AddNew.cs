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
		private static string path = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "Data" + Path.DirectorySeparatorChar + "Files" + Path.DirectorySeparatorChar;
		public AddNew(List<DataToMenu> listing, MenuAuto menu) : base("- Ajouter - -")
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
                File.AppendAllText(Path.Combine(Environment.CurrentDirectory, path + "Students.txt"), lastname+":"+firstname+":"+menu.Title+":"+Generator.Current_id.ToString() + Environment.NewLine);
                Generator.GenStudents();
                Generator.GenStudents_by_year();
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
				File.AppendAllText(Path.Combine(Environment.CurrentDirectory, path +"Teachers.txt"), lastname + ":" + firstname + ":" + teacherid+ ":" + salary + Environment.NewLine);
                Generator.GenTeachers();
                Generator.GenTeacherActivity();
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
                    string code = Generator.GenActivityCode(menu.Title);
                    listing.Add(new Activity(name, tea, ects, menu.Title, code));
                    Generator.List_of_activities = listing;
                    File.AppendAllText(Path.Combine(Environment.CurrentDirectory, path + "Activities.txt"), name + ":" + teacherid + ":" + ects + ":" + code + Environment.NewLine);
                    Generator.GenActivities();
                    Generator.GenActivities_by_year();
                }

            }
            if (listing[0].GetType() == typeof(Evaluation))
            {
                Console.Write("Intitulé : ");
                string name = Console.ReadLine();
				File.AppendAllText(Path.Combine(Environment.CurrentDirectory, path + "Evaluations"+Path.DirectorySeparatorChar+"TITLES.txt"), listing[0].Activity.Code + '.' +  name + Environment.NewLine);
                List<string> appreciations = new List<string> { "N", "C", "B", "TB", "X" };
                List<string> note_num = new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" };

                foreach (Student student in Generator.List_of_students_by_year[listing[0].Activity.Year])
                {
                    if (student.Name != "FirstItem")
                    {
                        Console.Write(student.Id + "\t" + student.Lastname + "\t" + student.Firstname + " ..... ");
                        string note = Console.ReadLine();
                        if (appreciations.Contains(note) || note_num.Contains(note))
                        {
                            listing.Add(new Evaluation(listing[0].Activity, student, name, note));
                            File.AppendAllText(Path.Combine(Environment.CurrentDirectory, string.Format(path + "Evaluations" + Path.DirectorySeparatorChar + "{0}.{1}.txt", listing[0].Activity.Code, name)), student.Id + ':' + note + Environment.NewLine);
                        }
                    }
                }
                Generator.GenEvaluation();
            }
            menu.LoadListing();
			menu.Display();
		}
	}
}
