using Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;
using Ambev.DeveloperEvaluation.Application.DTOs;
using Ambev.DeveloperEvaluation.Application.Sale.UpdateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.CartItems.UpdateCartItem;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.UpdateSale;

/// <summary>
/// Profile for mapping between Application and API UpdateCart responses.
/// </summary>
public class UpdateSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for UpdateCart feature.
    /// </summary>
    public UpdateSaleProfile()
    {
        CreateMap<UpdateSaleResult, UpdateSaleResponse>();
            
        CreateMap<UpdateSaleRequest, UpdateSaleCommand>();
    }
}