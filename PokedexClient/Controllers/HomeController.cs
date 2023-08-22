using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PokedexClient.Models;

namespace PokedexClient.Controllers;

public class HomeController : Controller
{
    
    private readonly PokedexContext _db;
    
    public HomeController(PokedexContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        return View();
        
    }

}