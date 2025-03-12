using Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;
using Ambev.DeveloperEvaluation.Application.DTOs;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;


namespace Ambev.DeveloperEvaluation.Application.CartsItems.UpdateCartItem;

/// <summary>
/// Profile for mapping between CartItem entity and UpdateCartItemResponse.
/// </summary>
public class UpdateCartItemProfile : Profile
{
    public UpdateCartItemProfile()
    {
        CreateMap<UpdateCartItemCommand, CartItem>();
        CreateMap<CartItem, UpdateCartItemResult>();
        CreateMap<CartItem, CartItemDTO>();
    }
}