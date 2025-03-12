using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.CartsItems.GetCartItem;

/// <summary>
/// Command for retrieving a cart item by its ID
/// </summary>
public record GetCartItemCommand : IRequest<GetCartItemResult>
{
    /// <summary>
    /// The unique identifier of the cart item to retrieve
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of GetCartItemCommand
    /// </summary>
    /// <param name="id">The ID of the cart item to retrieve</param>
    public GetCartItemCommand(Guid id)
    {
        Id = id;
    }
}