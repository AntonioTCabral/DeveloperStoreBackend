using Ambev.DeveloperEvaluation.WebApi.Common;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ProductsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        return Ok();
    }
    
    
    //POST /products

    [HttpPost]
    public async Task<IActionResult> CreateProduct()
    {
        return Ok();
    }
    
    
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetProductById(Guid id)
    {
        return Ok();
    }
    
    
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateProduct(Guid id)
    {
        return Ok();
    }
    
   
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        return Ok();
    }
   
    
    [HttpGet("categories")]
    public async Task<IActionResult> GetProductsCategories()
    {
        return Ok();
    }
    
    
    [HttpGet("category/{category}")]
    public async Task<IActionResult> GetProductsByCategory(string category)
    {
        return Ok();
    }
}