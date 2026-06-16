using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class MoviesController : Controller
{
private readonly ApplicationDbContext _context;


public MoviesController(ApplicationDbContext context)
{
    _context = context;
}

// Movie List + Search
public IActionResult Index(string searchString)
{
    var movies = _context.Movies.AsQueryable();

    if (!string.IsNullOrWhiteSpace(searchString))
    {
        movies = movies.Where(m =>
            m.Title.Contains(searchString));
    }

    return View(movies.ToList());
}

// Movie Details
public IActionResult Details(int id)
{
    var movie = _context.Movies.FirstOrDefault(m => m.Id == id);

    if (movie == null)
        return NotFound();

    return View(movie);
}

// Create GET
[HttpGet]
public IActionResult Create()
{
    return View();
}

// Create POST
[HttpPost]
public IActionResult Create(Movie movie)
{
    _context.Movies.Add(movie);
    _context.SaveChanges();

    return RedirectToAction(nameof(Index));
}

// Edit GET
[HttpGet]
public IActionResult Edit(int id)
{
    var movie = _context.Movies.FirstOrDefault(m => m.Id == id);

    if (movie == null)
        return NotFound();

    return View(movie);
}

// Edit POST
[HttpPost]
public IActionResult Edit(Movie movie)
{
    var existingMovie =
        _context.Movies.FirstOrDefault(m => m.Id == movie.Id);

    if (existingMovie == null)
        return NotFound();

    existingMovie.Title = movie.Title;
    existingMovie.Description = movie.Description;
    existingMovie.Price = movie.Price;
    existingMovie.ImageUrl = movie.ImageUrl;

    _context.SaveChanges();

    return RedirectToAction(nameof(Index));
}

// Delete
public IActionResult Delete(int id)
{
    var movie = _context.Movies.FirstOrDefault(m => m.Id == id);

    if (movie != null)
    {
        _context.Movies.Remove(movie);
        _context.SaveChanges();
    }

    return RedirectToAction(nameof(Index));
}


}
