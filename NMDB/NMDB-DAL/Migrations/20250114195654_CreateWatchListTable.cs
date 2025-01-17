using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NMDB_DAL.Migrations
{
    /// <inheritdoc />
    public partial class CreateWatchListTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "genre",
                table: "Shows",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "genre",
                table: "Shows");
        }
    }
}
