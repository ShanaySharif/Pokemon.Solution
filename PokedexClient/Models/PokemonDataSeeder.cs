using CsvHelper;
using CsvHelper.Configuration;
using PokedexClient.DataTransferObjects;
using PokedexClient.Models;
using System.Globalization;
using System.IO;
using System.Linq;



public static class PokemonDataSeeder
{
    public static void Seed(PokedexContext context)
    {
        var pokemonFilePath = Path.Combine("Data", "FirstGenPokemon.csv");

        // Reading pokemon data
        using (var reader = new StreamReader(pokemonFilePath))
        using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
        {
            var pokemonDtos = csv.GetRecords<PokemonDto>().ToList();
            var pokemons = pokemonDtos.Select(p => new Pokemon
            {
                Number = p.Number,
                Name = p.Name,  
                Height = p.Height,
                Weight = p.Weight,
                Type1 = p.Type1,
                Type2 = p.Type2,
                HP = p.HP,
                Attack = p.Attack,
                Defense = p.Defense,
                Special = p.Special,
                Speed = p.Speed,
            }).ToList();

            context.Pokemons.AddRange(pokemons);
            context.SaveChanges();
        }
    }
}
