﻿using Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;
using Ambev.DeveloperEvaluation.Application.DTOs;
using Ambev.DeveloperEvaluation.WebApi.Features.CartItems.UpdateCartItem;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;

/// <summary>
/// Profile for mapping between Application and API UpdateCart responses.
/// </summary>
public class UpdateCartProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for UpdateCart feature.
    /// </summary>
    public UpdateCartProfile()
    {

        CreateMap<UpdateCartItemRequest, CartItemDTO>();
        CreateMap<UpdateCartResult, UpdateCartResponse>();
        CreateMap<UpdateCartRequest, UpdateCartCommand>();
    }
}