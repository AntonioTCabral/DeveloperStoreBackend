using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.CartsItems.DeleteCartItem;

/// <summary>
/// Validator for DeleteCartItemCommand
/// </summary>
public class DeleteCartItemValidator : AbstractValidator<DeleteCartItemCommand>
{
    /// <summary>
    /// Initializes validation rules for DeleteCartItemCommand
    /// </summary>
    public DeleteCartItemValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Cart item ID is required");
    }
}