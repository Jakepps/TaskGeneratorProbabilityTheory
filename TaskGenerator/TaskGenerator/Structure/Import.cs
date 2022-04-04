using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using System.IO;

namespace TaskGenerator
{
    public class Import
    {
        // ? надо сюда его писать хз короче List<string> studentName = new List<string>();
        public static List<string> namefile()
        {
            //открытие файл, я хз как его читать без полного пути, как мне показывал рустам не получается
            List<string> studentName = new List<string>();
            Application application = new();
            Document document = application.Documents.Open("C:\\test\\a.docx");
            char[] chars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ')', '(','*','-' };
            //string[] chars = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", ")", "\r" };
            int count = document.Words.Count;
            string[] arrString = new string[count + 1];
            for (int i = 1; i <= count; i++)
            {
                string text = document.Words[i].Text;
                arrString[i] = text;
            }

            string stud = null;
            for (int i = 0; i < arrString.Length; i++)
            {
                stud += arrString[i];
            }
            StringBuilder newstud = new StringBuilder();
            for (int i = 0; i < stud.Length; i++)
            {
                if (!(chars.Contains(stud[i])))
                    newstud.Append(stud[i]);
            }
            string nst = newstud.ToString();
            string[] studnam = nst.Split('\n');
            for (int i = 0; i < studnam.Length; i++)
            {
                studentName.Add(studnam[i]);
            }
            //StreamWriter sw = new StreamWriter("C:\\test\\test.txt");
            //for (int i = 0; i < studentName.Count; i++)
            //{
            //    Console.WriteLine(studentName[i]);
            //    sw.WriteLine(studentName[i]);
            //}
            //sw.Close();
            return studentName;
        }

        public static List<int> GetTaskTypesFromString(String str)
        {
            List<int> result = new List<int>();

            char[] chars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ',', '-', ' ' };
            
            for (int i = 0; i < str.Length; i++)
            {
                if (!chars.Contains(str[i]))
                    throw new FormatException("GetTaskTypesFromString " + str);
            }

            String clearedString = str.Replace(" ","");
            String[] splittedString = clearedString.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            for (int i = 0; i < splittedString.Length; i++)
            {
                if (splittedString[i].Contains('-'))
                {
                    String[] splittedString2 = splittedString[i].Split('-', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
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
            return result;
        }

        public Import()
        {
            //studentName = new List<string>();
        }
    }

}  