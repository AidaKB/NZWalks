﻿using NZWalks.Models.Domain;

namespace NZWalks.Models.DTO
{
    public class WalkDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }

        public string? WalkImageUrl { get; set; }

        // foreign keys for region and difficulty(from naming)

        public RegionDto Region { get; set; }
        public Difficulty Difficulty { get; set; }

    }
}
