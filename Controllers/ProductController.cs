using Microsoft.AspNetCore.Mvc;

namespace openmarkethubAPI.controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductController : ControllerBase
{

    [HttpGet()]
    public IActionResult GetProducts()
    {
        
        return Ok("hello from get products");
    }

    [HttpPost()]
    public IActionResult PostProduct()
    {
        
        return Ok("hello from from post products");
    }
}
