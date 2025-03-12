using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;


namespace Ambev.DeveloperEvaluation.Application.CartsItems.CreateCartItem;

/// <summary>
/// Handler for processing AddCartItemCommand requests.
/// </summary>
public class CreateCartItemHandler : IRequestHandler<CreateCartItemCommand, CreateCartItemResult>
{
    private readonly ICartItemRepository _cartItemRepository;
    private readonly IMapper _mapper;

    public CreateCartItemHandler(ICartItemRepository cartItemRepository, IMapper mapper)
    {
        _cartItemRepository = cartItemRepository;
        _mapper = mapper;
    }

    public async Task<CreateCartItemResult> Handle(CreateCartItemCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateCartItemValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new FluentValidation.ValidationException(validationResult.Errors);

        var cartItem = new CartItem
        {
            CartId = command.CartId,
            ProductId = command.ProductId,
            Quantity = command.Quantity
        };

        var addedItem = await _cartItemRepository.CreateAsync(cartItem, cancellationToken);
        return _mapper.Map<CreateCartItemResult>(addedItem);
    }
}