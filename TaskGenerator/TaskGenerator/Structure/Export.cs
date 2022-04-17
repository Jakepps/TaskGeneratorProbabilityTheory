using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using System.IO;
using System.Diagnostics;
using Xceed;
using Xceed.Words.NET;
using Xceed.Document.NET;
using System.Drawing;

namespace TaskGenerator.Structure
{
    public class Export
    {
        public void ExportStudents()
        {
            string pathdoc = (@"C:\Users\artem\source\repos\Jakepps\TaskGeneratorProbabilityTheory\TaskGenerator\test.docx");
            string headlineText = "Constitution of the United States";
            string paraOne = ""
            + "We the People of the United States, in Order to form a more perfect Union, "
            + "establish Justice, insure domestic Tranquility, provide for the common defence, "
            + "promote the general Welfare, and secure the Blessings of Liberty to ourselves "
            + "and our Posterity, do ordain and establish this Constitution for the United "
            + "States of America.";

            // A formatting object for our headline:
            var headLineFormat = new Formatting();
            //headLineFormat.FontFamily = new FontFamily("Arial Black");
                //Xceed.Document.NET.Drawing.FontFamily("Arial Black");
            headLineFormat.Size = 18D;
            headLineFormat.Position = 12;

            // A formatting object for our normal paragraph text:
            var paraFormat = new Formatting();
            //paraFormat.FontFamily = new FontFamily("Calibri");
            paraFormat.Size = 10D;

            // Create the document in memory:
            var doc = DocX.Create(pathdoc);

            // Insert the now text obejcts;
            doc.InsertParagraph(headlineText, false, headLineFormat);
            doc.InsertParagraph(paraOne, false, paraFormat);

            // Save to the output directory:
            doc.Save();


        }
    }
}
