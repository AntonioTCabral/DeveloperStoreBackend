using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;
using Ambev.DeveloperEvaluation.Application.DTOs;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart;

/// <summary>
/// Profile for mapping between Cart entity and GetCartResponse
/// </summary>
public class GetCartProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetCart operation
    /// </summary>
    public GetCartProfile()
    {
        CreateMap<CartItem, CartItemDTO>();
        CreateMap<Cart, GetCartResult>();
    }
}