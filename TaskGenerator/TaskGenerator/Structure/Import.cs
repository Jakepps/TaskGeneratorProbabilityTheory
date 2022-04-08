using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using System.IO;

namespace TaskGenerator
{
  
    public static class Import
    {
        
        public static List<string> ImportStudents(string path)
        {
            List<string> students = new List<string>();

            Application application = new Application();
            Document document = application.Documents.Open(path, null, true);
            
            StringBuilder fullString = new StringBuilder();
            for (int i = 1; i <= document.Words.Count; i++)
            {
                fullString.Append(document.Words[i].Text);
            }
            document.Close();

            StringBuilder clearedString = new StringBuilder();
            char[] chars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ')', '(', '*', '-', '{', '}', '[', ']', '?', '=', '+', '-', '_', ',', '.' };
            for (int i = 0; i < fullString.Length; i++)
            {
                if (!chars.Contains(fullString[i]))
                    clearedString.Append(fullString[i]);
            }

            students = clearedString.ToString().Split(new char[] { '\r', '\n' }, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).ToList();

            //for(int i = 0; i < students.Count; i++)
            //    Console.WriteLine(students[i]);
            
            document.Close();
           
            return students;
        }

        public static List<int> GetTaskTypesFromString(string str)
        {
            List<int> result = new List<int>();

            char[] chars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ',', '-', ' ' };
            
            for (int i = 0; i < str.Length; i++)
            {
                if (!chars.Contains(str[i]))
                    throw new FormatException("GetTaskTypesFromString " + str);
            }

            string clearedString = str.Replace(" ","");
            string[] splittedString = clearedString.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            for (int i = 0; i < splittedString.Length; i++)
            {
                if (splittedString[i].Contains('-'))
                {
                    string[] splittedString2 = splittedString[i].Split('-', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                    if (splittedString2.Length == 2)
                    {
                        int from = Convert.ToInt32(splittedString2[0]), to = Convert.ToInt32(splittedString2[1]);
                        for (int j = from; j <= to; j++)
                        {
                            result.Add(j);
                        }
                    }
                }
                else
                {
                    int type = Convert.ToInt32(splittedString[i]);
                    result.Add(type);
                }
            }

            result = result.Distinct().ToList();
            result.Sort();
            return result;
        }
    }
}  