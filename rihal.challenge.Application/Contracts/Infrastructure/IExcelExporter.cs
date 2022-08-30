using System.Data;
using System.Threading.Tasks;

namespace rihal.challenge.Application.Contracts.Infrastructure
{
    public interface IExcelExporter
    {
        Task<byte[]> ExportToExcel(DataTable dataTable);
    }
}
