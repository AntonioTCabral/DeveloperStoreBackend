using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sale.CreateSale;

public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ICartRepository _cartRepository;
    private readonly ISaleRepository _saleRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public CreateSaleHandler(ICartRepository cartRepository, IMapper mapper, ISaleRepository saleRepository, ICustomerRepository customerRepository, IProductRepository productRepository)
    {
        _cartRepository = cartRepository;
        _mapper = mapper;
        _saleRepository = saleRepository;
        _customerRepository = customerRepository;
        _productRepository = productRepository;
    }

    public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var cart = await _cartRepository.GetWithItemsAsync(command.CartId, cancellationToken);

        if (cart == null)
            throw new KeyNotFoundException($"Cart with ID {command.CartId} not found");
        
        int lastSaleNumber = await _saleRepository.GetLastSaleNumberAsync();

        var sale = new Domain.Entities.Sale
        {
            SaleNumber = lastSaleNumber + 1,
            BranchId = command.BranchId,
            CustomerId = command.CustomerId,
            SaleDate = DateTime.UtcNow,
            TotalAmount = 0m
        };
        

        foreach (var cartItem in cart.Items)
        {
            if (cartItem.Quantity > 20)
                throw new InvalidOperationException($"Cannot sell more than 20 units of the same product (Product ID: {cartItem.ProductId})");
            
            var product = await _productRepository.GetByIdAsync(cartItem.ProductId, cancellationToken);
            if (product == null)
                throw new KeyNotFoundException($"Product with ID {cartItem.ProductId} not found");

            var unitPrice = product.Price;

            decimal discount = cartItem.Quantity switch
            {
                >= 4 and < 10 => unitPrice * 0.10m,
                >= 10 and <= 20 => unitPrice * 0.20m,
                _ => 0m
            };

            var totalItemAmount = (unitPrice - discount) * cartItem.Quantity;

            var saleItem = new SaleItem
            {
                ProductId = cartItem.ProductId,
                Quantity = cartItem.Quantity,
                UnitPrice = unitPrice,
                Discount = discount,
                TotalItemAmount = totalItemAmount
            };

            sale.SaleItems.Add(saleItem);
            sale.TotalAmount += totalItemAmount;
           
        }
        
        sale = await _saleRepository.CreateAsync(sale, cancellationToken);

        var result = _mapper.Map<CreateSaleResult>(sale);

        return result;
    }
}