using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.CartItems.DeleteCartItem;

/// <summary>
/// Profile for mapping DeleteCartItem feature requests to commands
/// </summary>
public class DeleteCartItemProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for DeleteCartItem feature
    /// </summary>
    public DeleteCartItemProfile()
    {
        CreateMap<Guid, Application.CartsItems.DeleteCartItem.DeleteCartItemCommand>()
            .ConstructUsing(id => new Application.CartsItems.DeleteCartItem.DeleteCartItemCommand(id));
    }
}