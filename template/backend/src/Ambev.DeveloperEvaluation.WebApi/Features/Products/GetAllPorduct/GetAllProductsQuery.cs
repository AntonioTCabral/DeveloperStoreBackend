using MediatR;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetAllPorduct;

/// <summary>
/// Query for retrieving all products.
/// </summary>
public class GetAllProductsQuery : IRequest<List<GetAllProductsResponse>>
{
    public int Page { get; set; }
    public int Size { get; set; }
    public string Order { get; set; }

    public GetAllProductsQuery(int page, int size, string order)
    {
        Page = page;
        Size = size;
        Order = order;
    }
}