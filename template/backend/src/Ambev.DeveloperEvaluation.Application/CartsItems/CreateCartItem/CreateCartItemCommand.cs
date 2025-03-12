using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.CartsItems.CreateCartItem;

/// <summary>
/// Command for adding an item to the cart.
/// </summary>
public class CreateCartItemCommand : IRequest<CreateCartItemResult>
{
    public Guid CartId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}