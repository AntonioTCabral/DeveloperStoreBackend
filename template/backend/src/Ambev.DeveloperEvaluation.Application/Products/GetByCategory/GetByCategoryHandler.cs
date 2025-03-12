using Ambev.DeveloperEvaluation.Application.Products.GetAllProduct;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using Ambev.DeveloperEvaluation.Application.DTOs;

namespace Ambev.DeveloperEvaluation.Application.Products.GetByCategory;

public class GetByCategoryHandler : IRequestHandler<GetByCategoryCommand, GetAllProductResult>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetByCategoryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<GetAllProductResult> Handle(GetByCategoryCommand request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetByCategoryAsync(request.Category, request.Order, cancellationToken);

        return new GetAllProductResult
        {
            Data = _mapper.Map<List<ProductDTO>>(products)
        };
    }
}