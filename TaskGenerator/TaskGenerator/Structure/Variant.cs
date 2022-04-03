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
        public string student;
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
        public static List<Variant> GetVariantsForStudents(List<String> students, List<int> taskTypes)
        {
            List<Variant> result = new List<Variant>();
            for (int i = 0; i < students.Count; i++)
            {
                Variant var = new Variant(taskTypes)
                {
                    number = i + 1,
                    student = students[i]
                };
                result.Add(var);
            } 
            return result;
        }
        public void TestPrint()
        {
            Console.WriteLine(number + "-В " + student);
            foreach (Task task in tasks)
                task.TestPrint();
            Console.WriteLine();
        }

        //Перенести в класс импорта данных, когда он будет готов.
        public static List<int> GetTaskTypesFromString(String str)
        {
            List<int> result = new List<int>();

            char[] chars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ',', '-' };
            StringBuilder sbString = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                if (chars.Contains(str[i]))
                    sbString.Append(str[i]);
            }

            String clearedString = sbString.ToString();
            String[] splittedString = clearedString.Split(new char[] { ',' });

            for (int i = 0; i < splittedString.Length; i++)
            {
                if (splittedString[i].Contains('-'))
                {
                    String[] splittedString2 = splittedString[i].Split('-');
                    int from = Convert.ToInt32(splittedString2[0]), to = Convert.ToInt32(splittedString2[1]);
                    for (int j = from; j <= to; j++)
                    {
                        result.Add(j);
                    }
                }
                else
                {
                    int type = Convert.ToInt32(splittedString[i]);
                    result.Add(type);
                }
            }
            return result;
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
