using Microsoft.AspNetCore.Mvc;
using PokedexClient.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace PokemonUserController.Controllers;

public class PokemonsController : Controller
{
    private readonly PokedexContext _db;

    public PokemonsController(PokedexContext db)
    {
        _db = db;
    }

    public ActionResult Index()
    {
        List<PokemonUser> pokemonUsers = _db.PokemonUsers.ToList();
        return View(pokemonUsers);
    }

    public ActionResult Create()
        {
            return View();
        }
        
    [HttpPost]
    
    public ActionResult Create(PokemonUser pokemonUser)
        {
            if (ModelState.IsValid)
            {
                _db.PokemonUsers.Add(pokemonUser);
                _db.SaveChanges();
                return RedirectToAction("Index"); 
            }
            return View(pokemonUser);
        }
    
    [HttpPost]
    
    public ActionResult Edit(PokemonUser pokemonUser)
        {
            if (ModelState.IsValid)
            {
                _db.PokemonUsers.Update(pokemonUser);
                _db.SaveChanges();
                return RedirectToAction("Index"); 
            }
            return View(pokemonUser);
        }

    public ActionResult Delete(int id)
    {
        PokemonUser thisPokemonUser = _db.PokemonUsers.FirstOrDefault(pokemonUser => pokemonUser.PokemonUserId == id);
        return View(thisPokemonUser);

    }

    public ActionResult AddPokemon(int id)
    {
        PokemonUser thisPokemonUser = _db.PokemonUsers.FirstOrDefault(pokemonUser => pokemonUser.PokemonUserId == id);

        List<Pokemon> pokemons = _db.Pokemons.ToList();
        SelectList pokemonList = new SelectList(pokemons,"PokemonId", "Name");
        ViewBag.PokemonList = pokemonList;
        return View(thisPokemonUser);
    }

    [HttpPost]
     public ActionResult AddPokemon(PokemonUser pokemonUser, int pokemonId)
     {
        #nullable enable
        PokemonUser? joinEntity = _db.PokemonUsers.FirstOrDefault(join => (join.PokemonId == pokemonId && join.PokemonUserId == pokemonUser.PokemonUserId));
         #nullable disable
         if (joinEntity == null && pokemonId != 0)
         {
            _db.PokemonUsers.Add(new PokemonUser() {PokemonId = pokemonId, PokemonUserId = pokemonUser.PokemonUserId});
            _db.SaveChanges();
         }
         return RedirectToAction("Details", new {id = pokemonUser.PokemonId});
     }

}