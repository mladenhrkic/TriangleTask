using Domain.Models;

namespace Domain.Abstractions
{
    public interface IExportToExcelService
    {
        Task Run(List<Triangle> triangle);
    }
}
