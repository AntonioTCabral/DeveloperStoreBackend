using Ambev.DeveloperEvaluation.Application.CartsItems.UpdateCartItem;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.CartItems.UpdateCartItem;

/// <summary>
/// Profile for mapping between Application and API UpdateCartItem responses.
/// </summary>
public class UpdateCartItemProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for UpdateCartItem feature.
    /// </summary>
    public UpdateCartItemProfile()
    {
        CreateMap<UpdateCartItemRequest, UpdateCartItemCommand>();
        CreateMap<UpdateCartItemResult, UpdateCartItemResponse>();

    }
}