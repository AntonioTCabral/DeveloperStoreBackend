using Ambev.DeveloperEvaluation.Application.DTOs;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllProduct;

public class GetAllProductsHandler : IRequestHandler<GetAllProductsCommand, GetAllProductResult>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetAllProductsHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<GetAllProductResult> Handle(GetAllProductsCommand request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllAsync(request.Order, cancellationToken);

        var result = new GetAllProductResult()
        {
            Data = _mapper.Map<List<ProductDTO>>(products)
        };

        return _mapper.Map<GetAllProductResult>(result);

    }
}