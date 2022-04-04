using System;
using System.Collections.Generic;

namespace TaskGenerator
{

    public class Task
    {
        public int type { get; set; }
        public int subtype { get; set; }
        public string condition { get; set; }
        public List<string> questions { get; set; }
        public List<string> answers { get; set; }

        public string conditionWithQuestions {
            get {
                return GetConditionAndQuestions();
		    }
            set {

			}
        }

        public string GetConditionAndQuestions()
        {
            string result = condition;
            for (int i = 0; i < questions.Count; i++)
                result +="\n" + (i+1) + ") " + questions[i];
            return result;
        }
        public void TestPrint()
        {
            //no cringe
            Console.WriteLine("\nTask " + type + ". \n" + condition);
            Console.WriteLine("questions:");
            for (int i = 0; i < questions.Count; i++)
                Console.WriteLine((i+1) + ") " + questions[i]);
            Console.WriteLine("answers:");
            for (int i = 0; i < answers.Count; i++)
                Console.WriteLine((i+1) + ") " + answers[i]);
        }
        public Task(int type = 0, int subtype = 0)
        {
            this.type = type;
            this.subtype = subtype;
            condition = "Есть два стула.";
            questions = new List<string>();
            answers = new List<string>();
        }
    }
}
