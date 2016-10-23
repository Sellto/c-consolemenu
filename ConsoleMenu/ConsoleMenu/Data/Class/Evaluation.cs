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
        private int note = -1;
        private string appreciation = "";
        private Dictionary<string, int> conversionAN = new Dictionary<string, int>();

        public Evaluation(Activity act)
        {
            activity = act;
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


        //Functions
        public void SetNote(int new_note)
        {
            note = new_note;
        }

        public void SetAppreciation(string app)
        {
            appreciation = app;
        }
    }
}
