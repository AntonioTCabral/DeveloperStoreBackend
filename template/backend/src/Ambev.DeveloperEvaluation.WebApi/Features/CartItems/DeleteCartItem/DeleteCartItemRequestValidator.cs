using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.CartItems.DeleteCartItem;

/// <summary>
/// Validator for DeleteCartItemRequest
/// </summary>
public class DeleteCartItemRequestValidator : AbstractValidator<DeleteCartItemRequest>
{
    /// <summary>
    /// Initializes validation rules for DeleteCartItemRequest
    /// </summary>
    public DeleteCartItemRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("CartItem ID is required");
    }
}