using System.Collections.Generic;
using Xceed.Words.NET;
using Xceed.Document.NET;
//using System.Drawing;

namespace TaskGenerator
{
    public class Export
    {
        public static void ExportVariants(List<Variant> variantList, string path)
        {
            //string pathdoc = @"test.docx";
            //string pathdocot = @"testotvet.docx";

            //string pathdoc = @"C:\Users\artem\source\repos\Jakepps\TaskGeneratorProbabilityTheory\TaskGenerator\test.docx";
            //string pathdocot = @"C:\Users\artem\source\repos\Jakepps\TaskGeneratorProbabilityTheory\TaskGenerator\testotvet.docx";

            //Title  
            var doc = DocX.Create(path + "\\Variants.docx");
            var docotvet = DocX.Create(path + "\\VariantsAnswers.docx");
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
                    string textParagraph = (j + 1) + ". " + variantList[i].tasks[j].conditionWithNumberedQuestions + '\r';
                    titleFormat.FontFamily = new Font("Times New Roman");
                    titleFormat.Size = 15D;
                    titleFormat.Position = 40;
                    titleFormat.FontColor = System.Drawing.Color.Black;
                    Formatting textParagraphFormat = new Formatting();
                    textParagraphFormat.FontFamily = new Font("Arial");
                    textParagraphFormat.Spacing = 1;
<<<<<<< HEAD
                    //Create docx  
                    //var doc = DocX.Create(pathdoc);
                    //Insert title  
                    //Paragraph paragraphTitle = doc.InsertParagraph(title, false, titleFormat);
                    //Paragraph paragraphTitle2 = doc.InsertParagraph(titlevar, false, titleFormat);
                    //paragraphTitle.Alignment = Alignment.center;
                    //paragraphTitle2.Alignment = Alignment.right;
                    //Insert text  
                    if (j + 1 == 15)
                    {
                        var t = doc.AddTable(5, 2);
                        t.Alignment = Alignment.left;
                        t.Rows[0].Cells[0].Paragraphs[0].Append("x:");
                        t.Rows[1].Cells[0].Paragraphs[0].Append("p:");

                    }
                    
=======
>>>>>>> a9559404bc47346bb17655344c62668e7f2888ef
                    doc.InsertParagraph(textParagraph, false, textParagraphFormat);
                }
                if (i != variantList.Count-1)
                    doc.InsertParagraph("").InsertPageBreakAfterSelf();
            }
            for (int i = 0; i < variantList.Count; i++)
            {
                string varotvet = "Вариант " + (i + 1);
                Formatting titleFormat = new Formatting();
                titleFormat.FontFamily = new Font("Times New Roman");
                titleFormat.Size = 18D;
                titleFormat.Position = 40;
                titleFormat.FontColor = System.Drawing.Color.Black;
                docotvet.InsertParagraph(varotvet,false,titleFormat);
                for (int j = 0; j < variantList[i].tasks.Count; j++)
                {
                    string otvet = "Номер " + (j + 1) + '\r' + variantList[i].tasks[j].numberedAnswers;
                    
                    docotvet.InsertParagraph(otvet);
                }
            }
            doc.Save();
            docotvet.Save();
            
        }
    }
}
