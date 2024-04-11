using Domain.Abstractions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class ImageTableRepository : IImageTableRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ImageTableRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<ImageTable> GetImageById(int id)
        {
            return await _databaseContext.ImageTable.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<ImageTable>> GetAllImage()
        {
            return await _databaseContext.ImageTable.ToListAsync();
        }
    }
}