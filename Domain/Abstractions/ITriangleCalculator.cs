using Domain.Models;
namespace Domain.Abstractions
{
    public interface ITriangleCalculator
    {
        public Task<Triangle> Result(Triangle sideValues);
    }
}
