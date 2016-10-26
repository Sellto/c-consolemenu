using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu
{
    public class Bulletin
    {
        private string student_id, student_year;
        private List<Evaluation> evaluations;
        private List<Activity> activities;

        public Bulletin(string id, string year)
        {
            student_id = id;
            student_year = year;
            evaluations = new List<Evaluation>();
        }

        public List<Evaluation> Evaluations
        {
            get { return evaluations; }
        }


        public void SearchEvaluations()
        {   
            foreach(Evaluation eval in Generator.List_of_evaluations)
            {
                if(eval.Student.Id == student_id)
                {
                    evaluations.Add(eval);
                }
            }
        }


        public List<string> SearchActivities()
        {
            List<string> act_name = new List<string>();
            foreach(Activity act in Generator.List_of_activities)
            {
                if(act.Code.Split('_')[0] == student_year)
                {
                    act_name.Add(act.Name);
                }
            }
            return act_name;
        }


        public void DisplayBulletin()
        {   
            //ON NE CREE LA LISTE DES  EVALUATIONS QUE SI LE BULLETIN DOIT ETRE AFFICHE
            SearchEvaluations();
            Console.Write("Bulletin:\n");
            foreach(string act_title in SearchActivities())
            {
                Console.WriteLine("\n\t-- " + act_title+ " --\t");
                foreach(Evaluation eval in evaluations)
                {
                    if(eval.Activity.Name == act_title)
                    {
                        Console.WriteLine("\t\t" + eval.Title + ":\t" + eval.GetNumNote());
                    }
                }
            }
            Console.WriteLine("\nMoyenne:\t" + Average() + "/20");
        }


        //Comme Average est appelée uniquement dans Displaybulletin -> la liste des evalutions est déja composée
        private double Average()
        {
            int total = 0;
            int total_ects = 0;
            foreach(Evaluation eval in evaluations)
            {   
                total += (eval.GetNumNote()*eval.Activity.Ects);
                Console.WriteLine(eval.Title + "\t" + eval.Activity.Ects + "\t" + total);
                total_ects += eval.Activity.Ects;
            }
            return (total / total_ects); 
        }        
    }
}
