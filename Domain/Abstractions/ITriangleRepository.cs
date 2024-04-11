using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions
{
    public interface ITriangleRepository
    {
        Task<ICollection<Triangle>> GetAllTriangle();
        Task<Triangle> GetTriangleById(int id);
        Task<Triangle> CreateTriangle(Triangle triangle);
        Task<Triangle> UpdateTriangle(Triangle triangle);
        Task DeleteTriangle(int id);
        Task<ICollection<Triangle>> GetTriangleByUserId(string userId);
    }
}
