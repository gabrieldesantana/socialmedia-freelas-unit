using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMediaFreelas.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AdjustTableExperiencias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_Experiencias_TB_Freelancers_FreelancerId1",
                table: "TB_Experiencias");

            migrationBuilder.DropIndex(
                name: "IX_TB_Experiencias_FreelancerId",
                table: "TB_Experiencias");

            migrationBuilder.DropIndex(
                name: "IX_TB_Experiencias_FreelancerId1",
                table: "TB_Experiencias");

            migrationBuilder.DropColumn(
                name: "FreelancerId1",
                table: "TB_Experiencias");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Experiencias_FreelancerId",
                table: "TB_Experiencias",
                column: "FreelancerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TB_Experiencias_FreelancerId",
                table: "TB_Experiencias");

            migrationBuilder.AddColumn<int>(
                name: "FreelancerId1",
                table: "TB_Experiencias",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_Experiencias_FreelancerId",
                table: "TB_Experiencias",
                column: "FreelancerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_Experiencias_FreelancerId1",
                table: "TB_Experiencias",
                column: "FreelancerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Experiencias_TB_Freelancers_FreelancerId1",
                table: "TB_Experiencias",
                column: "FreelancerId1",
                principalTable: "TB_Freelancers",
                principalColumn: "Id");
        }
    }
}
