using System.ComponentModel.DataAnnotations;

namespace NZWalks.Models.DTO
{
    public class UpdateRegionReguestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name length should be more than 3")]
        [MaxLength(20, ErrorMessage = "Name length should be less than 20")]
        public string Name { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "Code length should be less than 10")]
        public string Code { get; set; }

        public string? RegionImageUrl { get; set; }
    }
}
