using Application.Categories.Service;
using Domain.Abstractions;
using Domain.Models;
using MediatR;

namespace Application.Categories.ServiceHandler
{
    public class ExportToExcelHandler(IExportToExcelService exportToExcel) :
        IRequestHandler<ExportToExcel>
    {
        public async Task Handle(ExportToExcel request, CancellationToken cancellationToken)
        {
            var model = request.Triangles.ToList();
            await exportToExcel.Run(model);
        }
    }
}