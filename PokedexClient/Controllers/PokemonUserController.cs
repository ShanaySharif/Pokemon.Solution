using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PokedexClient.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace PokemonUserController.Controllers;

public class PokemonUserController : Controller
{
    private readonly PokedexContext _db;

    public PokemonUserController(PokedexContext db)
    {
        _db = db;
    }


}