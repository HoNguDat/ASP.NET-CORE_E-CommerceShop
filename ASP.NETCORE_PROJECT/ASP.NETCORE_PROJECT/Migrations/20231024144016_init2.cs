using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NETCORE_PROJECT.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_comment_userid",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Product_comment_productid",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_order_UserId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Order_orderdetail_orderid",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Product_orderdetail_productid",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Brand_product_brandid",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_product_cateid",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_TypeLaptop_product_typeid",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_product_brandid",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_product_cateid",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_comment_productid",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "product_brandid",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "product_cateid",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "comment_productid",
                table: "Comment");

            migrationBuilder.RenameColumn(
                name: "typeLaptop_name",
                table: "TypeLaptop",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "typeLaptop_image",
                table: "TypeLaptop",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "typeLaptop_id",
                table: "TypeLaptop",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "product_yearofmanufacturer",
                table: "Product",
                newName: "YearOfManufacturer");

            migrationBuilder.RenameColumn(
                name: "product_typeid",
                table: "Product",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "product_storage",
                table: "Product",
                newName: "Storage");

            migrationBuilder.RenameColumn(
                name: "product_size_volume",
                table: "Product",
                newName: "SizeVolume");

            migrationBuilder.RenameColumn(
                name: "product_sim",
                table: "Product",
                newName: "Sim");

            migrationBuilder.RenameColumn(
                name: "product_screen",
                table: "Product",
                newName: "Screen");

            migrationBuilder.RenameColumn(
                name: "product_ram",
                table: "Product",
                newName: "Ram");

            migrationBuilder.RenameColumn(
                name: "product_quantity",
                table: "Product",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "product_price",
                table: "Product",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "product_origin",
                table: "Product",
                newName: "Origin");

            migrationBuilder.RenameColumn(
                name: "product_operatingsystem",
                table: "Product",
                newName: "OperatingSystem");

            migrationBuilder.RenameColumn(
                name: "product_name",
                table: "Product",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "product_image",
                table: "Product",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "product_graphiccard",
                table: "Product",
                newName: "GraphicCard");

            migrationBuilder.RenameColumn(
                name: "product_frontcamera",
                table: "Product",
                newName: "FrontCamera");

            migrationBuilder.RenameColumn(
                name: "product_feature",
                table: "Product",
                newName: "Feature");

            migrationBuilder.RenameColumn(
                name: "product_face",
                table: "Product",
                newName: "Face");

            migrationBuilder.RenameColumn(
                name: "product_description",
                table: "Product",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "product_cpu",
                table: "Product",
                newName: "Cpu");

            migrationBuilder.RenameColumn(
                name: "product_color",
                table: "Product",
                newName: "Color");

            migrationBuilder.RenameColumn(
                name: "product_battery",
                table: "Product",
                newName: "Battery");

            migrationBuilder.RenameColumn(
                name: "product_backcamera",
                table: "Product",
                newName: "BackCamera");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "Product",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_product_typeid",
                table: "Product",
                newName: "IX_Product_TypeId");

            migrationBuilder.RenameColumn(
                name: "orderdetail_quantity",
                table: "OrderDetail",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "orderdetail_productid",
                table: "OrderDetail",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "orderdetail_orderid",
                table: "OrderDetail",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "orderdetail_id",
                table: "OrderDetail",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_orderdetail_productid",
                table: "OrderDetail",
                newName: "IX_OrderDetail_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_orderdetail_orderid",
                table: "OrderDetail",
                newName: "IX_OrderDetail_OrderId");

            migrationBuilder.RenameColumn(
                name: "order_totalbill",
                table: "Order",
                newName: "TotalBill");

            migrationBuilder.RenameColumn(
                name: "order_status",
                table: "Order",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "order_note",
                table: "Order",
                newName: "Note");

            migrationBuilder.RenameColumn(
                name: "order_createat",
                table: "Order",
                newName: "CreateAt");

            migrationBuilder.RenameColumn(
                name: "order_UserId",
                table: "Order",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "order_id",
                table: "Order",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Order_order_UserId",
                table: "Order",
                newName: "IX_Order_UserId");

            migrationBuilder.RenameColumn(
                name: "comment_userid",
                table: "Comment",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "comment_createdon",
                table: "Comment",
                newName: "CreateAt");

            migrationBuilder.RenameColumn(
                name: "comment_content",
                table: "Comment",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "comment_id",
                table: "Comment",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_comment_userid",
                table: "Comment",
                newName: "IX_Comment_UserId");

            migrationBuilder.RenameColumn(
                name: "cate_name",
                table: "Category",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "cate_image",
                table: "Category",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "cate_id",
                table: "Category",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "brand_name",
                table: "Brand",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "brand_image",
                table: "Brand",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "brand_id",
                table: "Brand",
                newName: "Id");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "BrandId",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Comment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandId",
                table: "Product",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ProductId",
                table: "Comment",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_UserId",
                table: "Comment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Product_ProductId",
                table: "Comment",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_UserId",
                table: "Order",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Order_OrderId",
                table: "OrderDetail",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Product_ProductId",
                table: "OrderDetail",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Brand_BrandId",
                table: "Product",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_TypeLaptop_TypeId",
                table: "Product",
                column: "TypeId",
                principalTable: "TypeLaptop",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_UserId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Product_ProductId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_UserId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Order_OrderId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Product_ProductId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Brand_BrandId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_TypeLaptop_TypeId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_BrandId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_CategoryId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_ProductId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Comment");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TypeLaptop",
                newName: "typeLaptop_name");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "TypeLaptop",
                newName: "typeLaptop_image");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TypeLaptop",
                newName: "typeLaptop_id");

            migrationBuilder.RenameColumn(
                name: "YearOfManufacturer",
                table: "Product",
                newName: "product_yearofmanufacturer");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Product",
                newName: "product_typeid");

            migrationBuilder.RenameColumn(
                name: "Storage",
                table: "Product",
                newName: "product_storage");

            migrationBuilder.RenameColumn(
                name: "SizeVolume",
                table: "Product",
                newName: "product_size_volume");

            migrationBuilder.RenameColumn(
                name: "Sim",
                table: "Product",
                newName: "product_sim");

            migrationBuilder.RenameColumn(
                name: "Screen",
                table: "Product",
                newName: "product_screen");

            migrationBuilder.RenameColumn(
                name: "Ram",
                table: "Product",
                newName: "product_ram");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Product",
                newName: "product_quantity");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Product",
                newName: "product_price");

            migrationBuilder.RenameColumn(
                name: "Origin",
                table: "Product",
                newName: "product_origin");

            migrationBuilder.RenameColumn(
                name: "OperatingSystem",
                table: "Product",
                newName: "product_operatingsystem");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Product",
                newName: "product_name");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Product",
                newName: "product_image");

            migrationBuilder.RenameColumn(
                name: "GraphicCard",
                table: "Product",
                newName: "product_graphiccard");

            migrationBuilder.RenameColumn(
                name: "FrontCamera",
                table: "Product",
                newName: "product_frontcamera");

            migrationBuilder.RenameColumn(
                name: "Feature",
                table: "Product",
                newName: "product_feature");

            migrationBuilder.RenameColumn(
                name: "Face",
                table: "Product",
                newName: "product_face");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Product",
                newName: "product_description");

            migrationBuilder.RenameColumn(
                name: "Cpu",
                table: "Product",
                newName: "product_cpu");

            migrationBuilder.RenameColumn(
                name: "Color",
                table: "Product",
                newName: "product_color");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Product",
                newName: "product_id");

            migrationBuilder.RenameColumn(
                name: "Battery",
                table: "Product",
                newName: "product_battery");

            migrationBuilder.RenameColumn(
                name: "BackCamera",
                table: "Product",
                newName: "product_backcamera");

            migrationBuilder.RenameIndex(
                name: "IX_Product_TypeId",
                table: "Product",
                newName: "IX_Product_product_typeid");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "OrderDetail",
                newName: "orderdetail_quantity");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "OrderDetail",
                newName: "orderdetail_productid");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "OrderDetail",
                newName: "orderdetail_orderid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "OrderDetail",
                newName: "orderdetail_id");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_ProductId",
                table: "OrderDetail",
                newName: "IX_OrderDetail_orderdetail_productid");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrderDetail",
                newName: "IX_OrderDetail_orderdetail_orderid");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Order",
                newName: "order_UserId");

            migrationBuilder.RenameColumn(
                name: "TotalBill",
                table: "Order",
                newName: "order_totalbill");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Order",
                newName: "order_status");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "Order",
                newName: "order_note");

            migrationBuilder.RenameColumn(
                name: "CreateAt",
                table: "Order",
                newName: "order_createat");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Order",
                newName: "order_id");

            migrationBuilder.RenameIndex(
                name: "IX_Order_UserId",
                table: "Order",
                newName: "IX_Order_order_UserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Comment",
                newName: "comment_userid");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Comment",
                newName: "comment_id");

            migrationBuilder.RenameColumn(
                name: "CreateAt",
                table: "Comment",
                newName: "comment_createdon");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Comment",
                newName: "comment_content");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_UserId",
                table: "Comment",
                newName: "IX_Comment_comment_userid");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Category",
                newName: "cate_name");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Category",
                newName: "cate_image");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Category",
                newName: "cate_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Brand",
                newName: "brand_name");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Brand",
                newName: "brand_image");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Brand",
                newName: "brand_id");

            migrationBuilder.AddColumn<Guid>(
                name: "product_brandid",
                table: "Product",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "product_cateid",
                table: "Product",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "comment_productid",
                table: "Comment",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "product_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "comment_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_product_brandid",
                table: "Product",
                column: "product_brandid");

            migrationBuilder.CreateIndex(
                name: "IX_Product_product_cateid",
                table: "Product",
                column: "product_cateid");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_comment_productid",
                table: "Comment",
                column: "comment_productid");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_comment_userid",
                table: "Comment",
                column: "comment_userid",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Product_comment_productid",
                table: "Comment",
                column: "comment_productid",
                principalTable: "Product",
                principalColumn: "product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_order_UserId",
                table: "Order",
                column: "order_UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Order_orderdetail_orderid",
                table: "OrderDetail",
                column: "orderdetail_orderid",
                principalTable: "Order",
                principalColumn: "order_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Product_orderdetail_productid",
                table: "OrderDetail",
                column: "orderdetail_productid",
                principalTable: "Product",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Brand_product_brandid",
                table: "Product",
                column: "product_brandid",
                principalTable: "Brand",
                principalColumn: "brand_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_product_cateid",
                table: "Product",
                column: "product_cateid",
                principalTable: "Category",
                principalColumn: "cate_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_TypeLaptop_product_typeid",
                table: "Product",
                column: "product_typeid",
                principalTable: "TypeLaptop",
                principalColumn: "typeLaptop_id");
        }
    }
}
