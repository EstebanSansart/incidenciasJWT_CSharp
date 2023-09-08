using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class TestMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserArea_area_AreaId",
                table: "UserArea");

            migrationBuilder.DropForeignKey(
                name: "FK_UserArea_user_UserId",
                table: "UserArea");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserArea",
                table: "UserArea");

            migrationBuilder.RenameTable(
                name: "UserArea",
                newName: "UserAreas");

            migrationBuilder.RenameIndex(
                name: "IX_UserArea_UserId",
                table: "UserAreas",
                newName: "IX_UserAreas_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserArea_AreaId",
                table: "UserAreas",
                newName: "IX_UserAreas_AreaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAreas",
                table: "UserAreas",
                columns: new[] { "IdUserFk", "IdAreaFk" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserAreas_area_AreaId",
                table: "UserAreas",
                column: "AreaId",
                principalTable: "area",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAreas_user_UserId",
                table: "UserAreas",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAreas_area_AreaId",
                table: "UserAreas");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAreas_user_UserId",
                table: "UserAreas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAreas",
                table: "UserAreas");

            migrationBuilder.RenameTable(
                name: "UserAreas",
                newName: "UserArea");

            migrationBuilder.RenameIndex(
                name: "IX_UserAreas_UserId",
                table: "UserArea",
                newName: "IX_UserArea_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAreas_AreaId",
                table: "UserArea",
                newName: "IX_UserArea_AreaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserArea",
                table: "UserArea",
                columns: new[] { "IdUserFk", "IdAreaFk" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserArea_area_AreaId",
                table: "UserArea",
                column: "AreaId",
                principalTable: "area",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserArea_user_UserId",
                table: "UserArea",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id");
        }
    }
}
