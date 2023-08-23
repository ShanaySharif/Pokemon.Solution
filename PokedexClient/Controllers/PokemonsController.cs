using Microsoft.AspNetCore.Mvc;
using PokedexClient.Models;
using System.Collections.Generic;
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
    public ActionResult Search(string name)
    {
        IQueryable<Pokemon> query = _db.Pokemons;

        if (!string.IsNullOrEmpty(name))
        {
            string nameTrim = name.ToLower().Trim();
            query = query.Where(p => p.Name.ToLower().Contains(nameTrim));
        }

        ViewBag.Types = PokemonTypes.Dictionary;
        List<Pokemon> model = query.ToList();

        return View(model);
    }

    // Handled by site.js
    [HttpPost]
    public ActionResult TypeFilter(string name)
    {
        IQueryable<Pokemon> query = _db.Pokemons;

        if (name != null)
        {
            query = query.Where(p => p.Type1 == name || p.Type2 == name);
        }

        ViewBag.Types = PokemonTypes.Dictionary;
        List<Pokemon> model = query.ToList();

        return PartialView("_PokemonList", model);
    }

    public ActionResult Details(int id)
    {
        Pokemon thisPokemon = _db.Pokemons.FirstOrDefault(p => p.PokemonId == id);
        {
            return View(thisPokemon);
        }
    }
}