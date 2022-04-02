using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskGenerator
{
    public class Task
    {
        public string number;
        public string condition;
        public List<string> questions;
        public List<string> answers;

        public void testPrintTask()
        {
            Console.WriteLine("Task " + number + ". \n" + condition + "\n" + "a) " + questions[0] + "\n" + "б) " + questions[1] + "\n" +
                              "Answers: \n" + "a) " + answers[0] + "\n" + "б) " + answers[1] + "\n");
        }
        public Task()
        {
            questions = new List<string>();
            answers = new List<string>();
        }
    }
}
