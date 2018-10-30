using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop;
using Microsoft.CSharp;
using CBSAutomation.Locators;

using ExcelDataReader;
using Microsoft.Office.Interop.Excel;

using System.IO;

using System.Runtime.InteropServices;


namespace CBSAutomation
{
  

        public class ExcelDataReadUpdate

        {

            public string TabName { get; set; }

            public string Scenario { get; set; }

            public string TestCase { get; set; }

            public Dictionary<string, string> Data { get; set; }
            public Dictionary<string, string> CellIndex { get; set; }
        }

        public class ExcelFile
        {
            public ExcelFile(List<ExcelDataReadUpdate> input)
            {
       
            excelFile = input;
            }


            public string GetTestInputValue(string tabName, string testScenario, string testCase, string columnName)
            {
                tabName = tabName.ToUpper();
                testScenario = testScenario.ToUpper();
                testCase = testCase.ToUpper();
                try
                {
                    var dic = excelFile.Where(e => e.Scenario.ToUpper() == testScenario && e.TabName.ToUpper() == tabName && e.TestCase.ToUpper() == testCase)
                        .Select(e => e.Data).FirstOrDefault();

                    return dic[columnName];
                }
                catch(Exception ex )
                {
                    return ex.Message;
                }
            


        }

            public void UpdateCellValue(string tabName, string testScenario, string testCase, string columnName, string valueToUpdate)
            {
                int columnIndex = 0;
                int rowIndex = 0;
                tabName = tabName.ToUpper();
                testScenario = testScenario.ToUpper();
                testCase = testCase.ToUpper();

                //Declaring all Interop object to use in finally block
                Microsoft.Office.Interop.Excel.Application excel = null;
                Microsoft.Office.Interop.Excel.Workbook workbook = null;
                Microsoft.Office.Interop.Excel.Worksheet worksheet = null;
                Microsoft.Office.Interop.Excel.Range row = null;
                try
                {
                    var dic = excelFile.Where(e => e.Scenario.ToUpper() == testScenario && e.TabName.ToUpper() == tabName && e.TestCase.ToUpper() == testCase)
                        .Select(e => e.CellIndex).FirstOrDefault();

                    if(dic != null)
                    {
                        rowIndex = int.Parse(dic[columnName].Split('-')[0]) + 1;
                        columnIndex = int.Parse(dic[columnName].Split('-')[1]) + 1;

                        excel = new Microsoft.Office.Interop.Excel.Application();
                        workbook = excel.Workbooks.Open(ExcelUtility.filePath, ReadOnly: false, Editable: true);
                        worksheet = workbook.Worksheets.Item[tabName] as Worksheet;
                        if (worksheet == null)
                            return;
                        //Get Cell to update
                        row = worksheet.Cells[rowIndex, columnIndex];
                        row.Value = string.Format("'{0}", valueToUpdate.ToString());

                        excel.Application.ActiveWorkbook.Save();
                        excel.Application.Quit();
                        excel.Quit();
                    }
                   
                }
                catch
                {

                }

                finally
                {
                    if (row != null) Marshal.ReleaseComObject(row);
                    if (worksheet != null) Marshal.ReleaseComObject(worksheet);
                    if (workbook != null) Marshal.ReleaseComObject(workbook);
                    if (excel != null) Marshal.ReleaseComObject(excel);
                }
            }

            public List<ExcelDataReadUpdate> excelFile = new List<ExcelDataReadUpdate>();
        }


        public class ExcelUtility
        {
            public static string filePath;

            static ExcelUtility()
            {


            // filePath = PropertyReader.GetProperty(Property.FILEPATH, GeneralProperties.Default);

            string cexcelDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            cexcelDirectory = cexcelDirectory.Remove(cexcelDirectory.IndexOf("\\bin\\Debug"));
            // filePath = (cexcelDirectory + "\\ExcelIO\\CBSInputTestData.xls");
            filePath = (cexcelDirectory + "\\ExcelIO\\CBSInputTestDataPostgress.xls");
            
        }

            public static ExcelFile LoadExcel()
            {
                List<ExcelDataReadUpdate> list = new List<ExcelDataReadUpdate>();
                using (var stream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite))
                {

                
                    // Auto-detect format, supports:
                    //  - Binary Excel files (2.0-2003 format; *.xls)
                    //  - OpenXml Excel files (2007 format; *.xlsx)
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {

                        // Choose one of either 1 or 2:

                        // 1. Use the reader methods
                        do
                        {
                            var columnNames = new List<string>();
                            int rowCount = 0;
                            while (reader.Read())
                            {
                                var scenario = reader.GetString(0);
                                var testCase = reader.GetString(1);

                                if (scenario == null || testCase == null)
                                    break;

                            if (rowCount == 0)
                                {
                                    int i = 0;
                                    while (i < reader.FieldCount)
                                    {
                                        var cellText = reader.GetString(i);
                                        if (cellText == null)
                                            break;
                                        columnNames.Add(reader.GetString(i));
                                        i++;
                                    }
                                }
                                else
                                {
                                    Dictionary<string, string> rowData = new Dictionary<string, string>();
                                    Dictionary<string, string> indexData = new Dictionary<string, string>();
                                    int i = 2;
                                    while (i < columnNames.Count)
                                    {
                                        rowData.Add(columnNames[i], reader.GetString(i));
                                        indexData.Add(columnNames[i], rowCount + "-" + i);
                                        i++;

                                    }
                                    var ds = new ExcelDataReadUpdate
                                    {
                                        Scenario = scenario,
                                        TestCase = testCase,
                                        TabName = reader.Name,
                                        Data = rowData,
                                        CellIndex = indexData
                                    };
                                    list.Add(ds);
                                }
                                rowCount++;
                            }
                        } while (reader.NextResult());

                    }
                }
                return new ExcelFile(list);
            }
        }
    }



