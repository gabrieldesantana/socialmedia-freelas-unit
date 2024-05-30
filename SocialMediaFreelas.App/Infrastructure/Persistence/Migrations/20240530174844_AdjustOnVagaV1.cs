using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMediaFreelas.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AdjustOnVagaV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FreelancerId",
                table: "TB_Vagas",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FreelancerId",
                table: "TB_Vagas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);
        }
    }
}
