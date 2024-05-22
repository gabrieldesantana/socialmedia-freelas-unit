using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMediaFreelas.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false),
                    Senha = table.Column<string>(type: "TEXT", nullable: false),
                    Actived = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_Vagas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    Cargo = table.Column<string>(type: "TEXT", nullable: false),
                    Tipo = table.Column<string>(type: "TEXT", nullable: false),
                    Remuneracao = table.Column<decimal>(type: "TEXT", nullable: false),
                    FreelancerId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClienteId1 = table.Column<int>(type: "INTEGER", nullable: true),
                    Actived = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Vagas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Vagas_TB_Clientes_ClienteId1",
                        column: x => x.ClienteId1,
                        principalTable: "TB_Clientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TB_Experiencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FreelancerId = table.Column<int>(type: "INTEGER", nullable: false),
                    Projeto = table.Column<string>(type: "TEXT", nullable: false),
                    Empresa = table.Column<string>(type: "TEXT", nullable: false),
                    Tecnologia = table.Column<string>(type: "TEXT", nullable: false),
                    Valor = table.Column<decimal>(type: "TEXT", nullable: false),
                    Avaliacao = table.Column<int>(type: "INTEGER", nullable: false),
                    FreelancerId1 = table.Column<int>(type: "INTEGER", nullable: true),
                    Actived = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Experiencias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_Freelancers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false),
                    Senha = table.Column<string>(type: "TEXT", nullable: false),
                    PretensaoSalarial = table.Column<decimal>(type: "TEXT", nullable: false),
                    Actived = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Freelancers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Freelancers_TB_Experiencias_Id",
                        column: x => x.Id,
                        principalTable: "TB_Experiencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_Freelancers_TB_Vagas_Id",
                        column: x => x.Id,
                        principalTable: "TB_Vagas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_Experiencias_FreelancerId1",
                table: "TB_Experiencias",
                column: "FreelancerId1");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Vagas_ClienteId1",
                table: "TB_Vagas",
                column: "ClienteId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Clientes_TB_Vagas_Id",
                table: "TB_Clientes",
                column: "Id",
                principalTable: "TB_Vagas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Experiencias_TB_Freelancers_FreelancerId1",
                table: "TB_Experiencias",
                column: "FreelancerId1",
                principalTable: "TB_Freelancers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_Clientes_TB_Vagas_Id",
                table: "TB_Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_Freelancers_TB_Vagas_Id",
                table: "TB_Freelancers");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_Experiencias_TB_Freelancers_FreelancerId1",
                table: "TB_Experiencias");

            migrationBuilder.DropTable(
                name: "TB_Vagas");

            migrationBuilder.DropTable(
                name: "TB_Clientes");

            migrationBuilder.DropTable(
                name: "TB_Freelancers");

            migrationBuilder.DropTable(
                name: "TB_Experiencias");
        }
    }
}
