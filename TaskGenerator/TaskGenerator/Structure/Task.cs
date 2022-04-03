using System;
using System.Collections.Generic;

namespace TaskGenerator
{
	public class Task
	{
		public int type;
        public int subtype;
        public string condition;
		public List<string> questions;
		public List<string> answers;

        public void TestPrint()
        {
            //Oh no, cringe
            if(type == 1)
            {
                Console.WriteLine("\nTask " + type + ". \n" + condition + "\n" + "a) " + questions[0] + "\n" + "б) " + questions[1] + "\n" +
                              "Answers: \n" + "a) " + answers[0] + "\n" + "б) " + answers[1] + "\n");
            }
            else 
            {
                Console.WriteLine("Task " + type);
            }
        }
        public Task(int type = 0, int subtype = 0)
        {
            this.type = type;
            this.subtype = subtype;
            questions = new List<string>();
            answers = new List<string>();
        }
    }
}
