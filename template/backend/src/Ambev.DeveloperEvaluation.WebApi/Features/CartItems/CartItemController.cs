using Ambev.DeveloperEvaluation.Application.CartsItems.CreateCartItem;
using Ambev.DeveloperEvaluation.Application.CartsItems.DeleteCartItem;
using Ambev.DeveloperEvaluation.Application.CartsItems.GetCartItem;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.CartItems.CreateCartItem;
using Ambev.DeveloperEvaluation.WebApi.Features.CartItems.DeleteCartItem;
using Ambev.DeveloperEvaluation.WebApi.Features.CartItems.GetCartItem;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.CartItems;

/// <summary>
/// Controller for managing cart item operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class CartItemsController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ICartItemRepository _cartItemRepository;

    /// <summary>
    /// Initializes a new instance of CartItemsController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public CartItemsController(IMediator mediator, IMapper mapper, ICartItemRepository cartItemRepository)
    {
        _mediator = mediator;
        _mapper = mapper;
        _cartItemRepository = cartItemRepository;
    }

    /// <summary>
    /// Creates a new cart item
    /// </summary>
    /// <param name="request">The cart item creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created cart item details</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateCartItemResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateCartItem([FromBody] CreateCartItemRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateCartItemRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateCartItemCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateCartItemResponse>
        {
            Success = true,
            Message = "Cart item created successfully",
            Data = _mapper.Map<CreateCartItemResponse>(response)
        });
    }


    /// <summary>
    /// Retrieves a cart item by its ID
    /// </summary>
    /// <param name="id">The unique identifier of the cart item</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The cart item details if found</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetCartItemResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCartItem([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetCartItemRequest { Id = id };
        var validator = new GetCartItemRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetCartItemCommand>(request.Id);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<GetCartItemResponse>
        {
            Success = true,
            Message = "Cart item retrieved successfully",
            Data = _mapper.Map<GetCartItemResponse>(response)
        });
    }
        
    /// <summary>
    /// Retrieves all cart items
    /// </summary>
    /// <param name="request">The request containing optional filters</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A list of cart items</returns>
    [HttpGet]
    [ProducesResponseType(typeof(PaginatedResponse<PaginatedList<CartItem>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllCartItems(
        [FromQuery] string? order,
        [FromQuery] int? page,
        [FromQuery] int? size,
        CancellationToken cancellationToken
    )
    {

        var cartItems = await _cartItemRepository.GetAllAsync(order);
            
        var result = await PaginatedList<CartItem>.CreateAsync(cartItems, page ?? 1, size ?? 10);


        return OkPaginated(result);
    }

    /// <summary>
    /// Deletes a cart item by its ID
    /// </summary>
    /// <param name="id">The unique identifier of the cart item to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Success response if the cart item was deleted</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteCartItem([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new DeleteCartItemRequest { Id = id };
        var validator = new DeleteCartItemRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<DeleteCartItemCommand>(request.Id);
        await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponse
        {
            Success = true,
            Message = "Cart item deleted successfully"
        });
    }

       
}