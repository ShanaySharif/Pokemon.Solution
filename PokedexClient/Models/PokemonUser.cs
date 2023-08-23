namespace PokedexClient.Models;

public class PokemonUser
{
    public int PokemonUserId { get; set; }
    public string ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
    public int PokemonId { get; set; }
    public Pokemon Pokemon { get; set; }
}
