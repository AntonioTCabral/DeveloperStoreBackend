using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.CartsItems.GetCartItem;

/// <summary>
/// Validator for GetCartItemCommand
/// </summary>
public class GetCartItemValidator : AbstractValidator<GetCartItemCommand>
{
    /// <summary>
    /// Initializes validation rules for GetCartItemCommand
    /// </summary>
    public GetCartItemValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Cart item ID is required");
    }
}