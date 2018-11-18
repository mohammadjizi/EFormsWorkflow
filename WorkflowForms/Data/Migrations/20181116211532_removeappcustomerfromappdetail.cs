using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkflowForms.Data.Migrations
{
    public partial class removeappcustomerfromappdetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationCustomer_ApplicationDetail_AppDetailId",
                table: "ApplicationCustomer");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationCustomer_AppDetailId",
                table: "ApplicationCustomer");

            migrationBuilder.DropColumn(
                name: "AppDetailId",
                table: "ApplicationCustomer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppDetailId",
                table: "ApplicationCustomer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationCustomer_AppDetailId",
                table: "ApplicationCustomer",
                column: "AppDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationCustomer_ApplicationDetail_AppDetailId",
                table: "ApplicationCustomer",
                column: "AppDetailId",
                principalTable: "ApplicationDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
