using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public class AdminController : Controller
{
    public IActionResult Dashboard()
    {
        ViewBag.MovieCount = 5;
        ViewBag.CategoryCount = 3;
        ViewBag.OrderCount = 4;
        ViewBag.TotalRevenue = 2500;

            
        return View();
    }
    

}