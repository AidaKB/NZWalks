namespace NZWalks.Models.DTO
{
    public class RegionDto
    {
        public Guid Id { get; set; }
        public string PresentationName { get; set; }

        public string Code { get; set; }

        public string? RegionImageUrl { get; set; }
    }
}
