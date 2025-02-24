using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    public partial class CreateEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ENDERECO",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CEP = table.Column<string>(maxLength: 10, nullable: false),
                    DESCRICAO = table.Column<string>(maxLength: 255, nullable: false),
                    CIDADE = table.Column<string>(maxLength: 100, nullable: false),
                    ESTADO = table.Column<string>(maxLength: 50, nullable: false),
                    PAIS = table.Column<string>(maxLength: 50, nullable: false),
                    NUMERO = table.Column<string>(maxLength: 10, nullable: false),
                    COMPLEMENTO = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENDERECO", x => x.ID);
                });
        }
        
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "ENDERECO");
        }
    }
}
