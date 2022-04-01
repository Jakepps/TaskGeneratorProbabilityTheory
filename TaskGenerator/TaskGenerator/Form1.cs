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

        }
        public Task()
        {
            questions = new List<string>();
            answers = new List<string>();
        }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            Console.WriteLine("TaskGeneratorProbabilityTheory");
            InitializeComponent();
        }
    }
}
