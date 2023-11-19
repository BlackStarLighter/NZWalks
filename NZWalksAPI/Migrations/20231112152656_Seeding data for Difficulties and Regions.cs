using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedingdataforDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("75972c93-1931-415c-93e2-28d8fd44d228"), "Easy" },
                    { new Guid("7c2c8f5a-4949-4167-a7ac-d7e515f21338"), "Hard" },
                    { new Guid("a9854fc6-3a4c-46c8-9f93-c3731979e3e0"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("0637f86e-2f43-470c-86ff-678c49183661"), "WGN", "Wellington", "Photo by Ketan Kumawat from Pexels: https://www.pexels.com/photo/body-of-water-photo-724952/" },
                    { new Guid("06fa121f-c2a0-47f0-a3b0-3f8418cbc8ff"), "NTL", "Northland", "https://www.pexels.com/photo/brown-and-orange-house-with-outdoor-plants-2259917/" },
                    { new Guid("53d814fb-a503-4bea-af1f-9f73e26188eb"), "BOP", "Bay of Plenty", null },
                    { new Guid("96019430-fb47-46c2-9018-ce63f843636d"), "STL", "Southland", null },
                    { new Guid("cfa28603-fa6c-424d-a18e-46d089eff9f0"), "AKL", "Auckland", "https://www.pexels.com/photo/the-auckland-harbour-bridge-in-new-zealand-5342976/" },
                    { new Guid("da317d93-cf6d-4c28-9797-a29a9cc2e7c3"), "NSN", "Nelson", "Photo by Nathan Cowley from Pexels: https://www.pexels.com/photo/photo-of-tree-on-lake-2463951/" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("75972c93-1931-415c-93e2-28d8fd44d228"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("7c2c8f5a-4949-4167-a7ac-d7e515f21338"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("a9854fc6-3a4c-46c8-9f93-c3731979e3e0"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0637f86e-2f43-470c-86ff-678c49183661"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("06fa121f-c2a0-47f0-a3b0-3f8418cbc8ff"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("53d814fb-a503-4bea-af1f-9f73e26188eb"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("96019430-fb47-46c2-9018-ce63f843636d"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("cfa28603-fa6c-424d-a18e-46d089eff9f0"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("da317d93-cf6d-4c28-9797-a29a9cc2e7c3"));
        }
    }
}
