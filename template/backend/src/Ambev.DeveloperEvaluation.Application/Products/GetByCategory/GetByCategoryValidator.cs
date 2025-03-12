using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.GetByCategory;

public class GetByCategoryValidator : AbstractValidator<GetByCategoryCommand>
{
    public GetByCategoryValidator()
    {
        RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
    }
}