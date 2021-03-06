﻿using System;
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


        private void SearchEvaluations()
        {   
            foreach(Evaluation eval in Generator.List_of_evaluations)
            {
                if(eval.Student.Id == student_id)
                {
                    evaluations.Add(eval);
                }
            }
        }


        private List<string> SearchActivities()
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
                Console.WriteLine("\n\t-- " + act_title+ " --\tMoyenne: : " + AverageByActivity(PointsByActivity(act_title)) + "/20\n");
                foreach(Evaluation eval in evaluations)
                {
                    if(eval.Activity.Name == act_title)
                    {
                        Console.WriteLine("\t\t" + eval.Title + ":\t" + eval.GetNote());
                    }
                }
            }
			evaluations = new List<Evaluation>();
          
        }

        //Comme Average est appelée uniquement dans Displaybulletin -> la liste des evalutions est déja composée
        private double AverageByActivity(List<int> points)
        {
            int total = 0;
            foreach (int point in points)
            {
                total += point;
            }
			try
			{
				return (total / points.Count);
			}
			catch
			{
				return 0;
			}
        }


        private List<int> PointsByActivity(string act_title)
        {
            List<int> points = new List<int>();

            foreach(Evaluation eval in evaluations)
            {   
               if(eval.Activity.Name == act_title)
                {
                    points.Add(eval.GetNumNote());
                }
            }
            return points; 
        }        
    }
}
