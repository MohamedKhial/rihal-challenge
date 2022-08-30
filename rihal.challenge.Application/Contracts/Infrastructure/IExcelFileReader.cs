using System.Collections.Generic;
using System.Data;

namespace rihal.challenge.Application.Contracts.Infrastructure
{
    public interface IExcelFileReader<T> where T : class
    {
        List<T> ToList(string excelFilePath);
        IEnumerable<T> Records(string excelFilePath);
        DataSet ToDataSet(string excelFilePath);
    }
}
