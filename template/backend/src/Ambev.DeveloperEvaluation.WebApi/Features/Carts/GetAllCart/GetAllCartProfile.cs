using Ambev.DeveloperEvaluation.Application.Carts.GetAllCart;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetAllCart
{
    /// <summary>
    /// Profile for mapping GetAllCarts feature requests to commands
    /// </summary>
    public class GetAllCartsProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for GetAllCarts feature
        /// </summary>
        public GetAllCartsProfile()
        {
            CreateMap<GetAllCartsRequest, GetAllCartsCommand>();
        }
    }
}
