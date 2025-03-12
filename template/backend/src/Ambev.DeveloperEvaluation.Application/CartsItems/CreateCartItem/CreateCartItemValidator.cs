using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.CartsItems.CreateCartItem;

public class CreateCartItemValidator : AbstractValidator<CreateCartItemCommand>
{
    public CreateCartItemValidator()
    {
        RuleFor(item => item.CartId).NotEmpty().WithMessage("Cart ID is required");
        RuleFor(item => item.ProductId).NotEmpty().WithMessage("Product ID is required");
        RuleFor(item => item.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than zero");
    }
}