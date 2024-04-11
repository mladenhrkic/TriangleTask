using Domain.Models;

namespace Domain.Abstractions
{
    public interface IImageTableRepository
    {
        Task<ImageTable> GetImageById(int id);
        Task<ICollection<ImageTable>> GetAllImage();
    }
}