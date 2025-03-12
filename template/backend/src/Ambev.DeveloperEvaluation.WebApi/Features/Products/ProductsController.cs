using Ambev.DeveloperEvaluation.Application.Carts.GetCart;
using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;
using Ambev.DeveloperEvaluation.Application.Products.GetCategories;
using Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetByCategory;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetCategories;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CreateProductValidator = Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct.CreateProductValidator;
using DeleteProductValidator = Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProduct.DeleteProductValidator;
using UpdateProductRequest = Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct.UpdateProductRequest;
using UpdateProductValidator = Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct.UpdateProductValidator;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public ProductsController(IMediator mediator, IMapper mapper, IProductRepository productRepository)
    {
        _mediator = mediator;
        _mapper = mapper;
        _productRepository = productRepository;
    }
    
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetProductResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProduct([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetProductRequest { Id = id };
        var validator = new GetProductRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetCartCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<GetProductResponse>
        {
            Success = true,
            Message = "Sale retrieved successfully",
            Data = _mapper.Map<GetProductResponse>(response)
        });
    }

    [HttpGet]
    [ProducesResponseType(typeof(PaginatedResponse<PaginatedList<Product>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllProducts(
        [FromQuery] int? page,
        [FromQuery] int? size,
        [FromQuery] string order )
    {

        var products = await _productRepository.GetAllAsync(order);
        
        var result = await PaginatedList<Product>.CreateAsync(products, page ?? 1, size ?? 10);

        return OkPaginated(result);
    }
    
    [HttpGet("category/{category}")]
    [ProducesResponseType(typeof(PaginatedResponse<PaginatedList<Product>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetByCategory(
        [FromRoute] string category,
        [FromQuery] int? page,
        [FromQuery] int? size,
        [FromQuery] string? order,
        CancellationToken cancellationToken)
    {

        var request = new GetProductsByCategoryRequest
        {
            Category = category,
            Order = order
        };

        var validator = new GetProductsByCategoryRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var products = await _productRepository.GetByCategoryAsync(category, order, cancellationToken);
        
        var result = await PaginatedList<Product>.CreateAsync(products, page ?? 1, size ?? 10);

        return OkPaginated(result);
    }
    
    [HttpGet("categories")]
    [ProducesResponseType(typeof(ApiResponseWithData<List<GetCategoriesResponse>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetCategories(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetCategoriesCommand(), cancellationToken);

        return Ok(new ApiResponseWithData<GetCategoriesResponse>
        {
            Success = true,
            Message = "Categories retrieved successfully",
            Data = _mapper.Map<GetCategoriesResponse>(response)
        });
    }
    

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateProductResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateProductValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateProductCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateProductResponse>
        {
            Success = true,
            Message = "Product created successfully",
            Data = _mapper.Map<CreateProductResponse>(response)
        });
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] UpdateProductRequest request, CancellationToken cancellationToken)
    {
        var validator = new UpdateProductValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<UpdateProductCommand>(request);
        command.Id = id;
        
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<UpdateProductResponse>
        {
            Success = true,
            Message = "Product updated successfully",
            Data = _mapper.Map<UpdateProductResponse>(response)
        });
    }
    
   
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        var validator = new DeleteProductValidator();
        var validationResult = await validator.ValidateAsync(new DeleteProductRequest{Id = id});
        
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);
        
        var command = _mapper.Map<DeleteProductCommand>(new DeleteProductRequest{Id = id});
        await _mediator.Send(command);
        
        return Ok(new ApiResponse
        {
            Success = true,
            Message = "Product deleted successfully"
        });
    }
    
}