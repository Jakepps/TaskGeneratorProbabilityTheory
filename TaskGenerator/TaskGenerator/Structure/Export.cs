using System.Collections.Generic;
using Xceed.Words.NET;
using Xceed.Document.NET;
//using System.Drawing;

namespace TaskGenerator
{
    public class Export
    {
        public static (DocX, DocX) ExportVariants(List<Variant> variantList, string pathVariants, string pathAnswers)
        {
            //string pathdoc = @"test.docx";
            //string pathdocot = @"testotvet.docx";
            //Title  
            var doc = DocX.Create(pathVariants);
            var docotvet = DocX.Create(pathAnswers);
            for (int i = 0; i < variantList.Count; i++)
            {
                string title = variantList[i].student;
                string titlevar = "Вариант " + (i + 1);
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
                Paragraph paragraphTitle = doc.InsertParagraph(title, false, titleFormat);
                Paragraph paragraphTitle2 = doc.InsertParagraph(titlevar, false, titleFormat);
                paragraphTitle.Alignment = Alignment.center;
                paragraphTitle2.Alignment = Alignment.right;
                for (int j = 0; j < variantList[i].tasks.Count; j++)
                {
                    //Text  
                    string textParagraph = (j + 1) + "." + variantList[i].tasks[j].conditionWithNumberedQuestions + '\r';
                    //string otvet = (i + 1) + variantList[i].tasks[j].numberedAnswers;
                    ////Formatting Title  
                    //Formatting titleFormat = new Formatting();
                    ////Specify font family  
                    //titleFormat.FontFamily = new Font("Times New Roman");
                    ////Specify font size  
                    //titleFormat.Size = 18D; 
                    //titleFormat.Position = 40;
                    //titleFormat.FontColor = System.Drawing.Color.Black;
                    ////titleFormat.UnderlineColor = System.Drawing.Color.Black; можно подчеркнуть по рофлу
                    //// titleFormat.Italic = true; я не итальянец
                    //Specify font family  
                    titleFormat.FontFamily = new Font("Times New Roman");
                    //Specify font size  
                    titleFormat.Size = 15D;
                    titleFormat.Position = 40;
                    titleFormat.FontColor = System.Drawing.Color.Black;
                    //titleFormat.UnderlineColor = System.Drawing.Color.Black;
                    //titleFormat.Italic = true;
                    //Formatting Text Paragraph  
                    Formatting textParagraphFormat = new Formatting();
                    //font family  
                    textParagraphFormat.FontFamily = new Font("Arial");
                    //font size  
                    textParagraphFormat.Size = 10D;
                    //Spaces between characters  
                    textParagraphFormat.Spacing = 1;
                    //Create docx  
                    //var doc = DocX.Create(pathdoc);
                    //Insert title  
                    //Paragraph paragraphTitle = doc.InsertParagraph(title, false, titleFormat);
                    //Paragraph paragraphTitle2 = doc.InsertParagraph(titlevar, false, titleFormat);
                    //paragraphTitle.Alignment = Alignment.center;
                    //paragraphTitle2.Alignment = Alignment.right;
                    //Insert text  
                    doc.InsertParagraph(textParagraph, false, textParagraphFormat);

                    //doc.InsertParagraph(otvet, false, textParagraphFormat);

                    //Process.Start("WINWORD.EXE", pathdoc);
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
