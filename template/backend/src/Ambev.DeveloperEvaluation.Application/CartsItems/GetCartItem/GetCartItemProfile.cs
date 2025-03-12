using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.CartsItems.GetCartItem;

/// <summary>
/// Profile for mapping between CartItem entity and GetCartItemResult
/// </summary>
public class GetCartItemProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetCartItem operation
    /// </summary>
    public GetCartItemProfile()
    {
        CreateMap<CartItem, GetCartItemResult>();
    }
}