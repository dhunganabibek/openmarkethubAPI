using Microsoft.AspNetCore.Mvc;

namespace openmarkethubAPI.controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("all-products")]
    public async Task<IActionResult> GetAllProductsAsync(CancellationToken cancellationToken)
    {
        var allProducts = await _productService.GetAllProductsAsync(cancellationToken);
        return Ok(allProducts);
    }

    [HttpGet("product/{productId}")]
    public async Task<IActionResult> GetProductByIdAsync(Guid productId, CancellationToken cancellationToken)
    {
        var product = await _productService.GetProductByIdAsync(productId, cancellationToken);
        return Ok(product);
    }

    [HttpPost("save-or-edit-product")]
    public async Task<IActionResult> SaveOrEditProductAsync([FromBody] ProductDTO request, CancellationToken cancellationToken)
    {
        await _productService.SaveOrEditProductAsync(request, cancellationToken);
        return Ok();
    }
}
