using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetProduct;

public class GetProductValidator : AbstractValidator<GetProductCommand>
{
    public GetProductValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Product ID is required");
    }
}