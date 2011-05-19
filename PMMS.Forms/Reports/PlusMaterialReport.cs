using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMMS.Services.System;
using Microsoft.Office.Interop.Excel;

namespace PMMS.Forms.Reports
{
    class PlusMaterialReport
    {

        public void GetReport(IList<PlusMaterialListView> listPlus, string templateFile, string fileName)
        {
            var missing = Type.Missing;
            ApplicationClass excel = null;

            excel = new ApplicationClass();

            //打开指定Excel文件的工作簿
            var workbook = excel.Workbooks.Open(templateFile, missing, missing, missing, missing, missing,
                                                      missing, missing, missing, missing, missing, missing, missing,
                                                      missing, missing);
            try
            {
                var worksheet = (Worksheet)workbook.Sheets.get_Item(1);
                int p = 3;
                foreach (var plus in listPlus)
                {
                    worksheet.get_Range("A" + p, "A" + p).Value2 = plus.No;
                    worksheet.get_Range("B" + p, "B" + p).Value2 = plus.Name;
                    worksheet.get_Range("C" + p, "C" + p).Value2 = plus.StockCount;
                    worksheet.get_Range("D" + p, "D" + p).Value2 = plus.Price;
                    worksheet.get_Range("E" + p, "E" + p).Value2 = plus.Color;
                    worksheet.get_Range("F" + p, "F" + p).Value2 = plus.FabricWidth;
                    worksheet.get_Range("G" + p, "G" + p).Value2 = plus.Supplier;
                    worksheet.get_Range("H" + p, "H" + p).Value2 = plus.Remark;
                    p++;
                }
            }
            finally
            {
                workbook.SaveAs(fileName, missing, missing, missing, missing, missing, XlSaveAsAccessMode.xlNoChange, missing, missing, missing, missing, missing);
                excel.Visible = true;
            }
        }
    }
}
