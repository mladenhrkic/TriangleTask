using Domain.Abstractions;
using Domain.Models;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ExcelServices
{
    public class CreateExcelFile : IExportToExcelService
    {
        public async Task Run(List<Triangle> triangle)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Trokut.xlsx";
            var file = new FileInfo(path);

            await SaveExcelFile(triangle, file);
        }

        private static async Task SaveExcelFile(IEnumerable<Triangle> triangle, FileInfo file)
        {
            DeleteExists(file);

            using var package = new ExcelPackage(file);

            var ws = package.Workbook.Worksheets.Add("MainReport");

            var range = ws.Cells["A2"].LoadFromCollection(triangle, true);
            range.AutoFitColumns();

            ws.Row(2).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Row(2).Style.Font.Bold = true;
            ws.Column(3).Width = 20;

            

            await package.SaveAsync();
        }

        private static void DeleteExists(FileSystemInfo file)
        {
            if (file.Exists)
            {
                file.Delete();
            }
        }
    }
}