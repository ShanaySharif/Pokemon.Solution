using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PokedexClient.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq; 


namespace PokemonsController.Controllers;

public class PokemonsController : Controller
{
    private readonly PokedexContext _db;
    
    public PokemonsController(PokedexContext db)
    {
        _db = db;
    }

    public ActionResult Index()
    {
        List<Pokemon> model = _db.Pokemons.ToList();
        return View(model);
    }

    public ActionResult Search()
    {
        Dictionary<string, int> typesDictionary = new Dictionary<string, int>();

        var pokemonTypes = new List<string>
        {
            "Normal", "Fire", "Water", "Electric", "Grass", "Ice",
            "Fighting", "Poison", "Ground", "Flying", "Psychic", 
            "Bug", "Rock", "Ghost", "Dragon"
        };

        int id = 1;
        foreach (var type in pokemonTypes)
        {
            typesDictionary[type] = id++;
        }

        List<Pokemon> model = _db.Pokemons.ToList();
        ViewBag.Types = typesDictionary;

        return View(model);
    }

    // Post Search()
    [HttpPost]
    public ActionResult Search(string name)
    {
        Dictionary<string, int> typesDictionary = new Dictionary<string, int>();

        var pokemonTypes = new List<string>
        {
            "Normal", "Fire", "Water", "Electric", "Grass", "Ice",
            "Fighting", "Poison", "Ground", "Flying", "Psychic", 
            "Bug", "Rock", "Ghost", "Dragon"
        };

        int id = 1;
        foreach (var type in pokemonTypes)
        {
            typesDictionary[type] = id++;
        }

        List<Pokemon> model = _db.Pokemons.Where(p => p.Name.ToLower() == name.ToLower().Trim() ).ToList();
        return View(model);
    }
}