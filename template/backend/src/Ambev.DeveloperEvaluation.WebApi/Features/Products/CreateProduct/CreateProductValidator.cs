using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

public class CreateProductValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("The title cannot be empty.")
            .MaximumLength(100).WithMessage("The title cannot be longer than 100 characters.");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("The description cannot be empty.")
            .MaximumLength(500).WithMessage("The description cannot be longer than 500 characters.");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("The price must be greater than 0.");

        RuleFor(x => x.Image)
            .NotEmpty()
            .WithMessage("The image cannot be empty.")
            .MaximumLength(250)
            .WithMessage("The image cannot be longer than 250 characters.");

        RuleFor(x => x.Category)
            .NotEmpty()
            .WithMessage("The category cannot be empty.")
            .MaximumLength(100)
            .WithMessage("The category cannot be longer than 100 characters.");

        RuleFor(x => x.RatingValueObject).NotNull();
    }
}