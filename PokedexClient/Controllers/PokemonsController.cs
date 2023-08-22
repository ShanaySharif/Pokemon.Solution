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
        ViewBag.Types = PokemonTypes.Dictionary;
        List<Pokemon> model = _db.Pokemons.ToList();

        return View(model);
    }

    // Post Search()
    [HttpPost]
    public ActionResult Search(string name, List<int> types)
    {
        // Return an empty list directly if more than 3 types are selected
        if (types.Count > 2)
        {
            ViewBag.Types = PokemonTypes.Dictionary;
            List<Pokemon> emptyList = new List<Pokemon>() { };
            return View(emptyList);
        }

        IQueryable<Pokemon> query = _db.Pokemons;

        if (!string.IsNullOrEmpty(name))
        {
            string nameTrim = name.ToLower().Trim();
            query = query.Where(p => p.Name.ToLower().Contains(nameTrim));
        }

        if (types.Any())
        {
            // Get type names from type values
            List<string> selectedTypeNames = types.Select(t => PokemonTypes.Dictionary.FirstOrDefault(x => x.Value == t).Key).ToList();

            if (selectedTypeNames.Count == 2)
            {
                query = query.Where(p => selectedTypeNames.Contains(p.Type1) && selectedTypeNames.Contains(p.Type2));
            }

            if (selectedTypeNames.Count == 1)
            {
                query = query.Where(p => selectedTypeNames.Contains(p.Type1));
            }
        }

        ViewBag.Types = PokemonTypes.Dictionary;
        List<Pokemon> model = query.ToList();

        return View(model);
    }

    public ActionResult Details(int id)
    {
        Pokemon thisPokemon = _db.Pokemons.FirstOrDefault(p => p.PokemonId == id);
        {
            return View(thisPokemon);
        }
    }

}