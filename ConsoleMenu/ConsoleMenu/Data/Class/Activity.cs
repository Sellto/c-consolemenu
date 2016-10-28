using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleMenu
{
	public class Activity : DataToMenu
	{

		private string name, code, year;
		private Teacher teacher;
		private int ects;


		public Activity(string name, Teacher teacher, int ects, string year, string code)
		{
			this.name = name;
			this.teacher = teacher;
			this.ects = ects;
			this.code = code;
			this.year = year;

		}

		//properties
		public override string Name
		{
			get { return name; }
		}

		public string Code
		{
			get { return code; }
		}

		public string Year
		{
			get { return year; }
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
				name, teacher.Lastname, this.code, ects));
		}


		public List<Evaluation> GenListofEvaluations()
		{
			List<Evaluation> list_of_evaluations = new List<Evaluation>();
			return list_of_evaluations;
		}


		//Needed For Navigation!
		public override string DisplayInfo()
		{
			return  this.Code + " - " + this.Name;
		}

		public override void Show()
		{
			List<DataToMenu> Listing = new List<DataToMenu>();
            List<string> titles = new List<string>();
            
            

            foreach (Evaluation eval in Generator.List_of_evaluations)
            {
                if (eval.Activity == this && !titles.Contains(eval.Title))
                {
                    Listing.Add(eval);
                    titles.Add(eval.Title);
                    //Console.WriteLine(eval.Title + " : " + eval.Student.Id + " : "  + eval.GetNote());
                }
            }

            if (Listing.Count == 0)
            {
                Listing.Add(new Evaluation(this, new Student("FirstItem", "FirstItem", "FirstItem"), "FirstItem"));
            }

            MenuAuto listing_of_evaluations = new MenuAuto("évaluations de l'activité : " + this.Name, Listing);
            listing_of_evaluations.Display();
        }
 
	}
}