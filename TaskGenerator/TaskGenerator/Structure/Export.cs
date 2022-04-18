using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using Xceed;
using Xceed.Words.NET;
using Xceed.Document.NET;
//using System.Drawing;

namespace TaskGenerator
{
    public class Export
    {
        public static DocX ExportStudents(string st, int var, string varlist, string ot)
        {
            string pathdoc = (@"C:\Users\artem\source\repos\Jakepps\TaskGeneratorProbabilityTheory\TaskGenerator\test.docx");
            //Title  
            string title = st;
            string titlevar = "Вариант " + var;
            //Text  
            string textParagraph = varlist;
            string otvet = ot;
            //Formatting Title  
            Formatting titleFormat = new Formatting();
            //Specify font family  
            titleFormat.FontFamily = new Font("Times New Roman");
            //Specify font size  
            titleFormat.Size = 18D;
            titleFormat.Position = 40;
            titleFormat.FontColor = System.Drawing.Color.Black;
           //titleFormat.UnderlineColor = System.Drawing.Color.Black; можно подчеркнуть по рофлу
           // titleFormat.Italic = true; я не итальянец
            //Specify font family  
            titleFormat.FontFamily = new Font("Times New Roman");
            //Specify font size  
            titleFormat.Size = 18D;
            titleFormat.Position = 40;
            titleFormat.FontColor = System.Drawing.Color.Black;
            //titleFormat.UnderlineColor = System.Drawing.Color.Black;
            //titleFormat.Italic = true;
            //Formatting Text Paragraph  
            Formatting textParagraphFormat = new Formatting();
            //font family  
            textParagraphFormat.FontFamily = new Font("Arial");
            //font size  
            textParagraphFormat.Size = 12D;
            //Spaces between characters  
            textParagraphFormat.Spacing = 1;
            //Create docx  
            var doc = DocX.Create(pathdoc);
            //Insert title  
            Paragraph paragraphTitle = doc.InsertParagraph(title, false, titleFormat);
            Paragraph paragraphTitle2 = doc.InsertParagraph(titlevar, false, titleFormat);
            paragraphTitle.Alignment = Alignment.center;
            paragraphTitle2.Alignment = Alignment.right;
            //Insert text  
            doc.InsertParagraph(textParagraph, false, textParagraphFormat);
            doc.InsertParagraph(otvet, false, textParagraphFormat);
            doc.Save();
            //Process.Start("WINWORD.EXE", pathdoc);

            return doc; 
        }
    }
}
