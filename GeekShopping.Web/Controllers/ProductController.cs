using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _ProductService;

        public ProductController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }

        public async Task<IActionResult> ProductIndex()
        {
            var Products = await _ProductService.FindAllProducts();
            return View(Products);
        } 

        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductModel Model)
        {
            if(ModelState.IsValid)
            {
                var Response = await _ProductService.CreateProduct(Model);
                if(Response != null)
                    return RedirectToAction(nameof(ProductIndex));
            }
           
            return View(Model);

        }
        
        public async Task<IActionResult> ProductUpdate(int Id)
        {
            var Model = await _ProductService.FindProductById(Id);
            if(Model != null)
                return View(Model);
            return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> ProductUpdate(ProductModel Model)
        {
            if(ModelState.IsValid)
            {
                var Response = await _ProductService.UpdateProduct(Model);
                if(Response != null)
                    return RedirectToAction(nameof(ProductIndex));
            }
           
            return View(Model);

        }

        public async Task<IActionResult> ProductDelete(int Id)
        {
            var Model = await _ProductService.FindProductById(Id);
            if (Model != null)
                return View(Model);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProductDelete(ProductModel Model)
        {
                var Response = await _ProductService.DeleteProductById(Model.Id);
                if (Response)
                    return RedirectToAction(nameof(ProductIndex));
            return View(Model);

        }
    }
}
