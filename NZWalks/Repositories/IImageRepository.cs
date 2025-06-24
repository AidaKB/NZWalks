using NZWalks.Models.Domain;

namespace NZWalks.Repositories
{
    public interface IImageRepository
    {
        Task<Image> UploadAsync(Image image);

    }
}
