using System;
using System.Collections.Generic;

namespace TaskGenerator
{

    public class Task
    {
        public int type { get; private set; }
        public int subtype { get; private set; }
        public string condition { get; set; }
        public List<string> questions { get; set; }
        public List<string> answers { get; set; }

        public string conditionWithNumberedQuestions
        {
            get {
                string result = condition;
                for (int i = 0; i < questions.Count; i++)
                    result += "\n" + (i + 1) + ") " + questions[i];
                return result;
            }
        }

        public string numberedAnswers
        {
            get
            {
                string result = "";
                if(answers.Count == 1)
                {
                    result += answers[0];
                    return result;
                }
                for (int i = 0; i < answers.Count; i++)
                {
                    result += (i + 1) + ") " + answers[i] + (i != answers.Count - 1 ? "\n" : "");
                } 
                return result;
            }
        }

        private void TaskReplace(Task task)
        {
            this.type = task.type;
            this.subtype = task.subtype;
            this.condition = task.condition;
            this.questions = task.questions;
            this.answers = task.answers;
        }

        public void RegenerateTaskSubtype()
        {
            int newSubtype = this.subtype == 1 ? 2 : 1;
            TaskReplace(TaskConstructor.CreateTask(this.type, newSubtype));
        }

        public void RegenerateTaskValues()
        {
            TaskReplace(TaskConstructor.CreateTask(this.type, this.subtype));
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
