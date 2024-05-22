using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMediaFreelas.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AdjustOnFreelancerV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_Clientes_TB_Vagas_Id",
                table: "TB_Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_Freelancers_TB_Experiencias_Id",
                table: "TB_Freelancers");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_Freelancers_TB_Vagas_Id",
                table: "TB_Freelancers");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TB_Freelancers",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TB_Clientes",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_Vagas_ClienteId",
                table: "TB_Vagas",
                column: "ClienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_Vagas_FreelancerId",
                table: "TB_Vagas",
                column: "FreelancerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_Experiencias_FreelancerId",
                table: "TB_Experiencias",
                column: "FreelancerId",
                unique: true);

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

            migrationBuilder.DropIndex(
                name: "IX_TB_Vagas_ClienteId",
                table: "TB_Vagas");

            migrationBuilder.DropIndex(
                name: "IX_TB_Vagas_FreelancerId",
                table: "TB_Vagas");

            migrationBuilder.DropIndex(
                name: "IX_TB_Experiencias_FreelancerId",
                table: "TB_Experiencias");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TB_Freelancers",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TB_Clientes",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Clientes_TB_Vagas_Id",
                table: "TB_Clientes",
                column: "Id",
                principalTable: "TB_Vagas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
    }
}
