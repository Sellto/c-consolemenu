using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu
{
    public class Evaluation
    {
        private Activity activity;
		private Student student;
        private string title;
        private int note = -1;
        private string appreciation = "";
        private Dictionary<string, int> conversionAN = new Dictionary<string, int>();

        public Evaluation(Activity act)
        {
            this.activity = activity;
            this.student = student;
            this.title = title;
            this.note = note;
            this.appreciation = appreciation;
            conversionAN.Add("", 0);
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

        public Activity Activity
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


        //Functions
        public void SetNote(int new_note)
        {
            note = new_note;
        }

        public void SetAppreciation(string app)
        {
            appreciation = app;
        }
		
		public int GetNumNote()
        {
            int num_note = (this.note == -1) ? conversionAN[appreciation] : this.note;
            return num_note;
        }
    }
}
