using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu
{
	public class Activity : DataToMenu
    {

        private string name, code;
        private Teacher teacher;
        private int ects;
        private static string CODE;

        public Activity(string name, Teacher teacher, int ects, string code="0")
        {
            this.name = name;
            this.teacher = teacher;
            this.ects = ects;
            this.code = (code == "0") ? GenCode() : code;

        }

        //properties
        public string Name
        {
            get { return name; }
        }

        public string Code
        {
            get { return code; }
        }

        public int Ects
        {
            get { return ects; }
        }

        public Teacher Teacher
        {
            get { return teacher; }
        }


        //functions
        public void DisplayActivity()
        {
            Console.WriteLine(string.Format("{0}\n\tEnseigant: {1}\n\tCode: {2}\n\tCredits: {3}", 
                name, teacher.Lastname,code, ects));
        }

        public string GenCode()
        {
            return "TEST";
        }

        public List<Evaluation> GenListofEvaluations()
        {
            List<Evaluation> list_of_evaluations = new List<Evaluation>();
            return list_of_evaluations;
        }


		//Needed For Navigation!
		public override string DisplayInfo()
		{
			return name;
		}

		public override void Show()
		{
			DisplayActivity();
		}
    }
}
