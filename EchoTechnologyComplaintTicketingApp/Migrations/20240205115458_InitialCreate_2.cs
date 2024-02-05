using Microsoft.EntityFrameworkCore.Migrations;

namespace EchoTechnologyComplaintTicketingApp.Migrations
{
    public partial class InitialCreate_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HashedPassword",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "654df45a-0965-4f08-93e7-d91b304998f9", "AQAAAAEAACcQAAAAENcjJagFdRdOGvWN7rpMSL0QAl75OuqyJw/LXWfDRsLXwzETX5n4/vfdo+FKFppHSA==", "d06fe353-3b1f-4b87-843f-7f1b078a471f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HashedPassword",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "HashedPassword", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68497ae9-70a6-426f-9973-0d7f557c6116", "AQAAAAEAACcQAAAAEHmNUo82HmjTOYU/uKK+8s2ulMD18/s5JDV8k3WkZ+nF8hOWY7x8Su88g1AA7U3Bvg==", null, "7925891c-eccb-462c-b8df-5839e32f5801" });
        }
    }
}
