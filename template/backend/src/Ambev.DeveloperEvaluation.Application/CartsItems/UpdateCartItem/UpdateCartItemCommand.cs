using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.CartsItems.UpdateCartItem;

/// <summary>
/// Command for updating a cart item.
/// </summary>
public class UpdateCartItemCommand : IRequest<UpdateCartItemResult>
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
}