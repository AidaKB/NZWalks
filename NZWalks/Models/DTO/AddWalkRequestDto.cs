namespace NZWalks.Models.DTO
{
    public class AddWalkRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }

        public string? WalkImageUrl { get; set; }

        // foreign keys for region and difficulty(from naming)
        public Guid RegionId { get; set; }
        public Guid DifficultyId { get; set; }
    }
}
