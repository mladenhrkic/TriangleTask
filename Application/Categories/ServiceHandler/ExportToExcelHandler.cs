using Application.Categories.Service;
using Domain.Abstractions;
using Domain.Models;
using MediatR;

namespace Application.Categories.ServiceHandler
{
    public class ExportToExcelHandler(IExportToExcelService exportToExcel) :
        IRequestHandler<ExportToExcel>
    {
        private readonly IExportToExcelService _exportToExcel = exportToExcel;

        public async Task Handle(ExportToExcel request, CancellationToken cancellationToken)
        {
            var model = new List<Triangle>();
            model = request.Triangles.ToList();
            await _exportToExcel.Run(model);
        }
    }
}