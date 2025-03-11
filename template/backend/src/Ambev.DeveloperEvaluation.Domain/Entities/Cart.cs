using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Cart : BaseEntity
{
    public DateTime Date { get; set; }
    public Guid UserId { get; set; }
    public List<Product> Products { get; set; }
}