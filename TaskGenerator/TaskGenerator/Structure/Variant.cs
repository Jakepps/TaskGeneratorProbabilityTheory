using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskGenerator
{
    public class Variant
    {
        public int number;
        //public string student;
        public List<Task> tasks;

        public void RegenerateTaskSubtype(int index)
        {
            if (index < 0 || index >= tasks.Count) throw new ArgumentOutOfRangeException("index");
            tasks[index] = TaskConstructor.CreateTask(tasks[index].type);
        }

        public void RegenerateTaskValues(int index)
        {
            if(index < 0 || index >= tasks.Count) throw new ArgumentOutOfRangeException("index");
            tasks[index] = TaskConstructor.CreateTask(tasks[index].type, tasks[index].subtype);
        }

        public static List<Variant>  GenerateSomeVariants(int count, List<int> taskTypes)
        {
            List<Variant> result = new List<Variant>();
            for (int i = 0; i < count; i++)
            {
                Variant var = new Variant(taskTypes)
                {
                    number = i + 1
                };
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


        public Variant(List<int> taskTypes)
        {
            tasks = new List<Task>();
            for (int i = 0; i < taskTypes.Count; i++)
            {
                tasks.Add(TaskConstructor.CreateTask(taskTypes[i]));
            }
            
        }
    }
}
