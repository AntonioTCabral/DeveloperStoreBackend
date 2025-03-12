using Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;
using Ambev.DeveloperEvaluation.Application.Sale.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sale.GetSale;
using Ambev.DeveloperEvaluation.Application.Sale.UpdateSale;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Sale.CreateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sale.GetSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sale.UpdateSale;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UpdateProductValidator = Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct.UpdateProductValidator;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale;

[ApiController]
[Route("api/[controller]")]
public class SalesController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ISaleRepository _saleRepository;

    public SalesController(IMediator mediator, IMapper mapper, ISaleRepository saleRepository)
    {
        _mediator = mediator;
        _mapper = mapper;
        _saleRepository = saleRepository;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateSale([FromBody] CreateSaleRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateSaleCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateSaleResponse>
        {
            Success = true,
            Message = "Sale created successfully",
            Data = _mapper.Map<CreateSaleResponse>(response)
        });
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetSaleResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetSale([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetSaleRequest { Id = id };
        var validator = new GetSaleRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetSaleCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<GetSaleResponse>
        {
            Success = true,
            Message = "Sale retrieved successfully",
            Data = _mapper.Map<GetSaleResponse>(response)
        });
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(PaginatedResponse<PaginatedList<Domain.Entities.Sale>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllSales(
        [FromQuery] int? page,
        [FromQuery] int? size,
        [FromQuery] string? order)
    {
        var sales = await _saleRepository.GetAllAsync(order);
        
        var result = await PaginatedList<Domain.Entities.Sale>.CreateAsync(sales, page ?? 1, size ?? 10);

        return OkPaginated(result);
    }
    
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateSale(Guid id, [FromBody] UpdateSaleRequest request, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<UpdateSaleCommand>(request);
        command.Id = id;
        
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<UpdateSaleResponse>
        {
            Success = true,
            Message = "Sale updated successfully",
            Data = _mapper.Map<UpdateSaleResponse>(response)
        });
    }
}