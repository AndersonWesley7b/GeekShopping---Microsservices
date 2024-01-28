using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekShopping.ProductApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductDateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "id", "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 2L, "T-Shirt", "Uma caneca para você beber seu café", "https://images.tcdn.com.br/img/img_prod/1066831/caneca_bumbum_grandao_escolha_a_cor_da_caneca_nao_e_magica_3145_1_67375d7557d970ab318292cb6952799c.jpg", "Name", 69.9m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "id",
                keyValue: 2L);
        }
    }
}
