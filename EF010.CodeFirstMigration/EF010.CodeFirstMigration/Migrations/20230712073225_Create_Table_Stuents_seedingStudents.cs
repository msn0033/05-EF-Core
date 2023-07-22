using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EF010.CodeFirstMigration.Migrations
{
    /// <inheritdoc />
    public partial class Create_Table_Stuents_seedingStudents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fatima Ali" },
                    { 2, "Noor Saleh" },
                    { 3, "Omar Youssef" },
                    { 4, "Huda Ahmed" },
                    { 5, "Amira Tariq" },
                    { 6, "Zainab Ismail" },
                    { 7, "Yousef Farid " },
                    { 8, "Layla Mustafa" },
                    { 9, "Mohammed Adel" },
                    { 10, "Samira Nabil" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
