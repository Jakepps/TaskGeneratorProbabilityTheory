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


        public void TestPrint()
        {
            foreach (Task task in tasks)
                task.TestPrint();
        }
        
        //Мб лучше перенести в конструктор, пока так.
        public void GenerateVariant(List<int> taskTypes)
        {
            for (int i = 0; i < taskTypes.Count; i++)
            {
                tasks.Add(TaskConstructor.CreateTask(taskTypes[i]));
            }
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

        public void TestPrint()
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
