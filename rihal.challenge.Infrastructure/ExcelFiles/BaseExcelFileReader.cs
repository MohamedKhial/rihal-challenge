using ExcelDataReader;
using System.Data;
using System.IO;

namespace rihal.challenge.Infrastructure.ExcelFiles
{
    public class BaseExcelFileReader
    {
        public DataSet ToDataSet(string excelFilePath)
        {
            using (FileStream stream = File.Open(excelFilePath, FileMode.Open, FileAccess.Read))
            {
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                {
                    DataSet ds = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });
                    return ds;
                }
            }
        }
    }
}
