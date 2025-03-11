using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

public class UpdateCartValidator : AbstractValidator<UpdateCartCommand>
{
    public UpdateCartValidator()
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
            .MaximumLength(500);

        RuleFor(x => x.Category)
            .NotEmpty()
            .WithMessage("The category cannot be empty.")
            .MaximumLength(100);

        RuleFor(x => x.Rating).NotNull();
    }
}