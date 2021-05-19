using Microsoft.EntityFrameworkCore.Migrations;

namespace FreakyFashionServices.Catalog.Migrations
{
    public partial class IntialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleNumber = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    AvailableStock = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "ArticleNumber", "AvailableStock", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "atq134", 1, "description1", "name1", 101 },
                    { 2, "vdw234", 2, "description2", "name2", 102 },
                    { 3, "opa554", 3, "description3", "name3", 103 },
                    { 4, "ort578", 4, "description4", "name4", 104 },
                    { 5, "ace548", 5, "description5", "name5", 105 },
                    { 6, "pob789", 6, "description6", "name6", 106 },
                    { 7, "acr467", 7, "description7", "name7", 107 },
                    { 8, "pav356", 8, "description8", "name8", 108 },
                    { 9, "zzz728", 9, "description9", "name9", 109 },
                    { 10, "xxx823", 10, "description10", "name10", 110 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
