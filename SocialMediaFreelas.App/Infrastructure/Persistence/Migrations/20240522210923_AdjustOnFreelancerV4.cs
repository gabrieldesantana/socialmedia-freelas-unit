using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMediaFreelas.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AdjustOnFreelancerV4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_Experiencias_TB_Freelancers_FreelancerId",
                table: "TB_Experiencias");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_Vagas_TB_Clientes_ClienteId",
                table: "TB_Vagas");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_Vagas_TB_Freelancers_FreelancerId",
                table: "TB_Vagas");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Experiencias_TB_Freelancers_FreelancerId",
                table: "TB_Experiencias",
                column: "FreelancerId",
                principalTable: "TB_Freelancers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Vagas_TB_Clientes_ClienteId",
                table: "TB_Vagas",
                column: "ClienteId",
                principalTable: "TB_Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Vagas_TB_Freelancers_FreelancerId",
                table: "TB_Vagas",
                column: "FreelancerId",
                principalTable: "TB_Freelancers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_Experiencias_TB_Freelancers_FreelancerId",
                table: "TB_Experiencias");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_Vagas_TB_Clientes_ClienteId",
                table: "TB_Vagas");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_Vagas_TB_Freelancers_FreelancerId",
                table: "TB_Vagas");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Experiencias_TB_Freelancers_FreelancerId",
                table: "TB_Experiencias",
                column: "FreelancerId",
                principalTable: "TB_Freelancers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Vagas_TB_Clientes_ClienteId",
                table: "TB_Vagas",
                column: "ClienteId",
                principalTable: "TB_Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Vagas_TB_Freelancers_FreelancerId",
                table: "TB_Vagas",
                column: "FreelancerId",
                principalTable: "TB_Freelancers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
