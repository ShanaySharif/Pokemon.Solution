using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PokedexClient.Models;

public class Pokemon
{
    public int PokemonId { get; set; }
    public int Number { get; set; }
    public string Name { get; set; }
    public float Height { get; set; }
    public float Weight { get; set; }
    public string Type1 { get; set; }
    public string Type2 { get; set; }
    public int  HP { get; set; }
    public int  Attack { get; set; }
    public int  Defense { get; set; }
    public int  Special { get; set; }
    public int  Speed { get; set; }
    
    // public Account User { get; set; }
}
