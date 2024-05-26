using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineLibrary.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBookFiels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookPrices_Discounts_DiscountId",
                table: "BookPrices");

            migrationBuilder.AddColumn<bool>(
                name: "Featured",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "JustArrived",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "DiscountId",
                table: "BookPrices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BookPrices_Discounts_DiscountId",
                table: "BookPrices",
                column: "DiscountId",
                principalTable: "Discounts",
                principalColumn: "DiscountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookPrices_Discounts_DiscountId",
                table: "BookPrices");

            migrationBuilder.DropColumn(
                name: "Featured",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "JustArrived",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "DiscountId",
                table: "BookPrices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookPrices_Discounts_DiscountId",
                table: "BookPrices",
                column: "DiscountId",
                principalTable: "Discounts",
                principalColumn: "DiscountId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
