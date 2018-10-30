using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using DiffPlex;
using DiffPlex.DiffBuilder;
using DiffPlex.DiffBuilder.Model;
using DiffPlex.Model;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using NUnit.Framework;

namespace CBSAutomation.Base_Classes
{
    class PDFComparator
    {


        static string FirstFile, SecondFile;
        public static void CompareTwoPDF(string File_NameInput, string File_Nameextract)
        {
            string cexcelDirectorycapture = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            cexcelDirectorycapture = cexcelDirectorycapture.Remove(cexcelDirectorycapture.IndexOf("\\bin\\Debug"));

            String Path1 = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //  String sFile1 = cexcelDirectorycapture + "\\InputTestData\\ScreenShotValidation\\Engineering\\Base\\" + File_NameInput + ".pdf";
            //  String sFile2 = cexcelDirectorycapture + "\\InputTestData\\ScreenShotValidation\\Engineering\\Actual\\" + File_Nameextract + ".pdf";

            String sFile1 = "C:\\tmp\\" + File_NameInput + ".pdf";
            String sFile2 = "C:\\tmp\\" + File_Nameextract + ".pdf";




            if (File.Exists(sFile1) && File.Exists(sFile1))
            {



                PdfReader reader = new PdfReader(sFile1);
                for (int page = 1; page <= reader.NumberOfPages; page++)
                {
                    ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                    FirstFile += PdfTextExtractor.GetTextFromPage(reader, page, strategy);



                }

            }



            IEnumerable<string> file1 = FirstFile.Trim().Split('\r', '\n');

            ;

            File.WriteAllLines("C:\\tmp\\pdfresultInput.txt", file1);

            List<string> File1diff;

            File1diff = file1.ToList();

            Console.WriteLine(File1diff);



            //file 2
            if (File.Exists(sFile2) && File.Exists(sFile2))
            {



                PdfReader reader = new PdfReader(sFile2);
                for (int page = 1; page <= reader.NumberOfPages; page++)
                {
                    ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                    SecondFile += PdfTextExtractor.GetTextFromPage(reader, page, strategy);



                }
                //  reader.Close();
            }



            IEnumerable<string> file2 = SecondFile.Trim().Split('\r', '\n');

            File.WriteAllLines("C:\\tmp\\pdfresultExtracted.txt", file2);

            List<string> File2diff;

            File2diff = file2.ToList();

            Console.WriteLine(File2diff);








            if (file2.Count() > file1.Count())
            {
                Console.WriteLine("File 1 has less number of lines than File 2.");
                for (int i = 0; i < File1diff.Count; i++)
                {
                    if (!File1diff[i].Equals(File2diff[i]))
                    {
                        Console.WriteLine("File 1 content: " + File1diff[i] + "\r\n" + "File 2 content: " + File2diff[i]);

                    }

                }
                for (int i = File1diff.Count; i < File2diff.Count; i++)
                {
                    Console.WriteLine("File 2 extra content:" + File2diff[i]);

                    File.AppendAllText("C:\\tmp\\pdFile2diff.txt", File2diff[i]);

                }


            }
            else if (file2.Count() < file1.Count())
            {
                Console.WriteLine("File 2 has less number of lines than File 1.");

                for (int i = 0; i < File2diff.Count; i++)
                {
                    if (!File1diff[i].Equals(File2diff[i]))
                    {
                        Console.WriteLine("File 1 content: ” +File1diff[i] + “\r\n” + “File 2 content: ” +File2diff[i]");
                    }
                }

                for (int i = File2diff.Count; i < File1diff.Count; i++)
                {
                    Console.WriteLine("File 1 extra content: ” +File1diff[i]");
                    File.AppendAllText("C:\\tmp\\pdFile1diff.txt", File2diff[i]);
                }
            }
            else
            {
                Console.WriteLine("File 1 and File 2, both are having same number of lines.");

                for (int i = 0; i < File1diff.Count; i++)
                {
                    if (!File1diff[i].Equals(File2diff[i]))
                    {
                        Console.WriteLine("File 1 content: ” +File1diff[i]" + "\r\n" + "File 2 Content: " + File2diff[i]);

                    }



                }
                diff_Comparision();
            }
        }


        public static void diff_Comparision()

        {
            string textInput1 = System.IO.File.ReadAllText("C:\\tmp\\pdfresultInput.txt");

            string textExtracted2 = System.IO.File.ReadAllText("C:\\tmp\\pdfresultExtracted.txt");



            Differ differ = new Differ();
            var builder = new InlineDiffBuilder(differ);

            //   var diffResult = differ.CreateWordDiffs(text1, text2, true, seperators.ToArray());
            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb = new StringBuilder();
            var result = builder.BuildDiffModel(textInput1, textExtracted2);
            List<string> inserted = new List<string>();
            List<string> deleted = new List<string>();
            List<string> modified = new List<string>();
            List<string> imaginary = new List<string>();
            string pattern = "(1[012]|[1-9]):[0-5][0-9]:[0-5][0-9](\\s)?(?i)";

            string pattern1 = "((0?[1-9]|1[012])/(0?[1-9]|[012][0-9]|3[01]/[20][0-9]{2}?\\d\\d).*)";

            string pattern2 = "(am|pm|AM|PM)]?";
            string pattern3 = "EstimateLink:\\s*[0-9]{7}.*";

            var patterns = new string[] { @pattern, @pattern1, @pattern2, @pattern3 };
            Regex rgx = new Regex(string.Join("|", patterns), RegexOptions.IgnoreCase);

            foreach (var line in result.Lines)
            {
                if (line.Type == ChangeType.Inserted)
                {

                    string linetesxt1 = null;
                    if (rgx.IsMatch(line.Text))
                    {
                        linetesxt1 = rgx.Replace(line.Text, " ");
                    }
                    sb1.AppendLine(linetesxt1);
                    // sb1.Append("+");
                }
                else if (line.Type == ChangeType.Deleted)
                {


                    string linetesxt2 = null;

                    if (rgx.IsMatch(line.Text))
                    {
                        linetesxt2 = rgx.Replace(line.Text, " ");
                    }

                    sb.AppendLine(linetesxt2);

                    //  sb.Append("-");


                }


            }

            string path = "C:\\tmp\\InputtextEqualfiles.txt";
            string path1 = "C:\\tmp\\ExtractedtextEqualfiles1.txt";
            StreamWriter sw = new StreamWriter(new FileStream(path, FileMode.Create, FileAccess.Write));
            sw.Write(sb);
            sw.Close();
            StreamWriter sw1 = new StreamWriter(new FileStream(path1, FileMode.Create, FileAccess.Write));

            sw1.Write(sb1);
            sw1.Close();
            string textnew1 = System.IO.File.ReadAllText(path);

            string textnew2 = System.IO.File.ReadAllText(path1);
            Differ differnew = new Differ();
            var buildernew = new InlineDiffBuilder(differnew);

            var resultnew = builder.BuildDiffModel(textnew1, textnew2);


            foreach (var line in resultnew.Lines)
            {
                if (line.Type == ChangeType.Inserted)
                {
                    Assert.Fail("Report generated is inappropirate");
                }

                else if (line.Type == ChangeType.Deleted)
                {
                    Assert.Fail("Report generated is inappropirate");
                }
                else if (line.Type == ChangeType.Unchanged)
                {
                    Assert.Pass("Report generated is Correct");
                }





            }
        }
    }
}





