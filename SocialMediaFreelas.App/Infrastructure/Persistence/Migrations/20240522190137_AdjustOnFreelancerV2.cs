using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMediaFreelas.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AdjustOnFreelancerV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_Clientes_TB_Vagas_Id",
                table: "TB_Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_Experiencias_TB_Freelancers_FreelancerId",
                table: "TB_Experiencias");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_Experiencias_TB_Freelancers_Id",
                table: "TB_Experiencias");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_Freelancers_TB_Vagas_Id",
                table: "TB_Freelancers");

            migrationBuilder.DropIndex(
                name: "IX_TB_Experiencias_FreelancerId",
                table: "TB_Experiencias");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TB_Experiencias",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "FreelancerId1",
                table: "TB_Experiencias",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_Experiencias_FreelancerId1",
                table: "TB_Experiencias",
                column: "FreelancerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Clientes_TB_Vagas_Id",
                table: "TB_Clientes",
                column: "Id",
                principalTable: "TB_Vagas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Experiencias_TB_Freelancers_FreelancerId1",
                table: "TB_Experiencias",
                column: "FreelancerId1",
                principalTable: "TB_Freelancers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Freelancers_TB_Experiencias_Id",
                table: "TB_Freelancers",
                column: "Id",
                principalTable: "TB_Experiencias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Freelancers_TB_Vagas_Id",
                table: "TB_Freelancers",
                column: "Id",
                principalTable: "TB_Vagas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_Clientes_TB_Vagas_Id",
                table: "TB_Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_Experiencias_TB_Freelancers_FreelancerId1",
                table: "TB_Experiencias");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_Freelancers_TB_Experiencias_Id",
                table: "TB_Freelancers");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_Freelancers_TB_Vagas_Id",
                table: "TB_Freelancers");

            migrationBuilder.DropIndex(
                name: "IX_TB_Experiencias_FreelancerId1",
                table: "TB_Experiencias");

            migrationBuilder.DropColumn(
                name: "FreelancerId1",
                table: "TB_Experiencias");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TB_Experiencias",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_Experiencias_FreelancerId",
                table: "TB_Experiencias",
                column: "FreelancerId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Clientes_TB_Vagas_Id",
                table: "TB_Clientes",
                column: "Id",
                principalTable: "TB_Vagas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Experiencias_TB_Freelancers_FreelancerId",
                table: "TB_Experiencias",
                column: "FreelancerId",
                principalTable: "TB_Freelancers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Experiencias_TB_Freelancers_Id",
                table: "TB_Experiencias",
                column: "Id",
                principalTable: "TB_Freelancers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Freelancers_TB_Vagas_Id",
                table: "TB_Freelancers",
                column: "Id",
                principalTable: "TB_Vagas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
