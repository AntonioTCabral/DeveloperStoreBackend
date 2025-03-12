using Ambev.DeveloperEvaluation.Application.CartsItems.GetCartItem;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.CartsItems.DeleteCartItem;

/// <summary>
/// Command for deleting a cart item
/// </summary>
public record DeleteCartItemCommand(Guid Id) : IRequest;