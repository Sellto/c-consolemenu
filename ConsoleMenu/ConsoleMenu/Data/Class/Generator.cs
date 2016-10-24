using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleMenu
{
    public class Generator
    {
		private static Dictionary<string, List<DataToMenu>> list_of_students = new Dictionary<string, List<DataToMenu>>();
		private static List<DataToMenu> list_of_teachers = new List<DataToMenu>();
		private static List<DataToMenu> list_of_activities = new List<DataToMenu>();
        private static List<string> list_of_titles_evaluations = new List<string>();
        private static List<Evaluation> list_of_evaluations = new List<Evaluation>();


        private static int current_id;

        //Avoid multiple instances of Generator
        private static readonly Generator generator = new Generator();

        public static Generator GetInstance()
        {
            return generator;
        }

        private Generator()
        {

            current_id = GenCurrentID();
            GenStudents();
            GenTeachers();
            GenActivities();
            
        }

        //Properties
		public static Dictionary<string,List<DataToMenu>> List_of_students
        {
            get { return list_of_students; }
            set { list_of_students = value; }
        }

		public static List<DataToMenu> List_of_teachers
        {
            get { return list_of_teachers; }
            set { list_of_teachers = value; }
        }

		public static List<DataToMenu> List_of_activities
        {
            get { return list_of_activities; }
            set { list_of_activities = value; }
        }

        public static int Current_id

        {
            get { return current_id; }
        }




        //functions
        public static void GenStudents()
        {
            string[] file = System.IO.File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "..\\..\\Data\\Files\\Students.txt"));
			foreach (string line in file)
			{
				string[] parameters = line.Split(':');
				if (!list_of_students.ContainsKey(parameters[2]))
				{
					list_of_students.Add(parameters[2], new List<DataToMenu>());
				}
				list_of_students[parameters[2]].Add(new Student(parameters[0], parameters[1], parameters[2], parameters[3]));
			}
        }



        public static void GenTeachers()
        {
            string[] file = System.IO.File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "..\\..\\Data\\Files\\Teachers.txt"));

            foreach (string line in file)
            {
                string[] parameters = line.Split(':');
				list_of_teachers.Add(new Teacher(parameters[0], parameters[1], parameters[2].ToUpper(), 2000));
            }
        }


        public static void GenActivities()
        {
            string[] file = System.IO.File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "..\\..\\Data\\Files\\Activities.txt"));

            foreach (string line in file)
            {
                string[] parameters = line.Split(':');

                //Gets the teacher of the activity based on its 'trigram'
                Teacher tea = null;
                foreach(Teacher teacher in list_of_teachers)
                {
					if (parameters[1].ToUpper() == teacher.Trigram.ToUpper())
                    {
						tea = teacher;
						tea.Trigram = tea.Trigram.ToUpper();
                        break;
                    }
                }
                list_of_activities.Add(new Activity(parameters[0], tea, Int32.Parse(parameters[2])));
            }

        }


        public static void GenEvaluation()
        {
            string[] file = System.IO.File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "..\\..\\Data\\Files\\Evaluations\\TITLES.txt"));

            foreach(string title in file)
            {
                string[] param_title = title.Split('.');
                string[] eval = System.IO.File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, string.Format("..\\..\\Data\\Files\\Evaluations\\{0}.txt", title)));


                Activity current_activity;

                foreach(string evaluation in eval)
                {
                    string[] param_eval = evaluation.Split(':');
                    //list_of_evaluations.Add(new Evaluation("", ));
                }
            }
        }


        //public static Student SearchStudent(string id)
        //{
            //foreach(Student student in )
        //}






        public int GenCurrentID()
        {
            string[] file = System.IO.File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "..\\..\\Data\\Files\\Generator.txt"));
            string[] parameters = file[0].Split(':');
            return Int32.Parse(parameters[1]);
        }
		
		 public static string GenID()
        {

            current_id += 1 ;
            ModificationOfGeneratorFileByID("ID");
            return current_id.ToString();
        }

        public static void ModificationOfGeneratorFileByID(string id)
        {
            string[] file = System.IO.File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "..\\..\\Data\\Files\\Generator.txt"));
            foreach (string line in file)
            {
                string[] parameters = line.Split(':');
                if (parameters[0] == id)
                {

                    File.WriteAllLines(Path.Combine(Environment.CurrentDirectory, "..\\..\\Data\\Files\\Generator.txt"), parameters[0] + ":" + current_id);
                }
                else
                {
                    File.AppendAllText(Path.Combine(Environment.CurrentDirectory, "..\\..\\Data\\Files\\Generator.txt"), line);
                }
            }
        }
    }
}

