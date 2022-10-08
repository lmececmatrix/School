using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinderGarten.Migrations
{
    public partial class database_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassID",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_ClassID",
                table: "Blogs",
                column: "ClassID");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Classes_ClassID",
                table: "Blogs",
                column: "ClassID",
                principalTable: "Classes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Classes_ClassID",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_ClassID",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "ClassID",
                table: "Blogs");
        }
    }
}
