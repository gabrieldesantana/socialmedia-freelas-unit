using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMediaFreelas.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AdjustTableVagas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_Vagas_TB_Clientes_ClienteId1",
                table: "TB_Vagas");

            migrationBuilder.DropIndex(
                name: "IX_TB_Vagas_ClienteId",
                table: "TB_Vagas");

            migrationBuilder.DropIndex(
                name: "IX_TB_Vagas_ClienteId1",
                table: "TB_Vagas");

            migrationBuilder.DropIndex(
                name: "IX_TB_Vagas_FreelancerId",
                table: "TB_Vagas");

            migrationBuilder.DropColumn(
                name: "ClienteId1",
                table: "TB_Vagas");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Vagas_ClienteId",
                table: "TB_Vagas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Vagas_FreelancerId",
                table: "TB_Vagas",
                column: "FreelancerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TB_Vagas_ClienteId",
                table: "TB_Vagas");

            migrationBuilder.DropIndex(
                name: "IX_TB_Vagas_FreelancerId",
                table: "TB_Vagas");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId1",
                table: "TB_Vagas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_Vagas_ClienteId",
                table: "TB_Vagas",
                column: "ClienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_Vagas_ClienteId1",
                table: "TB_Vagas",
                column: "ClienteId1");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Vagas_FreelancerId",
                table: "TB_Vagas",
                column: "FreelancerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Vagas_TB_Clientes_ClienteId1",
                table: "TB_Vagas",
                column: "ClienteId1",
                principalTable: "TB_Clientes",
                principalColumn: "Id");
        }
    }
}
