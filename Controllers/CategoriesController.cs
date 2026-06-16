using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class CategoriesController : Controller
{
    private readonly ApplicationDbContext _context;

        
    public CategoriesController(ApplicationDbContext context)
    {
        _context = context;
    }

// Category List
    public IActionResult Index()
    {
        return View(_context.Categories.ToList());
    }

// Details
    public IActionResult Details(int id)
    {
        var category =
            _context.Categories.FirstOrDefault(c => c.Id == id);

        if (category == null)
            return NotFound();

        return View(category);
    }

// Create GET
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

// Create POST
    [HttpPost]
    public IActionResult Create(Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

// Edit GET
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var category =
            _context.Categories.FirstOrDefault(c => c.Id == id);

        if (category == null)
            return NotFound();

        return View(category);
    }

// Edit POST
    [HttpPost]
    public IActionResult Edit(Category category)
    {
        var existingCategory =
            _context.Categories.FirstOrDefault(c => c.Id == category.Id);

        if (existingCategory == null)
            return NotFound();

        existingCategory.Name = category.Name;

        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

// Delete
    public IActionResult Delete(int id)
    {
        var category =
            _context.Categories.FirstOrDefault(c => c.Id == id);

        if (category != null)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        return RedirectToAction(nameof(Index));
    }
    
}