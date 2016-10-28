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
		private static Dictionary<string, List<DataToMenu>> list_of_students_by_year;
        private static List<DataToMenu> list_of_students;
        private static List<DataToMenu> list_of_teachers;
		private static List<DataToMenu> list_of_activities;
        private static List<Evaluation> list_of_evaluations;
        private static Dictionary<string, List<Activity>> list_of_activities_by_teachers = new Dictionary<string,List<Activity>>();
		private static Dictionary<string, List<DataToMenu>> list_of_activities_by_year;
		private static string path = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "Data" + Path.DirectorySeparatorChar + "Files" + Path.DirectorySeparatorChar;
        private static int current_id;
		private static Dictionary<string, string> current_activities_code = new Dictionary<string, string>();

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
            GenTeacherActivity();
            GenCurrentActivitiesCode();
			GenActivities_by_year();

        }

        //Properties
		public static Dictionary<string,List<DataToMenu>> List_of_students_by_year
        {
            get { return list_of_students_by_year;}
            set { list_of_students_by_year = value;}
        }

		public static Dictionary<string, List<DataToMenu>> List_of_Activities_by_year
		{
			get { return list_of_activities_by_year;}
			set { list_of_activities_by_year = value; }
		}

        public static Dictionary<string, List<Activity>> List_Of_Activities_By_Teacher
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

        public static Dictionary<string, string> Current_activities_code
        {
            get { return current_activities_code; }
        }




        //Functions
        public static void GenStudents()
        {
            list_of_students = new List<DataToMenu>();
            string[] file = System.IO.File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, path+"Students.txt"));
            foreach (string line in file)
            {
                string[] parameters = line.Split(':');
                list_of_students.Add(new Student(parameters[0], parameters[1], parameters[2], parameters[3]));
            }
        }


        public static void GenStudents_by_year()
        {
            list_of_students_by_year = new Dictionary<string, List<DataToMenu>>();

            string[] file = System.IO.File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, path+"Year.txt"));
	        string[] parameters = file[0].Split(':');
			foreach (string year in parameters)
            {
				list_of_students_by_year.Add(year, new List<DataToMenu>());
                list_of_students_by_year[year].Add(new Student("FirstItem","FirstItem",year,"64000"));
            }

            foreach (Student student in List_of_students)
            {
                list_of_students_by_year[student.Year].Add(student);
            }
        }

        public static Student SearchStudent(string id)
        {
            foreach (Student student in list_of_students)
            {
                if (student.Id == id)
                {
                    return student;
                }
            }
            return null;
        }


        public static void GenTeachers()
        {
            list_of_teachers = new List<DataToMenu>();
            string[] file = System.IO.File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, path +"Teachers.txt"));
            foreach (string line in file)
            {
                string[] parameters = line.Split(':');
                list_of_teachers.Add(new Teacher("FirstItem", "FirstItem", "FirstItem", 0));
				list_of_teachers.Add(new Teacher(parameters[0], parameters[1], parameters[2].ToUpper(), Int32.Parse(parameters[3])));
            }
        }


        public static void GenActivities()
        {
            list_of_activities = new List<DataToMenu>();

            string[] file = System.IO.File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, path + "Activities.txt"));
            foreach (string line in file)
            {
                string[] parameters = line.Split(':');
				string[] splitingcode = parameters[3].Split('_');
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
				list_of_activities.Add(new Activity(parameters[0], tea, Int32.Parse(parameters[2]),splitingcode[0], parameters[3]));
            }

        }

		public static void GenActivities_by_year()
		{
            list_of_activities_by_year = new Dictionary<string, List<DataToMenu>>();

            string[] file = System.IO.File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, path + "Year.txt"));
			string[] parameters = file[0].Split(':');
			foreach (string year in parameters)
			{
				list_of_activities_by_year.Add(year, new List<DataToMenu>());
                list_of_activities_by_year[year].Add(new Activity("FirstItem", new Teacher("FirstItem", "FirstItem", "FirstItem", 0),0,year, "FirstItem"));
            }
			foreach (Activity activity in List_of_activities)
			{
				list_of_activities_by_year[activity.Year].Add(activity);
			}
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


        public static void GenEvaluation()
        {   
            list_of_evaluations = new List<Evaluation>();

            string[] file = System.IO.File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, path + "Evaluations"+Path.DirectorySeparatorChar+ "TITLES.txt"));
            foreach(string title in file)
            {
                string[] param_title = title.Split('.');

                if (title != "")
                {
                    string[] eval = System.IO.File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, string.Format(path + "Evaluations"+Path.DirectorySeparatorChar+"{0}.txt", title)));
                    foreach (string evaluation in eval)
                    {
                        string[] param_eval = evaluation.Split(':');
                        list_of_evaluations.Add(new Evaluation(SearchActivity(param_title[0]), SearchStudent(param_eval[0]), param_title[1], param_eval[1]));
                    }
                }
                
            }
        }
        

        public static void GenCurrentActivitiesCode()
        {
            string[] file = System.IO.File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, path + "Generator.txt"));
            for(int i=0; i<5; i++)
            {
                string[] parameters = file[i + 1].Split(':');
                current_activities_code.Add(parameters[0], parameters[1]);
            }
        }


        public static string GenActivityCode(string year)
        {
            string current_code = current_activities_code["CODE_" + year];
            int next_max = Int32.Parse(current_code.Split('_')[1]) + 1;
            string new_code = string.Format("{0}_{1}", year, next_max.ToString());
            current_activities_code["CODE_" + year] = new_code;
			ModificationOfGeneratorFileByID("CODE_" + year, new_code);
            return new_code;
        }


        public int GenCurrentID()
        {
            string[] file = System.IO.File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, path + "Generator.txt"));
            string[] parameters = file[0].Split(':');
            return Int32.Parse(parameters[1]);
        }
		

		 public static string GenID()
        {
            current_id += 1 ;
			ModificationOfGeneratorFileByID("ID",current_id.ToString());
            return current_id.ToString();
        }


        public static Dictionary<string, List<Activity>> GenTeacherActivity()
        {
            foreach (Teacher teacher in List_of_teachers)
            {
                if (!list_of_activities_by_teachers.ContainsKey(teacher.Trigram))
                {
                    list_of_activities_by_teachers.Add(teacher.Trigram,new List<Activity>());
                }
            }
            foreach (Activity activity in List_of_activities)
            {

               list_of_activities_by_teachers[activity.Teacher.Trigram].Add(activity);
                
            }
            return list_of_activities_by_teachers;
        }
            


        public static void ModificationOfGeneratorFileByID(string id,string newentry)
        {
            var pathfile = Path.Combine(Environment.CurrentDirectory, path + "Generator.txt");
            string[] file = System.IO.File.ReadAllLines(pathfile);
			File.WriteAllText(pathfile, String.Empty);
            foreach (string line in file)
            {
                string[] parameters = line.Split(':');
                if (parameters[0] == id)
                {
                    File.AppendAllText(pathfile, parameters[0] + ":" + newentry+"\n");
                }
                else
                {
                    File.AppendAllText(pathfile, line+"\n");
                }

            }
        }
    }
}

