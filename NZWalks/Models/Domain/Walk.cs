namespace NZWalks.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }

        public string? WalkImageUrl { get; set; }

        // foreign keys for region and difficulty(from naming)
        public Guid RegionId { get; set; }
        public Guid DifficultyId { get; set; }

        // for reading data return the whole class not just id
        public Region Region { get; set; }
        public Difficulty Difficulty { get; set; }
    }
}