using DDDTest.Application.Commands.Products.Commands;
using DDDTest.Application.Queries.Products;
using DDDTest.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DDDTest.Presentation.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // LIST ALL PRODUCTS
        public async Task<IActionResult> Index()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            return View(products);
        }

        // SHOW PRODUCT DETAILS
        public async Task<IActionResult> Details(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery { Id = id });
            if (product == null) return NotFound();

            return View(product);
        }

        // CREATE NEW PRODUCT
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            if (!ModelState.IsValid)
                return View(command);

            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        // EDIT EXISTING PRODUCT
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery { Id = id });
            if (product == null) return NotFound();

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, UpdateProductCommand command)
        {
            if (!ModelState.IsValid)
                return View(command);

            command.Id = id;
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        // DELETE PRODUCT
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery { Id = id });
            if (product == null) return NotFound();

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _mediator.Send(new DeleteProductCommand { Id = id });
            return RedirectToAction(nameof(Index));
        }
    }
}
