using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMediaFreelas.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableVagasEFreelancers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_Vagas_TB_Freelancers_FreelancerId",
                table: "TB_Vagas");

            migrationBuilder.DropIndex(
                name: "IX_TB_Vagas_FreelancerId",
                table: "TB_Vagas");

            migrationBuilder.DropColumn(
                name: "FreelancerId",
                table: "TB_Vagas");

            migrationBuilder.CreateTable(
                name: "FreelancerVaga",
                columns: table => new
                {
                    FreelancersId = table.Column<int>(type: "INTEGER", nullable: false),
                    VagasId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreelancerVaga", x => new { x.FreelancersId, x.VagasId });
                    table.ForeignKey(
                        name: "FK_FreelancerVaga_TB_Freelancers_FreelancersId",
                        column: x => x.FreelancersId,
                        principalTable: "TB_Freelancers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FreelancerVaga_TB_Vagas_VagasId",
                        column: x => x.VagasId,
                        principalTable: "TB_Vagas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FreelancerVaga_VagasId",
                table: "FreelancerVaga",
                column: "VagasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FreelancerVaga");

            migrationBuilder.AddColumn<int>(
                name: "FreelancerId",
                table: "TB_Vagas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_Vagas_FreelancerId",
                table: "TB_Vagas",
                column: "FreelancerId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Vagas_TB_Freelancers_FreelancerId",
                table: "TB_Vagas",
                column: "FreelancerId",
                principalTable: "TB_Freelancers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
