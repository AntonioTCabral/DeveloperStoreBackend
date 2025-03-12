using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.CartItems.GetCartItem;

/// <summary>
/// Validator for GetCartItemRequest.
/// </summary>
public class GetCartItemRequestValidator : AbstractValidator<GetCartItemRequest>
{
    /// <summary>
    /// Initializes validation rules for GetCartItemRequest.
    /// </summary>
    public GetCartItemRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Cart item ID is required.");
    }
}