using Microsoft.EntityFrameworkCore.Migrations;

namespace EchoTechnologyComplaintTicketingApp.Migrations
{
    public partial class InitialCreate_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Demands",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Complaints",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "358f1269-a4b8-47a5-8872-f36af4d907d8", "AQAAAAEAACcQAAAAEKYZAOsPvzyCB3fIBVuzur2Vx/43I/uKNH4vq/Njn9UbfA6gBtnCUMgYNBrQwLM19A==", "3bdb616b-ff2c-4ea3-a17a-866be52a009e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Demands");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Complaints");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "654df45a-0965-4f08-93e7-d91b304998f9", "AQAAAAEAACcQAAAAENcjJagFdRdOGvWN7rpMSL0QAl75OuqyJw/LXWfDRsLXwzETX5n4/vfdo+FKFppHSA==", "d06fe353-3b1f-4b87-843f-7f1b078a471f" });
        }
    }
}
