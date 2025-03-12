using Ambev.DeveloperEvaluation.Application.CartsItems.CreateCartItem;
using Ambev.DeveloperEvaluation.Application.CartsItems.GetCartItem;
using Ambev.DeveloperEvaluation.WebApi.Features.CartItems.CreateCartItem;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.CartItems.GetCartItem;

public class GetCartItemProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateCartItem feature.
    /// </summary>
    public GetCartItemProfile()
    {
        CreateMap<GetCartItemResult, GetCartItemResponse>().ReverseMap();
    }
}