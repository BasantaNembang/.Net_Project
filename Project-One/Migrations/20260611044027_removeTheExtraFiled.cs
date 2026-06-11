using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_One.Migrations
{
    /// <inheritdoc />
    public partial class removeTheExtraFiled : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "BookDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "BookDetails",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
