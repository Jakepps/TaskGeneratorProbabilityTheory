using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskGenerator
{
    public class Task
    {
        public string number; //?
        public string condition;
        public List<string> questions;
        public List<string> answers;

        public virtual void Decision()
        {
            //Тут по идее генерация рандомных значений для условие, метод решения задачи и заполнение полей. 
        }
        public Task()
        {
            questions = new List<string>();
            answers = new List<string>();
        }
    }

    public class Task1 : Task
    {
        public override void Decision()
        {
            number = "1";
            condition = "Наугад выбирается автомобиль с четырехзначным номером. Найти вероятность того, что: ";
            questions.Add("Это автомобиль Ф. Киркорова");
            questions.Add("Номер не содержит одинаковых цифр.");
            answers.Add("1/10000"); //?
            answers.Add("5040/10000"); //?
            Console.WriteLine("Task " + number + ". \n" + condition + "\n" + "a) " + questions[0] + "\n" + "б) " + questions[1] + "\n" +
                              "Answers: \n" + "a) " + answers[0] + "\n" + "б) " + answers[1] + "\n");
        }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            Console.WriteLine("TaskGeneratorProbabilityTheory");
            Task1 task1 = new Task1();
            task1.Decision();
            InitializeComponent();
        }
    }
}
