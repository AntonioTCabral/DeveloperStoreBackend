namespace Ambev.DeveloperEvaluation.Application.DTOs;

public class CartDTO
{
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public Guid UserId { get; set; }
    public List<CartItemDTO> Items { get; set; }
}