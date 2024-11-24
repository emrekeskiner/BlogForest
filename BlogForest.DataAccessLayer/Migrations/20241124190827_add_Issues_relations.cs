using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogForest.DataAccessLayer.Migrations
{
    public partial class add_Issues_relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_AspNetUsers_AppUserId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_AppUserId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Issues");

            migrationBuilder.AlterColumn<int>(
                name: "ReportedByUserId",
                table: "Issues",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "AdminUserId",
                table: "Issues",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Issues_AdminUserId",
                table: "Issues",
                column: "AdminUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_ReportedByUserId",
                table: "Issues",
                column: "ReportedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_AspNetUsers_AdminUserId",
                table: "Issues",
                column: "AdminUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_AspNetUsers_ReportedByUserId",
                table: "Issues",
                column: "ReportedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_AspNetUsers_AdminUserId",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_AspNetUsers_ReportedByUserId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_AdminUserId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_ReportedByUserId",
                table: "Issues");

            migrationBuilder.AlterColumn<string>(
                name: "ReportedByUserId",
                table: "Issues",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AdminUserId",
                table: "Issues",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Issues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Issues_AppUserId",
                table: "Issues",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_AspNetUsers_AppUserId",
                table: "Issues",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
