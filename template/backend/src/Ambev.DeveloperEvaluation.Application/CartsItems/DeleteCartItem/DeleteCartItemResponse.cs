using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.CartsItems.DeleteCartItem;

/// <summary>
/// Response model for DeleteCartItem operation
/// </summary>
public class DeleteCartItemResponse
{
    /// <summary>
    /// Indicates whether the deletion was successful
    /// </summary>
    public bool Success { get; set; }
}