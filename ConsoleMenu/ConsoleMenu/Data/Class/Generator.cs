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
		private static Dictionary<string, List<DataToMenu>> list_of_students_by_year = new Dictionary<string, List<DataToMenu>>();
        private static List<DataToMenu> list_of_students = new List<DataToMenu>();
        private static List<DataToMenu> list_of_teachers = new List<DataToMenu>();
		private static List<DataToMenu> list_of_activities = new List<DataToMenu>();
        private static List<Evaluation> list_of_evaluations = new List<Evaluation>();
        private static Dictionary<string, MenuGen> list_of_activities_by_teachers = new Dictionary<string, MenuGen>();


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
            GenStudents_by_year();
            GenTeachers();
            GenActivities();
            GenEvaluation();
        }

        //Properties
		public static Dictionary<string,List<DataToMenu>> List_of_students_by_year
        {
            get { return list_of_students_by_year;}
            set { list_of_students_by_year = value;}
        }

        public static Dictionary<string, MenuGen> List_Of_Activities_By_Teacher
        {
            get { return list_of_activities_by_teachers; }
        }

        public static List<DataToMenu> List_of_students
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

        public static List<Evaluation> List_of_evaluations
        {
            get { return list_of_evaluations; }
        }

        public static int Current_id

        {
            get { return current_id; }
        }




        //Functions
        public static void GenStudents()
        {
            string[] file = System.IO.File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "..\\..\\Data\\Files\\Students.txt"));
			//string[] file = System.IO.File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../Data/Files/Students.txt"));
            foreach (string line in file)
            {
                string[] parameters = line.Split(':');
                list_of_students.Add(new Student(parameters[0], parameters[1], parameters[2], parameters[3]));
            }
        }


        public static void GenStudents_by_year()
        {
            string[] file = System.IO.File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "..\\..\\Data\\Files\\Year.txt"));
			//string[] file = System.IO.File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../Data/Files/Year.txt"));
	        string[] parameters = file[0].Split(':');
            foreach (string year in parameters)
            {
                list_of_students_by_year.Add(year, new List<DataToMenu>());
            }
            foreach (Student student in List_of_students)
            {
                list_of_students_by_year[student.Year].Add(student);
            }
        }


        public static void GenTeachers()
        {
            string[] file = System.IO.File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "..\\..\\Data\\Files\\Teachers.txt"));
			//string[] file = System.IO.File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../Data/Files/Teachers.txt"));
            foreach (string line in file)
            {
                string[] parameters = line.Split(':');
				list_of_teachers.Add(new Teacher(parameters[0], parameters[1], parameters[2].ToUpper(), 2000));
            }
        }


        public static void GenActivities()
        {
            string[] file = System.IO.File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "..\\..\\Data\\Files\\Activities.txt"));
			//string[] file = System.IO.File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../Data/Files/Activities.txt"));
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
                list_of_activities.Add(new Activity(parameters[0], tea, Int32.Parse(parameters[2]), parameters[3]));
            }

        }


        public static void GenEvaluation()
        {
            string[] file = System.IO.File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "..\\..\\Data\\Files\\Evaluations\\TITLES.txt"));
			//string[] file = System.IO.File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../Data/Files/Evaluations/TITLES.txt"));
            foreach(string title in file)
            {
                string[] param_title = title.Split('.');

                string[] eval = System.IO.File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, string.Format("..\\..\\Data\\Files\\Evaluations\\{0}.txt", title)));
				//string[] eval = System.IO.File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, string.Format("../../Data/Files/Evaluations/{0}.txt", title)));
                foreach(string evaluation in eval)
                {
                    string[] param_eval = evaluation.Split(':');
                    list_of_evaluations.Add(new Evaluation(SearchActivity(param_title[0]), SearchStudent(param_eval[0]), param_title[1], Int32.Parse(param_eval[1]) ));
                }
            }
        }


        public static Student SearchStudent(string id)
        {
            foreach(Student student in list_of_students)
            {   
                if (student.Id == id)
                {
                    return student;
                }
            }
            return null;
        }


        public static Activity SearchActivity(string code)
        {
            foreach (Activity activity in list_of_activities)
            {
                if (activity.Code == code)
                {
                    return activity;
                }
            }
            return null;
        }


        public int GenCurrentID()
        {
            string[] file = System.IO.File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "..\\..\\Data\\Files\\Generator.txt"));
			//string[] file = System.IO.File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../Data/Files/Generator.txt"));
            string[] parameters = file[0].Split(':');
            return Int32.Parse(parameters[1]);
        }
		

		 public static string GenID()
        {

            current_id += 1 ;
            ModificationOfGeneratorFileByID("ID");
            return current_id.ToString();
        }


        public static Dictionary<string, MenuGen> GenTeacherActivityMenu()
        {
            foreach (Teacher teacher in List_of_teachers)
            {
                if (!list_of_activities_by_teachers.ContainsKey(teacher.Trigram))
                {
                    list_of_activities_by_teachers.Add(teacher.Trigram, new MenuGen("Listes des Activité de "+teacher.Lastname+" "+teacher.firstname));
                }
            }
            foreach (Activity activity in List_of_activities)
            {
                
                list_of_activities_by_teachers[activity.Teacher.Trigram].AddAction(activity.Name, activity);
                
            }
            return list_of_activities_by_teachers;
        }
            


        public static void ModificationOfGeneratorFileByID(string id)
        {
			//var path = Path.Combine(Environment.CurrentDirectory, "../../Data/Files/Generator.txt");
            var path = Path.Combine(Environment.CurrentDirectory, "..\\..\\Data\\Files\\Generator.txt");
            string[] file = System.IO.File.ReadAllLines(path);
            File.WriteAllText(path, String.Empty);
            foreach (string line in file)
            {
                string[] parameters = line.Split(':');
                if (parameters[0] == id)
                {

                    File.AppendAllText(path, parameters[0] + ":" + current_id);
                }
                else
                {
                    File.AppendAllText(path, line);
                }
            }
        }
    }
}

