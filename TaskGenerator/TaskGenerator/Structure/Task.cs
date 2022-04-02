using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskGenerator
{
    public class Variant
    {
        public string number;
        public string studentName;
        public List<Task> tasks;

        public void testPrint()
        {
           foreach (Task task in tasks)
                task.testPrint();
        }

        public Variant()
        {
            tasks = new List<Task>();
        }
    }

    public class Task
    {
        public string number;
        public string condition;
        public List<string> questions;
        public List<string> answers;

        public void testPrint()
        {
            Console.WriteLine("\nTask " + number + ". \n" + condition + "\n" + "a) " + questions[0] + "\n" + "б) " + questions[1] + "\n" +
                              "Answers: \n" + "a) " + answers[0] + "\n" + "б) " + answers[1] + "\n");
        }
        public Task()
        {
            questions = new List<string>();
            answers = new List<string>();
        }
    }
}
