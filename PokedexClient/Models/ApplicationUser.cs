using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration.UserSecrets;


namespace PokedexClient.Models;

public class ApplicationUser : IdentityUser
{
    public List<PokemonsUser> PokemonsUser { get; set; }
}


