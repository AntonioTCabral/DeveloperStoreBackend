using Ambev.DeveloperEvaluation.Application.DTOs;
using Ambev.DeveloperEvaluation.Domain.Entities;


namespace Ambev.DeveloperEvaluation.Application.Carts.GetAllCart
{
    /// <summary>
    /// Response model for GetAllCarts operation
    /// </summary>
    public class GetAllCartsResult
    {
        public List<CartDTO> Carts { get; set; }
    }
}
