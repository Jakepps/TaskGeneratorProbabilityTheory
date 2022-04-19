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
                    titleFormat.FontFamily = new Font("Times New Roman");
                    titleFormat.Size = 15D;
                    titleFormat.Position = 40;
                    titleFormat.FontColor = System.Drawing.Color.Black;
                    Formatting textParagraphFormat = new Formatting();
                    textParagraphFormat.FontFamily = new Font("Arial");
                    textParagraphFormat.Spacing = 1;
                    if (j==14) 
                    {   
                        var columnWidths1 = new float[] { 40f, 40f, 40f ,40f};
                        var t = doc.AddTable(2, columnWidths1.Length);
                        t.SetWidths(columnWidths1);
                        t.Alignment = Alignment.left;
                        t.Rows[0].Cells[0].Paragraphs[0].Append("x:");
                        t.Rows[0].Cells[1].Paragraphs[0].Append(variantList[i].tasks[j].tables[0][0, 0]);
                        t.Rows[0].Cells[2].Paragraphs[0].Append(variantList[i].tasks[j].tables[0][1, 0]);
                        t.Rows[0].Cells[3].Paragraphs[0].Append(variantList[i].tasks[j].tables[0][2, 0]);
                        t.Rows[1].Cells[0].Paragraphs[0].Append("p:");
                        t.Rows[1].Cells[1].Paragraphs[0].Append(variantList[i].tasks[j].tables[0][0, 1]);
                        t.Rows[1].Cells[2].Paragraphs[0].Append(variantList[i].tasks[j].tables[0][1, 1]);
                        t.Rows[1].Cells[3].Paragraphs[0].Append(variantList[i].tasks[j].tables[0][2, 1]);

                        var columnWidths2 = new float[] { 40f, 40f, 40f };
                        var t2 = doc.AddTable(2, columnWidths2.Length);
                        t2.SetWidths(columnWidths2);
                        t2.Alignment = Alignment.left;
                        t2.Rows[0].Cells[0].Paragraphs[0].Append("y:");
                        t2.Rows[0].Cells[1].Paragraphs[0].Append(variantList[i].tasks[j].tables[1][0, 0]);
                        t2.Rows[0].Cells[2].Paragraphs[0].Append(variantList[i].tasks[j].tables[1][1, 0]);
                        t2.Rows[1].Cells[0].Paragraphs[0].Append("p:");
                        t2.Rows[1].Cells[1].Paragraphs[0].Append(variantList[i].tasks[j].tables[1][0, 1]);
                        t2.Rows[1].Cells[2].Paragraphs[0].Append(variantList[i].tasks[j].tables[1][1, 1]);
                        string textParagraph = (j + 1) + ". " + "Независимые случайные величины X и Y заданы таблицами распределений.";
                        string nay = "Найти:";
                        var d = doc.InsertParagraph(textParagraph, false, textParagraphFormat);
                        d.SpacingAfter(15d);
                        d.InsertTableAfterSelf(t2);
                        string space = '\r'+ "";
                        d.InsertParagraphAfterSelf(space);
                        d.InsertTableAfterSelf(t);
                        doc.InsertParagraph(nay,false,textParagraphFormat);
                        for (int q = 0; q < 3; q++)
                        {
                            string textQ = (q + 1) + ") " + variantList[i].tasks[j].questions[q];
                            doc.InsertParagraph(textQ, false, textParagraphFormat);
                        }
                    }
                    else
                    {
                        string textParagraph = (j + 1) + ". " + variantList[i].tasks[j].conditionWithNumberedQuestions + '\r';
                        doc.InsertParagraph(textParagraph, false, textParagraphFormat);
                    }
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
                    string otvet = "Номер " + (j + 1) + ":" + '\r' + variantList[i].tasks[j].numberedAnswers;
                    
                    docotvet.InsertParagraph(otvet);
                }
            }
            doc.Save();
            docotvet.Save();
            
        }
    }
}
