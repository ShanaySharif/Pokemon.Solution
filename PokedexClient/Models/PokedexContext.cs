using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace PokedexClient.Models;

public class PokedexContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<Pokemon> Pokemons { get; set; }
    public DbSet<PokemonUser> PokemonsUsers { get; set; }
    public PokedexContext(DbContextOptions options) : base(options) { }
}




