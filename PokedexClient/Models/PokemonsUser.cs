namespace PokedexClient.Models;

public class PokemonsUser
{
    public int PokemonsUserId { get; set; }
    public string ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
    public int PokemonId { get; set; }
    public Pokemon Pokemon { get; set; }
}
