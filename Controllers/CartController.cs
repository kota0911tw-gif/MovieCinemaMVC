using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class CartController : Controller
{
    private static List<CartItem> cartItems = new();

    public static List<CartItem> CartItems => cartItems;

    public IActionResult Index()
    {
        return View(cartItems);
    }

    public IActionResult Add(
        int movieId,
        string title,
        decimal price)
    {
        cartItems.Add(new CartItem
        {
            MovieId = movieId,
            MovieTitle = title,
            Price = price
        });

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Remove(int movieId)
    {
        var item = cartItems.FirstOrDefault(
            x => x.MovieId == movieId);

        if (item != null)
        {
            cartItems.Remove(item);
        }

        return RedirectToAction(nameof(Index));
    }
}