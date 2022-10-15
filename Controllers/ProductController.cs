using MangoWeb.Models;
using MangoWeb.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MangoWeb.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> ProductIndex()
    {
        List<ProductDto> products = new();
        var accessToken = await HttpContext.GetTokenAsync("access_token");
        var response = await _productService.GetAllProductsAsync<ResponseDto>(accessToken);
        if (response != null && response.IsSuccess)
        {
            products = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
        }
        return View(products);
    }

    public async Task<IActionResult> ProductCreate()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ProductCreate(ProductDto product)
    {
        if (ModelState.IsValid)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _productService.CreateProductAsync<ResponseDto>(product, accessToken);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(ProductIndex));
            }
        }
        return View(product);
    }

    public async Task<IActionResult> ProductEdit(int productId)
    {
        var accessToken = await HttpContext.GetTokenAsync("access_token");
        var response = await _productService.GetproductByIdAsync<ResponseDto>(productId, accessToken);
        if (response != null && response.IsSuccess)
        {
            var product = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
            return View(product);
        }
        return NotFound();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ProductEdit(ProductDto product)
    {
        if (ModelState.IsValid)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _productService.UpdateProductAsync<ResponseDto>(product, accessToken);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(ProductIndex));
            }
        }
        return View(product);
    }

    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> ProductDelete(int productId)
    {
        var accessToken = await HttpContext.GetTokenAsync("access_token");
        var response = await _productService.GetproductByIdAsync<ResponseDto>(productId, accessToken);
        if (response != null && response.IsSuccess)
        {
            var product = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
            return View(product);
        }
        return NotFound();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> ProductDelete(ProductDto product)
    {
        if (ModelState.IsValid)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _productService.DeleteProductAsync<ResponseDto>(product.Id, accessToken);
            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(ProductIndex));
            }
        }
        return View(product);
    }
}