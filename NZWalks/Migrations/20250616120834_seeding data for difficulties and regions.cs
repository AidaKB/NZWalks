using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.Migrations
{
    /// <inheritdoc />
    public partial class seedingdatafordifficultiesandregions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("8b49f4b7-7b4b-4da5-97ca-a31e5d5f1ae3"), "Hard" },
                    { new Guid("d17a6c5d-e4c1-47e1-a44f-3f66fadacacf"), "Medium" },
                    { new Guid("dbb3f82a-75c1-4da1-8d49-6d4150ac282c"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("11ac579d-7f6f-4e90-a12e-c6a5f8bbebbb"), "CZ", "Central Zone", "https://example.com/images/central.jpg" },
                    { new Guid("62f72a79-f438-43b1-bb1b-d679e223d50b"), "WZ", "West Zone", "https://example.com/images/west.jpg" },
                    { new Guid("7ae3ac41-dc46-414c-b41a-a49f7e81446a"), "NZ", "North Zone", "https://example.com/images/north.jpg" },
                    { new Guid("a81f4b3a-2f49-4fc2-97b2-1c8b2aa921d5"), "SZ", "South Zone", "https://example.com/images/south.jpg" },
                    { new Guid("cf98235f-f190-4bfc-8714-cf5792df1707"), "EZ", "East Zone", "https://example.com/images/east.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("8b49f4b7-7b4b-4da5-97ca-a31e5d5f1ae3"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("d17a6c5d-e4c1-47e1-a44f-3f66fadacacf"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("dbb3f82a-75c1-4da1-8d49-6d4150ac282c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("11ac579d-7f6f-4e90-a12e-c6a5f8bbebbb"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("62f72a79-f438-43b1-bb1b-d679e223d50b"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("7ae3ac41-dc46-414c-b41a-a49f7e81446a"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a81f4b3a-2f49-4fc2-97b2-1c8b2aa921d5"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("cf98235f-f190-4bfc-8714-cf5792df1707"));
        }
    }
}
