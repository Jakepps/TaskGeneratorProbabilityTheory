using System;
using System.Collections.Generic;

namespace TaskGenerator
{
	public class Task
	{
		public string number;
		public string condition;
		public List<string> questions;
		public List<string> answers;

        public void TestPrint()
        {
            //Oh no, cringe
            if(number == "1")
            {
                Console.WriteLine("\nTask " + number + ". \n" + condition + "\n" + "a) " + questions[0] + "\n" + "б) " + questions[1] + "\n" +
                              "Answers: \n" + "a) " + answers[0] + "\n" + "б) " + answers[1] + "\n");
            }
            else 
            {
                Console.WriteLine("Task " + number);
            }
        }
        public Task(int number = 0)
        {
            this.number = number.ToString();
            questions = new List<string>();
            answers = new List<string>();
        }
    }
}
