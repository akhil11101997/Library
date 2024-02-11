using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryControllerAPIs.Migrations
{
    /// <inheritdoc />
    public partial class Updatedbook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookCopy");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Books");

            migrationBuilder.CreateTable(
                name: "BookCopy",
                columns: table => new
                {
                    CopyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BookISBN = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCopy", x => x.CopyId);
                    table.ForeignKey(
                        name: "FK_BookCopy_Books_BookISBN",
                        column: x => x.BookISBN,
                        principalTable: "Books",
                        principalColumn: "ISBN");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookCopy_BookISBN",
                table: "BookCopy",
                column: "BookISBN");
        }
    }
}
