using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokedexClient.Migrations
{
    public partial class PokemonUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PokemonsUserId",
                table: "PokemonsUsers",
                newName: "PokemonUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PokemonUserId",
                table: "PokemonsUsers",
                newName: "PokemonsUserId");
        }
    }
}
