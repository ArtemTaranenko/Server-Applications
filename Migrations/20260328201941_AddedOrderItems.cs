using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AS_Taranenko_lab1_gr1.Migrations
{
    /// <inheritdoc />
    public partial class AddedOrderItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Item_Orders_OrderId",
                table: "Order_Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Item_Products_ProductId",
                table: "Order_Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order_Item",
                table: "Order_Item");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderStatuses");

            migrationBuilder.DropColumn(
                name: "OrderStatusHistoryId",
                table: "OrderStatuses");

            migrationBuilder.DropColumn(
                name: "OrderStatusHistoryId",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Order_Item",
                newName: "OrderItems");

            migrationBuilder.RenameIndex(
                name: "IX_Order_Item_ProductId",
                table: "OrderItems",
                newName: "IX_OrderItems_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_Item_OrderId",
                table: "OrderItems",
                newName: "IX_OrderItems_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                newName: "Order_Item");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_ProductId",
                table: "Order_Item",
                newName: "IX_Order_Item_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_OrderId",
                table: "Order_Item",
                newName: "IX_Order_Item_OrderId");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "OrderStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderStatusHistoryId",
                table: "OrderStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderStatusHistoryId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order_Item",
                table: "Order_Item",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Item_Orders_OrderId",
                table: "Order_Item",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Item_Products_ProductId",
                table: "Order_Item",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
