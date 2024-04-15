using Domain.Abstractions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class TriangleRepository : ITriangleRepository
    {
        private readonly DatabaseContext _dbContext;

        public TriangleRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Triangle> CreateTriangle(Triangle triangle)
        {
            var categories = await GetAllTriangle();
            var maxId = 0;
            if (categories.Count > 0)
            {
                maxId = categories.Max(x => x.TriangleId);
            }
            triangle.TriangleId = maxId + 1;
            _dbContext.Triangles.Add(triangle);
            await _dbContext.SaveChangesAsync();
            return triangle;
        }

        public async Task DeleteTriangle(int id)
        {
            var category = await _dbContext.Triangles.FirstOrDefaultAsync(c => c.TriangleId == id);
            if (category == null) return;

            _dbContext?.Triangles.Remove(category);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<Triangle>> GetAllTriangle()
        {
            return await _dbContext.Triangles.ToListAsync();
        }

        public async Task<Triangle> GetTriangleById(int id)
        {
            return await _dbContext.Triangles.FirstOrDefaultAsync(c => c.TriangleId == id);
        }

        public async Task<Triangle> UpdateTriangle(Triangle updateTriangle)
        {
            var triangle = await _dbContext.Triangles.FirstOrDefaultAsync(c => c.TriangleId == updateTriangle.TriangleId);

            triangle.SideA = updateTriangle.SideA;
            triangle.SideB = updateTriangle.SideB;
            triangle.SideC = updateTriangle.SideC;
            triangle.GammaAngle = updateTriangle.GammaAngle;
            triangle.AlphaAngle = updateTriangle.AlphaAngle;
            triangle.BetaAngle = updateTriangle.BetaAngle;
            triangle.Perimeter = updateTriangle.Perimeter;
            triangle.Area = updateTriangle.Area;
            triangle.TriangleBySide = updateTriangle.TriangleBySide;
            triangle.TriangleByAngle = updateTriangle.TriangleByAngle;
            triangle.Image = updateTriangle.Image;
            triangle.Image_2 = updateTriangle.Image_2;

            await _dbContext.SaveChangesAsync();
            return triangle;
        }

        public async Task<ICollection<Triangle>> GetTriangleByUserId(string userId)
        {
            return await _dbContext.Triangles.Where(c => c.UserId == userId).ToListAsync();
        }
    }
}