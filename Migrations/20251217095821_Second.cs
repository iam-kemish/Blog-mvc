using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DatasInformation.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "All about tech and gadgets", "Technology" },
                    { 2, "Health tips and news", "Health" },
                    { 3, "Travel guides and experiences", "Travel" },
                    { 4, "Recipes and food reviews", "Food" },
                    { 5, "Sports news and events", "Sports" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Author", "CategoryId", "Content", "FeatureImagePath", "PublishedDate", "Title" },
                values: new object[,]
                {
                    { 1, "Theon", 1, "Stay updated with the latest technology trends for 2025.", null, new DateTime(2025, 12, 17, 15, 43, 18, 297, DateTimeKind.Local).AddTicks(9872), "Latest Tech Trends 2025" },
                    { 2, "Ramsay", 2, "Learn how to eat healthy and maintain your lifestyle.", null, new DateTime(2025, 12, 17, 15, 43, 18, 298, DateTimeKind.Local).AddTicks(634), "Healthy Eating Tips" },
                    { 3, "lockhead", 3, "Check out the most amazing travel destinations this year.", null, new DateTime(2025, 12, 17, 15, 43, 18, 298, DateTimeKind.Local).AddTicks(637), "Top Travel Destinations" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedDate", "PostId", "UserName" },
                values: new object[,]
                {
                    { 1, "Great article! Learned a lot about tech.", new DateTime(2025, 12, 17, 15, 43, 18, 298, DateTimeKind.Local).AddTicks(3145), 1, "Alice" },
                    { 2, "Very helpful health tips, thanks!", new DateTime(2025, 12, 17, 15, 43, 18, 298, DateTimeKind.Local).AddTicks(3787), 2, "Bob" },
                    { 3, "I want to visit these places ASAP!", new DateTime(2025, 12, 17, 15, 43, 18, 298, DateTimeKind.Local).AddTicks(3790), 3, "Charlie" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
