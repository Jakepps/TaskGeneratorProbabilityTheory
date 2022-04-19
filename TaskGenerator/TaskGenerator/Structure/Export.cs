using System.Collections.Generic;
using Xceed.Words.NET;
using Xceed.Document.NET;
//using System.Drawing;

namespace TaskGenerator
{
    public class Export
    {
        public static (DocX, DocX) ExportStudents(List<Variant> variantList)
        {
            string pathdoc = @"C:\Users\Артем\source\repos\git\TaskGeneratorProbabilityTheory\TaskGenerator\test.docx";
            string pathdocot = @"C:\Users\Артем\source\repos\git\TaskGeneratorProbabilityTheory\TaskGenerator\testotvet.docx";
            //Title  
            var doc = DocX.Create(pathdoc);
            var docotvet = DocX.Create(pathdocot);
            for (int i = 0; i < variantList.Count; i++)
            {
                string title = variantList[i].student;
                string titlevar = "Вариант " + (i + 1);
                Formatting titleFormat = new Formatting();
                titleFormat.FontFamily = new Font("Times New Roman");
                titleFormat.Size = 18D;
                titleFormat.Position = 40;
                titleFormat.FontColor = System.Drawing.Color.Black;
                Paragraph paragraphTitle = doc.InsertParagraph(title, false, titleFormat);
                Paragraph paragraphTitle2 = doc.InsertParagraph(titlevar, false, titleFormat);
                paragraphTitle.Alignment = Alignment.center;
                paragraphTitle2.Alignment = Alignment.right;
                for (int j = 0; j < variantList[i].tasks.Count; j++)
                {
                    string textParagraph = (j + 1) + "." + variantList[i].tasks[j].conditionWithNumberedQuestions + '\r';
                    titleFormat.FontFamily = new Font("Times New Roman");
                    titleFormat.Size = 15D;
                    titleFormat.Position = 40;
                    titleFormat.FontColor = System.Drawing.Color.Black;
                    Formatting textParagraphFormat = new Formatting();
                    textParagraphFormat.FontFamily = new Font("Arial");
                    textParagraphFormat.Spacing = 0;
                    doc.InsertParagraph(textParagraph, false, textParagraphFormat);
                }
            }
            for (int i = 0; i < variantList.Count; i++)
            {
                string varotvet = "Вариант " + (i + 1);
                docotvet.InsertParagraph(varotvet);
                for (int j = 0; j < variantList[i].tasks.Count; j++)
                {
                    string otvet = "Номер " + (j + 1) + '\r' + variantList[i].tasks[j].numberedAnswers;
                    docotvet.InsertParagraph(otvet);
                }
            }
            doc.Save();
            docotvet.Save();
            return (doc, docotvet);
        }
    }
}
