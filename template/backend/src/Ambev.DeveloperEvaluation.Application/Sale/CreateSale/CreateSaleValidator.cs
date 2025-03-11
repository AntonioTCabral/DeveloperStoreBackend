using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sale.CreateSale;

public class CreateSaleValidator : AbstractValidator<CreateSaleCommand>
{
   public CreateSaleValidator()
   {
       RuleFor(x => x.CustomerId).NotEmpty().WithMessage("The customer id cannot be empty.");
       RuleFor(x => x.CartId).NotEmpty().WithMessage("The cart id cannot be empty.");
   }
}