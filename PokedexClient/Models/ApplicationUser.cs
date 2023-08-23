using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;


namespace PokedexClient.Models;

public class ApplicationUser : IdentityUser
{
    public List<PokemonUser> PokemonUser { get; set; }
}


