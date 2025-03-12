using Ambev.DeveloperEvaluation.Application.CartsItems.GetCartItem;
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