using Ambev.DeveloperEvaluation.WebApi.Common;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts;

[ApiController]
[Route("api/[controller]")]
public class CartsController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;


    public CartsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetCarts()
    {
        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCart()
    {
        return Ok();
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetCartById(Guid id)
    {
        return Ok();
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateCart()
    {
        return Ok();
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCart(Guid id)
    {
        return Ok();
    }
}