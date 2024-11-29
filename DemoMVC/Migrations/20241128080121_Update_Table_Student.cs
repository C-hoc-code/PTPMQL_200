using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoMVC.Migrations
{
    /// <inheritdoc />
    public partial class Update_Table_Student : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Student");

            migrationBuilder.AddColumn<int>(
                name: "MaLop",
                table: "Student",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LopHoc",
                columns: table => new
                {
                    MaLop = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TenLop = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHoc", x => x.MaLop);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_MaLop",
                table: "Student",
                column: "MaLop");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_LopHoc_MaLop",
                table: "Student",
                column: "MaLop",
                principalTable: "LopHoc",
                principalColumn: "MaLop",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_LopHoc_MaLop",
                table: "Student");

            migrationBuilder.DropTable(
                name: "LopHoc");

            migrationBuilder.DropIndex(
                name: "IX_Student_MaLop",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "MaLop",
                table: "Student");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Student",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
