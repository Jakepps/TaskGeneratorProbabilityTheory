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
        public List<string> studentName = new List<string>();
        public static void Op()
        {   //открытие файл, я хз как его читать без полного пути, как мне показывал рустам не получается
            Application application = new();
            Document document = application.Documents.Open("C:\\Users\\artem\\source\\repos\\Jakepps\\TaskGeneratorProbabilityTheory\\TaskGenerator\\a.docx");

            int count = document.Words.Count;
            for (int i = 1; i <= count; i++)
            { 
                string text = document.Words[i].Text;
                if (text == "1" || text == "2" || text == "3" || text == "4" || text == "5" || text == "6" || text == "7" || text == "8" || text == "9" || text == "0" || text == ")" || text == "\r") continue;
               // else studentName.Add(text);   
            }
            application.Quit();
        }
    }

}  