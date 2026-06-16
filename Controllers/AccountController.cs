using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class AccountController : Controller
{
    private readonly ApplicationDbContext _context;

        
    public AccountController(ApplicationDbContext context)
    {
        _context = context;
    }

// Login

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string email, string password)
    {
        var user = _context.Users.FirstOrDefault(x =>
            x.Email == email &&
            x.Password == password);

        if (user == null)
        {
            ViewBag.Error = "Invalid Email or Password";
            return View();
        }

        TempData["UserName"] = user.FullName;
        TempData["Role"] = user.Role;

        return RedirectToAction("Index", "Home");
    }

// Register

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(ApplicationUser user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();

        return RedirectToAction("Login");
    }

// Logout

    public IActionResult Logout()
    {
        TempData.Clear();

        return RedirectToAction("Login");
    }
    

}