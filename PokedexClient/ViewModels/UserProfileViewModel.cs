using PokedexClient.Models;
using System.Collections.Generic;

public class UserProfileViewModel
{
    public string Id { get; set; }
    public string Email { get; set; }
    public List<PokemonUser> PokemonUsers { get; set; }
}
