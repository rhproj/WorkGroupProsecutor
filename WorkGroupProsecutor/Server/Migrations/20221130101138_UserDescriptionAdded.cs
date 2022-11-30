using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkGroupProsecutor.Server.Migrations
{
    /// <inheritdoc />
    public partial class UserDescriptionAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserDescription",
                table: "UserAccount",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserDescription",
                table: "UserAccount");
        }
    }
}
