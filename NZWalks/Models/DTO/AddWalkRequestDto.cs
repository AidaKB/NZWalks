using System.ComponentModel.DataAnnotations;

namespace NZWalks.Models.DTO
{
    public class AddWalkRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name length should be more than 3")]
        [MaxLength(20, ErrorMessage = "Name length should be less than 20")]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        [Range(0, 50)]
        public double LengthInKm { get; set; }

        public string? WalkImageUrl { get; set; }

        // foreign keys for region and difficulty(from naming)
        [Required]
        public Guid RegionId { get; set; }

        [Required]
        public Guid DifficultyId { get; set; }
    }
}
