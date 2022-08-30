using ClosedXML.Excel;
using rihal.challenge.Application.Contracts.Infrastructure;
using System.Data;
using System.IO;
using System.Threading.Tasks;

namespace rihal.challenge.Infrastructure.ExcelFiles
{
    public class ExcelExporter : IExcelExporter
    {
        public async Task<byte[]> ExportToExcel(DataTable dataTable)
        {
            return await Task.Run(() =>
             {
                 XLWorkbook wb = new XLWorkbook();
                 wb.Worksheets.Add(dataTable, "WorksheetName");
                 using (MemoryStream ms = new MemoryStream())
                 {
                     wb.SaveAs(ms);
                     byte[] excelFileBytes = ms.ToArray();
                     return excelFileBytes;
                 }
             });

        }
    }
}
