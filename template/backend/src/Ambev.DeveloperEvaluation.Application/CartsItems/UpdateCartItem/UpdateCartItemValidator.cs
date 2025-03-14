﻿using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.CartsItems.UpdateCartItem;

/// <summary>
/// Validator for UpdateCartItemCommand.
/// </summary>
public class UpdateCartItemValidator : AbstractValidator<UpdateCartItemCommand>
{
    public UpdateCartItemValidator()
    {
        RuleFor(item => item.Id).NotEmpty().WithMessage("Cart item ID is required.");
        RuleFor(item => item.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than zero.");
    }
}