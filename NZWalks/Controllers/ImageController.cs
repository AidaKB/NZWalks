using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Models.Domain;
using NZWalks.Models.DTO;
using NZWalks.Repositories;

namespace NZWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImageController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDto imageUploadRequestDto)
        {
            ValidateFileUpload(imageUploadRequestDto);
            if (ModelState.IsValid)
            {
                var imageDomainModel = new Image
                {
                    File = imageUploadRequestDto.File,
                    FileExtension = Path.GetExtension(imageUploadRequestDto.File.FileName),
                    FileSizeInBytes = imageUploadRequestDto.File.Length,
                    FileName = imageUploadRequestDto.FileName,
                    FileDescription = imageUploadRequestDto.FileDescription
                };
                await imageRepository.UploadAsync(imageDomainModel);
                return Ok(new { message = "Image uploaded successfully", image = imageDomainModel });

            }
            return BadRequest(ModelState);


        }

        private void ValidateFileUpload(ImageUploadRequestDto imageUploadRequestDto)
        {
            var valid_extensions = new string[] { ".jpg", ".jpeg", ".png" };
            if (!valid_extensions.Contains(Path.GetExtension(imageUploadRequestDto.File.FileName)))
            {
                ModelState.AddModelError("File", "Invalid file type. Only .jpg, .jpeg, and .png files are allowed.");
            }
            if (imageUploadRequestDto.File.Length > 10485760)
            {
                ModelState.AddModelError("File", "File size exceeds the maximum limit of 10MB.");
            }


        }
    }
}
