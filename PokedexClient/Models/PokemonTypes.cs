using System.Collections.Generic;

public static class PokemonTypes
{
    private static Dictionary<string, int> _dictionary = GenerateTypeToIdMap();

    public static Dictionary<string, int> Dictionary => new Dictionary<string, int>(_dictionary);

    private static Dictionary<string, int> GenerateTypeToIdMap()
    {
        var pokemonTypes = new List<string>
        {
            "Normal", "Fire", "Water", "Electric", "Grass", "Ice",
            "Fighting", "Poison", "Ground", "Flying", "Psychic",
            "Bug", "Rock", "Ghost", "Dragon"
        };

        var localTypeToIdMap = new Dictionary<string, int>();

        int id = 1;
        foreach (var type in pokemonTypes)
        {
            localTypeToIdMap[type] = id++;
        }

        return localTypeToIdMap;
    }
}