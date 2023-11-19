using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Data
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

            //seed data for Difficulties
            //Easy, Medium, Hard

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("75972c93-1931-415c-93e2-28d8fd44d228"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("a9854fc6-3a4c-46c8-9f93-c3731979e3e0"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("7c2c8f5a-4949-4167-a7ac-d7e515f21338"),
                    Name = "Hard"
                },
            };

            //seed Difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            //seed deata for Regions
            var regions = new List<Region>()
            {
                new Region
                {
                    Id = Guid.Parse("cfa28603-fa6c-424d-a18e-46d089eff9f0"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://www.pexels.com/photo/the-auckland-harbour-bridge-in-new-zealand-5342976/"
                },
                new Region
                {
                    Id = Guid.Parse("06fa121f-c2a0-47f0-a3b0-3f8418cbc8ff"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImageUrl = "https://www.pexels.com/photo/brown-and-orange-house-with-outdoor-plants-2259917/"
                },
                new Region
                {
                    Id = Guid.Parse("53d814fb-a503-4bea-af1f-9f73e26188eb"),
                    Name = "Bay of Plenty",
                    Code = "BOP",
                    RegionImageUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("0637f86e-2f43-470c-86ff-678c49183661"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImageUrl = "Photo by Ketan Kumawat from Pexels: https://www.pexels.com/photo/body-of-water-photo-724952/"
                },
                new Region
                {
                    Id = Guid.Parse("da317d93-cf6d-4c28-9797-a29a9cc2e7c3"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageUrl = "Photo by Nathan Cowley from Pexels: https://www.pexels.com/photo/photo-of-tree-on-lake-2463951/"
                },
                new Region
                {
                    Id = Guid.Parse("96019430-fb47-46c2-9018-ce63f843636d"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageUrl = null
                },
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
