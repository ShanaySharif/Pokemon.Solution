using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokedexClient.Migrations
{
    public partial class UserPage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonsUsers_AspNetUsers_ApplicationUserId",
                table: "PokemonsUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonsUsers_Pokemons_PokemonId",
                table: "PokemonsUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PokemonsUsers",
                table: "PokemonsUsers");

            migrationBuilder.RenameTable(
                name: "PokemonsUsers",
                newName: "PokemonUsers");

            migrationBuilder.RenameIndex(
                name: "IX_PokemonsUsers_PokemonId",
                table: "PokemonUsers",
                newName: "IX_PokemonUsers_PokemonId");

            migrationBuilder.RenameIndex(
                name: "IX_PokemonsUsers_ApplicationUserId",
                table: "PokemonUsers",
                newName: "IX_PokemonUsers_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PokemonUsers",
                table: "PokemonUsers",
                column: "PokemonUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonUsers_AspNetUsers_ApplicationUserId",
                table: "PokemonUsers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonUsers_Pokemons_PokemonId",
                table: "PokemonUsers",
                column: "PokemonId",
                principalTable: "Pokemons",
                principalColumn: "PokemonId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonUsers_AspNetUsers_ApplicationUserId",
                table: "PokemonUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonUsers_Pokemons_PokemonId",
                table: "PokemonUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PokemonUsers",
                table: "PokemonUsers");

            migrationBuilder.RenameTable(
                name: "PokemonUsers",
                newName: "PokemonsUsers");

            migrationBuilder.RenameIndex(
                name: "IX_PokemonUsers_PokemonId",
                table: "PokemonsUsers",
                newName: "IX_PokemonsUsers_PokemonId");

            migrationBuilder.RenameIndex(
                name: "IX_PokemonUsers_ApplicationUserId",
                table: "PokemonsUsers",
                newName: "IX_PokemonsUsers_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PokemonsUsers",
                table: "PokemonsUsers",
                column: "PokemonUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonsUsers_AspNetUsers_ApplicationUserId",
                table: "PokemonsUsers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonsUsers_Pokemons_PokemonId",
                table: "PokemonsUsers",
                column: "PokemonId",
                principalTable: "Pokemons",
                principalColumn: "PokemonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
