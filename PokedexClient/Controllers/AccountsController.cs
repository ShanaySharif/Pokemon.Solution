using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PokedexClient.Models;
using PokedexClient.ViewModels;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

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
      ApplicationUser user = new ApplicationUser { UserName = model.Email, Email = model.Email };
      IdentityResult result = await _userManager.CreateAsync(user, model.Password);
      if (result.Succeeded)
      {
        await AutoLoginUserAsync(user.UserName);
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

  // Method to auto login after registering.
  private async Task<bool> AutoLoginUserAsync(string username)
  {
    var user = await _userManager.FindByNameAsync(username);
    if (user != null)
    {
      await _signInManager.SignInAsync(user, isPersistent: true);
      return true;
    }
    return false;
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
                                 .ThenInclude(pu => pu.Pokemon)
                                 .FirstOrDefaultAsync(u => u.Id == currentUserId);

    if (user == null)
    {
      return NotFound();
    }

    var userProfileViewModel = new UserProfileViewModel
    {
      Id = user.Id,
      Email = user.UserName,
      PokemonUsers = user.PokemonUsers,
      Pokemons = user.PokemonUsers.Select(pu => pu.Pokemon).ToList()
    };

    return View(userProfileViewModel);
  }

  [HttpPost]
  [Authorize]
  public async Task<IActionResult> AddPokemonToUserList(int pokemonId)
  {
    // Get the current logged-in user's ID.
    string currentUserId = _userManager.GetUserId(User);

    // Check if this relationship already exists.
    var existingEntry = _db.PokemonUsers.FirstOrDefault(pu => pu.PokemonId == pokemonId && pu.ApplicationUserId == currentUserId);

    // If it doesn't exist, create a new relationship.
    if (existingEntry == null)
    {
      var newPokemonUser = new PokemonUser
      {
        ApplicationUserId = currentUserId,
        PokemonId = pokemonId
      };

      _db.PokemonUsers.Add(newPokemonUser);
      await _db.SaveChangesAsync();
    }

    // Redirect the user to the Profile view.
    return RedirectToAction("Profile");
  }


}

