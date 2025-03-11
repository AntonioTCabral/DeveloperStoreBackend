using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;
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
    public async Task<IActionResult> CreateCart([FromBody] CreateCartRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateCartRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateCartCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateCartResponse>
        {
            Success = true,
            Message = "Product created successfully",
            Data = _mapper.Map<CreateCartResponse>(response)
        });
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