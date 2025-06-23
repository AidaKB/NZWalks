using Microsoft.EntityFrameworkCore;
using NZWalks.Models.Domain;

namespace NZWalks.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<Image> Images { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var difficulties = new List<Difficulty>()
            {
                new Difficulty
                {
                    Id = Guid.Parse("dbb3f82a-75c1-4da1-8d49-6d4150ac282c"),
                    Name = "Easy"
                },
                new Difficulty
                {
                    Id = Guid.Parse("d17a6c5d-e4c1-47e1-a44f-3f66fadacacf"),
                    Name = "Medium"
                },
                new Difficulty
                {
                    Id = Guid.Parse("8b49f4b7-7b4b-4da5-97ca-a31e5d5f1ae3"),
                    Name = "Hard"
                }
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.Parse("7ae3ac41-dc46-414c-b41a-a49f7e81446a"),
                    Name = "North Zone",
                    Code = "NZ",
                    RegionImageUrl = "https://example.com/images/north.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("a81f4b3a-2f49-4fc2-97b2-1c8b2aa921d5"),
                    Name = "South Zone",
                    Code = "SZ",
                    RegionImageUrl = "https://example.com/images/south.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("cf98235f-f190-4bfc-8714-cf5792df1707"),
                    Name = "East Zone",
                    Code = "EZ",
                    RegionImageUrl = "https://example.com/images/east.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("62f72a79-f438-43b1-bb1b-d679e223d50b"),
                    Name = "West Zone",
                    Code = "WZ",
                    RegionImageUrl = "https://example.com/images/west.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("11ac579d-7f6f-4e90-a12e-c6a5f8bbebbb"),
                    Name = "Central Zone",
                    Code = "CZ",
                    RegionImageUrl = "https://example.com/images/central.jpg"
                }
            };
            modelBuilder.Entity<Region>().HasData(regions);


        }

    }
}
