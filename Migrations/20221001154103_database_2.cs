using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinderGarten.Migrations
{
    public partial class database_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Books_ClassID",
                table: "Books",
                column: "ClassID");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Classes_ClassID",
                table: "Books",
                column: "ClassID",
                principalTable: "Classes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Classes_ClassID",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_ClassID",
                table: "Books");
        }
    }
}
