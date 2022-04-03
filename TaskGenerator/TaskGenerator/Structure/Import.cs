using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;

namespace TaskGenerator
{

    public class Import
    {
        public List<string> studentName;
        public void Op()
        {   //открытие файл, я хз как его читать без полного пути, как мне показывал рустам не получается
            Application application = new();
            Document document = application.Documents.Open("C:\\Users\\artem\\source\\repos\\Jakepps\\TaskGeneratorProbabilityTheory\\TaskGenerator\\a.docx");

            string[] chars = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", ")", "\r" };
            int count = document.Words.Count;
            for (int i = 1; i <= count; i++)
            { 
                string text = document.Words[i].Text;
                if (chars.Contains(text)) continue;
                studentName.Add(text);   
            }
            application.Quit();
        }

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

        public Import()
        {
            studentName = new List<string>();
        }
    }

}  