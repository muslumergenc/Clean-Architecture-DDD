using DDDTest.Application.Commands.Categories.Commands;
using DDDTest.Application.Queries.Categories;
using DDDTest.Application.Queries.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace DDDTest.Presentation.Controllers;
public class CategoriesController : Controller
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> Index()
    {
        var categories = await _mediator.Send(new GetAllCategoriesQuery());
        return View(categories);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            ModelState.AddModelError("", "Name is required.");
            return View();
        }

        await _mediator.Send(new CreateCategoryCommand { Name = name });
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var category = await _mediator.Send(new GetCategoryByIdQuery { Id = id });
        if (category == null) return NotFound();

        return View(category);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            ModelState.AddModelError("", "Name is required.");
            return View();
        }

        await _mediator.Send(new UpdateCategoryCommand { Id = id, NewName = name });
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteCategoryCommand { Id = id });
        return RedirectToAction(nameof(Index));
    }
    
    [HttpGet("products/{id}")]
    public async Task<IActionResult> Products(int id)
    {
        var products = await _mediator.Send(new GetProductsByCategoryIdQuery { CategoryId = id });
        var categories = await _mediator.Send(new GetAllCategoriesQuery());
        var name=categories.FirstOrDefault()?.Name;
        ViewBag.CategoryName = name;
        return View(products);
    }
}