using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
namespace ResultManager
{
    public static class Facade
    {
        private static List<XDocument> resultsList;
        static string root = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
        static Facade()
        {
            resultsList = new List<XDocument>();
        }

        public static void addXDocument(string path)
        {
            XDocument newFile = XDocument.Load(path);
            if (newFile.Root.Name == "TspResultInstance")
                resultsList.Add(newFile);
        }
        public static bool createExcel(string fileName)
        {
            fileName = root + @"\" + fileName;
            Application xlApp = new Application();
            

           if (xlApp == null)
           {
             return false ;
           }
            object misValue = System.Reflection.Missing.Value;
            Workbook xlWorkBook = xlApp.Workbooks.Add(misValue);
            Excel.Worksheet xlWorkSheet;
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);



            string newFileName = fileName;
            int i = 0;
            while(File.Exists(newFileName + ".xls"))
            {
                newFileName = fileName;
                newFileName += i + ".xls";
              
            }

            fillUpExcel(xlWorkSheet);

            xlWorkBook.SaveAs(newFileName + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, newFileName+".xls", misValue);
            xlApp.Quit();

           
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);
            return true;

           
        }

        private static void fillUpExcel(Worksheet xlWorkSheet)
        {
            int row = 1;
           
            foreach(var result in resultsList)
            {
                string name = getName(result);
                xlWorkSheet.Cells[row, 1] = name;
                row++;
                xlWorkSheet.Cells[row, 1] = "Generations";
                xlWorkSheet.Cells[row, 2] = "Fittnes";
                row++;
                var nodes = result.Root.Element("OtherSolutionsWhereBestAtTime");
                var list = nodes.Descendants().Where(x => x.Name == "Result");
                foreach(var node in list)
                {
                    xlWorkSheet.Cells[row, 1] = node.Element("Generation").Value;
                    xlWorkSheet.Cells[row, 2] = node.Element("Fittnes").Value;
                    row++;
                }
                
                

            }
        }
        private static string getName(XDocument result)
        {
            string fileName = "";
            fileName=result.Root.Element("InstanceName").Value;

            return fileName;
        }
    }
}
