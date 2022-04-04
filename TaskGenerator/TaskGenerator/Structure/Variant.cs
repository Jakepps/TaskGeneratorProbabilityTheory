using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TaskGenerator
{
    public class Variant
    {
        public int number {get;}
        //public string student;
        public List<Task> tasks { get; private set; }

        public static List<Variant>  GenerateSomeVariants(int count, List<int> taskTypes)
        {
            List<Variant> result = new List<Variant>();
            for (int i = 0; i < count; i++)
            {
                Variant var = new Variant(i + 1, taskTypes);
                result.Add(var);
            }
            return result;
        }
        //public static List<Variant> GetVariantsForStudents(List<String> students, List<int> taskTypes)
        //{
        //    List<Variant> result = new List<Variant>();
        //    for (int i = 0; i < students.Count; i++)
        //    {
        //        Variant var = new Variant(taskTypes)
        //        {
        //            number = i + 1,
        //            student = students[i]
        //        };
        //        result.Add(var);
        //    } 
        //    return result;
        //}

        public void TestPrint()
        {
            Console.WriteLine(number + "-В ");
            foreach (Task task in tasks)
                task.TestPrint();
            Console.WriteLine();
        }

        public Variant(int number, List<int> taskTypes)
        {
            this.number = number + 5;
            tasks = new List<Task>();
            for (int i = 0; i < taskTypes.Count; i++)
            {
                tasks.Add(TaskConstructor.CreateTask(taskTypes[i]));
            }
            
        }
    }
}
