using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClickNEat.API.Migrations
{
    /// <inheritdoc />
    public partial class AddMenuItemTranslations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DescriptionDe",
                table: "MenuItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionEn",
                table: "MenuItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionEs",
                table: "MenuItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameDe",
                table: "MenuItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameEn",
                table: "MenuItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameEs",
                table: "MenuItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "DescriptionDe", "DescriptionEn", "DescriptionEs", "NameDe", "NameEn", "NameEs" },
                values: new object[] { null, null, null, null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriptionDe",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "DescriptionEn",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "DescriptionEs",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "NameDe",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "NameEn",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "NameEs",
                table: "MenuItems");
        }
    }
}
