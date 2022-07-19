using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClientApi.Migrations
{
    public partial class removecolumnteste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("alter table client drop column coluna_teste");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "client");
        }
    }
}
