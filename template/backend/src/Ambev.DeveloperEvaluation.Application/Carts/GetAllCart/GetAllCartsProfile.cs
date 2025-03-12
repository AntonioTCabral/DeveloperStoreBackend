using Ambev.DeveloperEvaluation.Application.Carts.GetCart;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.DTOs;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetAllCart
{
    /// <summary>
    /// Profile for mapping between Cart entity and GetAllCartsResult
    /// </summary>
    public class GetAllCartsProfile : Profile
    {
        public GetAllCartsProfile()
        {
            CreateMap<CartItem, CartItemDTO>();
            CreateMap<Cart, CartDTO>();
        }
    }
}
