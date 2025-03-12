using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CartsItems.GetCartItem;

/// <summary>
/// Handler for processing GetCartItemCommand requests
/// </summary>
public class GetCartItemHandler : IRequestHandler<GetCartItemCommand, GetCartItemResult>
{
    private readonly ICartItemRepository _cartItemRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetCartItemHandler
    /// </summary>
    /// <param name="cartItemRepository">The cart item repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public GetCartItemHandler(
        ICartItemRepository cartItemRepository,
        IMapper mapper)
    {
        _cartItemRepository = cartItemRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetCartItemCommand request
    /// </summary>
    /// <param name="request">The GetCartItem command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The cart item details if found</returns>
    public async Task<GetCartItemResult> Handle(GetCartItemCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetCartItemValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new FluentValidation.ValidationException(validationResult.Errors);

        var cartItem = await _cartItemRepository.GetByIdAsync(request.Id, cancellationToken);
        if (cartItem == null)
            throw new KeyNotFoundException($"Cart item with ID {request.Id} not found");

        return _mapper.Map<GetCartItemResult>(cartItem);
    }
}