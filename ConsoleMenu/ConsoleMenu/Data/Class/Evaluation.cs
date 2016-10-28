using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu
{
	public class Evaluation:DataToMenu
    {
        private Activity activity;
		private Student student;
        private string title;
        private int note;
        private string appreciation;
        private Dictionary<string, int> conversionAN = new Dictionary<string, int>();
        private bool is_numerical = true;

        public Evaluation(Activity activity, Student student, string title, string cote = "default")
        {
            this.activity = activity;
            this.student = student;
            this.title = title;

            try { this.note = Int32.Parse(cote); }
            catch
            {
                this.appreciation = cote;
                is_numerical = false;
            }
                  
            conversionAN.Add("N", 4);
            conversionAN.Add("C", 8);
            conversionAN.Add("B", 12);
            conversionAN.Add("TB", 16);
            conversionAN.Add("X", 20);
        }


        //Properties
        public int Note
        {
            get { return note; }
        }   

        public string Appreciation
        {
            get { return appreciation; }
        }

        public override Activity Activity
        {
            get { return activity; }
        }
		
		public Student Student
        {
            get { return student; }
        }

        public string Title
        {
            get { return title; }
        }

        public override string Name
        {
            get { return title; }
        }


        //Functions
        public void SetNote(int new_note)
        {
            note = new_note;
        }

        public void SetAppreciation(string app)
        {
            appreciation = app;
        }
		
        public string GetNote()
        {
            if (is_numerical)
            {
                return note.ToString();
            }
            else
            {
                return appreciation;
            }
        }


		public int GetNumNote()
        {
            int num_note = (is_numerical) ? this.note : conversionAN[appreciation];
            return num_note;
        }

        public void DisplayEvaluation()
        {
            Console.WriteLine("\n" + activity.Name + "\n\n\t" + title + ":\t" + student.Id + "\t" + GetNote() );
        }


		//Needed For Navigation!
		//function needed when a item of a class can be display into a menu
		public override string DisplayInfo()
		{
            return this.Title;
		}

		public override void Show()
		{
            Console.WriteLine(this.Title);
            foreach (Evaluation eval in Generator.List_of_evaluations)
            {
                if (eval.Title == this.Title)
                {
                    Console.WriteLine(eval.student.Id + " : " + eval.GetNote());
                }
            }
		}
    }
}
