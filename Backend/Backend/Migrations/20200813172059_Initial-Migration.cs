using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Points",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Whatsapp = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Uf = table.Column<string>(maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Points", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PointItems",
                columns: table => new
                {
                    PointId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointItems", x => new { x.PointId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_PointItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PointItems_Points_PointId",
                        column: x => x.PointId,
                        principalTable: "Points",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Image", "ImageUrl", "Title" },
                values: new object[] { 1, "lampadas.svg", null, "Lâmpadas" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Image", "ImageUrl", "Title" },
                values: new object[] { 2, "baterias.svg", null, "Pilhas e Baterias" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Image", "ImageUrl", "Title" },
                values: new object[] { 3, "papeis-papelao.svg", null, "Papéis e Papelão" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Image", "ImageUrl", "Title" },
                values: new object[] { 4, "eletronicos.svg", null, "Resíduos Eletrônicos" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Image", "ImageUrl", "Title" },
                values: new object[] { 5, "organicos.svg", null, "Resíduos Orgânicos" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Image", "ImageUrl", "Title" },
                values: new object[] { 6, "oleo.svg", null, "Óleo de Cozinha" });

            migrationBuilder.CreateIndex(
                name: "IX_PointItems_ItemId",
                table: "PointItems",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PointItems");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Points");
        }
    }
}
