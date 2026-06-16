using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class OrdersController : Controller
{
    private static List<Order> orders =
    [
        new()
        {
            Id = 1,
            MovieTitle = "Avengers",
            Price = 500,
            OrderDate = DateTime.Now
        },

        
        new()
        {
        Id = 2,
        MovieTitle = "Spider-Man",
        Price = 450,
        OrderDate = DateTime.Now
        }
    ];

    public IActionResult Index()
    {
        return View(orders);
    }
    

}