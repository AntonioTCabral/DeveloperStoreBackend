using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using AutoMapper;
using FluentAssertions;
using FluentValidation;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application;

/// <summary>
/// Conjunto de testes para a classe <see cref="CreateProductHandler"/>.
/// </summary>
public class CreateProductHandlerTests
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly CreateProductHandler _handler;

    public CreateProductHandlerTests()
    {
        _productRepository = Substitute.For<IProductRepository>();
        _mapper = Substitute.For<IMapper>();

        _handler = new CreateProductHandler(_productRepository, _mapper);
    }

    [Fact(DisplayName = "Dado command válido, quando criar produto, então retorna resultado de sucesso")]
    public async Task Handle_ValidCommand_ReturnsCreateProductResult()
    {
        // Arrange

        var command = new CreateProductCommand
        {
            Title = "Produto Valido",
            Description = "Desc",
            Price = 10m,
            Image = "http://nautical-crown.name",
            Category = "Tools",
            RatingValueObject = new RatingValueObject
            {
                Count = 5,
                Rate = 4.5m
            }
        };

        var product = new Product
        {
            Id = Guid.NewGuid(),
            Title = command.Title,
            Description = command.Description,
            Price = command.Price,
            Rating = command.RatingValueObject,
            Category = command.Category,
            Image = command.Image,
        };

        var result = new CreateProductResult
        {
            Id = product.Id
        };

        // Configura mocks:
        // 1) Quando o AutoMapper mapear o command para Product, retorna "product"
        _mapper.Map<Product>(command).Returns(product);
        // 2) Quando o repositório criar o produto, retorna "product"
        _productRepository.CreateAsync(product, Arg.Any<CancellationToken>()).Returns(product);
        // 3) Quando o AutoMapper mapear o Product criado para CreateProductResult, retorna "result"
        _mapper.Map<CreateProductResult>(product).Returns(result);

        // Act
        var createResult = await _handler.Handle(command, CancellationToken.None);

        // Assert
        createResult.Should().NotBeNull();
        createResult.Id.Should().Be(product.Id);

        // Verifica se o repositório foi chamado 1 vez com o Product correto
        await _productRepository.Received(1).CreateAsync(Arg.Is<Product>(p =>
            p.Title == command.Title &&
            p.Description == command.Description &&
            p.Price == command.Price
        ), Arg.Any<CancellationToken>());

        // Verifica se o mapper mapeou o command e o product
        _mapper.Received(1).Map<Product>(command);
        _mapper.Received(1).Map<CreateProductResult>(product);
    }

    [Fact(DisplayName = "Dado command inválido, quando criar produto, então lança ValidationException")]
    public async Task Handle_InvalidCommand_ThrowsValidationException()
    {
        // Arrange

        var command = new CreateProductCommand
        {
            Title = "",
            Description = "Desc",
            Price = -1,
            Image = "http://nautical-crown.name",
            Category = "Tools",
            RatingValueObject = new RatingValueObject
            {
                Count = 5,
                Rate = 4.5m
            }
        };

        // Act
        var act = () => _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<ValidationException>()
            .WithMessage("*Validation failed*"); // Ou outra verificação específica
    }

    [Fact(DisplayName = "Dado product válido, quando criar produto, então repositório é chamado uma vez")]
    public async Task Handle_ValidCommand_CallsRepositoryOnce()
    {
        // Arrange
        var command = new CreateProductCommand
        {
            Title = "Produto Valido",
            Description = "Desc",
            Price = 10m,
            Image = "http://nautical-crown.name",
            Category = "Tools",
            RatingValueObject = new RatingValueObject
            {
                Count = 5,
                Rate = 4.5m
            }
        };

        var product = new Product { Id = Guid.NewGuid() };
        var result = new CreateProductResult { Id = product.Id };

        _mapper.Map<Product>(command).Returns(product);
        _productRepository.CreateAsync(product, Arg.Any<CancellationToken>()).Returns(product);
        _mapper.Map<CreateProductResult>(product).Returns(result);

        // Act
        await _handler.Handle(command, CancellationToken.None);

        // Assert
        await _productRepository.Received(1).CreateAsync(product, Arg.Any<CancellationToken>());
    }
}