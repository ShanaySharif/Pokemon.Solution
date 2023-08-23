using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PokedexClient.Models;
using PokedexClient.ViewModels;
using System.Threading.Tasks;
using System.Linq;


namespace PokedexClient.Controllers;


public class AccountsController : Controller
{
  private readonly PokedexContext _db;
  private readonly UserManager<ApplicationUser> _userManager;
  private readonly SignInManager<ApplicationUser> _signInManager;

  public AccountsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, PokedexContext db)
  {
    _userManager = userManager;
    _signInManager = signInManager;
    _db = db;
  }

  public ActionResult Index()
  {
    return View();
  }

  public IActionResult Register()
  {
    return View();
  }

  [HttpPost]
  public async Task<ActionResult> Register(RegisterViewModel model)
  {
    if (!ModelState.IsValid)
    {
      return View(model);
    }
    else
    {
      ApplicationUser user = new ApplicationUser { UserName = model.Email };
      IdentityResult result = await _userManager.CreateAsync(user, model.Password);
      if (result.Succeeded)
      {
        return RedirectToAction("Index");
      }
      else
      {
        foreach (IdentityError error in result.Errors)
        {
          ModelState.AddModelError("", error.Description);
        }
        return View(model);
      }
    }
  }

  public ActionResult Login()
  {
    return View();
  }

  [HttpPost]
  public async Task<ActionResult> Login(LoginViewModel model)
  {
    if (!ModelState.IsValid)
    {
      return View(model);
    }
    else
    {
      Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
      if (result.Succeeded)
      {
        return RedirectToAction("Index", "Home");
      }
      else
      {

        ModelState.AddModelError("", "We do not have an account matching that username and password. Please make sure you spelled both of them correctly.");
        return View(model);
      }
    }
  }

  [HttpPost]
  public async Task<ActionResult> LogOff()
  {
    await _signInManager.SignOutAsync();
    return RedirectToAction("Index");
  }

  [HttpGet("Accounts/Profile")]
  public async Task<IActionResult> Profile()
  {
    // Check if the user is authenticated
    if (!User.Identity.IsAuthenticated)
    {
      return Unauthorized();
    }

    // Get the currently logged-in user's ID.
    string currentUserId = _userManager.GetUserId(User);

    // Get the user and their Pokemon list using UserManager.
    // Here, we include the PokemonUser list.
    var user = await _userManager.Users
                                 .Include(u => u.PokemonUsers)
                                 .ThenInclude(pu => pu.Pokemon)  // If you want to load Pokemon details too.
                                 .FirstOrDefaultAsync(u => u.Id == currentUserId);

    if (user == null)
    {
      return NotFound();
    }

    var userProfileViewModel = new UserProfileViewModel
    {
      Id = user.Id,
      Email = user.Email,
      PokemonUsers = user.PokemonUsers
    };

    return View(userProfileViewModel);
  }

  [HttpPost]
  public ActionResult DeletePokemonFromUserList(int id)
  {
    PokemonUser thisPokemonUser = _db.PokemonUsers.FirstOrDefault(pokemonUser => pokemonUser.PokemonUserId == id);
    return View(thisPokemonUser);
  }

  [HttpPost]
  public ActionResult AddPokemonToUserList(PokemonUser pokemonUser, int pokemonId)
  {
#nullable enable
    PokemonUser? joinEntity = _db.PokemonUsers.FirstOrDefault(join => (join.PokemonId == pokemonId && join.PokemonUserId == pokemonUser.PokemonUserId));
#nullable disable
    if (joinEntity == null && pokemonId != 0)
    {
      _db.PokemonUsers.Add(new PokemonUser() { PokemonId = pokemonId, PokemonUserId = pokemonUser.PokemonUserId });
      _db.SaveChanges();
    }
    return RedirectToAction("Details", new { id = pokemonUser.PokemonId });
  }
}

