using NZWalks.Models.Domain;

namespace NZWalks.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> CreateAsync(Walk walk);
        Task<Walk?> GetByIdAsync(Guid id);


    }
}
