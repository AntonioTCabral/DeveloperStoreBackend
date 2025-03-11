using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sale.CreateSale;

public class CreateSaleCommand : IRequest<CreateSaleResult>
{
    public Guid CustomerId { get; set; }
    public Guid CartId { get; set; }
    public Guid BranchId { get; set; }
}