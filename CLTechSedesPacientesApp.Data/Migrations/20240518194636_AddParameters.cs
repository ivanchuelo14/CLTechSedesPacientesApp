using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CLTechSedesPacientesApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddParameters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "Lab63Sedes",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Lab63Sedes");
        }
    }
}
