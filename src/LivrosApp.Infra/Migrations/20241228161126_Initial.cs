using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LivrosApp.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assuntos",
                columns: table => new
                {
                    CodAs = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assuntos", x => x.CodAs);
                });

            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    CodAu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.CodAu);
                });

            migrationBuilder.CreateTable(
                name: "CanalVendas",
                columns: table => new
                {
                    CodCv = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CanalVendas", x => x.CodCv);
                });

            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    CodL = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Editora = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Edicao = table.Column<int>(type: "int", nullable: false),
                    AnoPublicacao = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.CodL);
                });

            migrationBuilder.CreateTable(
                name: "LivrosAssuntos",
                columns: table => new
                {
                    CodLa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Livro_CodL = table.Column<int>(type: "int", nullable: false),
                    Assunto_CodAs = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivrosAssuntos", x => x.CodLa);
                    table.ForeignKey(
                        name: "FK_LivrosAssuntos_Assuntos_Assunto_CodAs",
                        column: x => x.Assunto_CodAs,
                        principalTable: "Assuntos",
                        principalColumn: "CodAs",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivrosAssuntos_Livros_Livro_CodL",
                        column: x => x.Livro_CodL,
                        principalTable: "Livros",
                        principalColumn: "CodL",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LivrosAutores",
                columns: table => new
                {
                    CodLa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Livro_CodL = table.Column<int>(type: "int", nullable: false),
                    Autor_CodAu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivrosAutores", x => x.CodLa);
                    table.ForeignKey(
                        name: "FK_LivrosAutores_Autores_Autor_CodAu",
                        column: x => x.Autor_CodAu,
                        principalTable: "Autores",
                        principalColumn: "CodAu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivrosAutores_Livros_Livro_CodL",
                        column: x => x.Livro_CodL,
                        principalTable: "Livros",
                        principalColumn: "CodL",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TabelaPrecos",
                columns: table => new
                {
                    CodTp = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodL = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CodCv = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaPrecos", x => x.CodTp);
                    table.ForeignKey(
                        name: "FK_TabelaPrecos_CanalVendas_CodCv",
                        column: x => x.CodCv,
                        principalTable: "CanalVendas",
                        principalColumn: "CodCv",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TabelaPrecos_Livros_CodL",
                        column: x => x.CodL,
                        principalTable: "Livros",
                        principalColumn: "CodL",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LivrosAssuntos_Assunto_CodAs",
                table: "LivrosAssuntos",
                column: "Assunto_CodAs");

            migrationBuilder.CreateIndex(
                name: "IX_LivrosAssuntos_Livro_CodL",
                table: "LivrosAssuntos",
                column: "Livro_CodL");

            migrationBuilder.CreateIndex(
                name: "IX_LivrosAutores_Autor_CodAu",
                table: "LivrosAutores",
                column: "Autor_CodAu");

            migrationBuilder.CreateIndex(
                name: "IX_LivrosAutores_Livro_CodL",
                table: "LivrosAutores",
                column: "Livro_CodL");

            migrationBuilder.CreateIndex(
                name: "IX_TabelaPrecos_CodCv",
                table: "TabelaPrecos",
                column: "CodCv");

            migrationBuilder.CreateIndex(
                name: "IX_TabelaPrecos_CodL",
                table: "TabelaPrecos",
                column: "CodL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LivrosAssuntos");

            migrationBuilder.DropTable(
                name: "LivrosAutores");

            migrationBuilder.DropTable(
                name: "TabelaPrecos");

            migrationBuilder.DropTable(
                name: "Assuntos");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "CanalVendas");

            migrationBuilder.DropTable(
                name: "Livros");
        }
    }
}
