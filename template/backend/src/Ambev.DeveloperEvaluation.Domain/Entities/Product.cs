using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Product : BaseEntity
{
    
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Image { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    private string RatingJson { get; set; } = string.Empty;
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; private set; }

    [NotMapped]
    public Rating Rating
    {
        get => JsonSerializer.Deserialize<Rating>(RatingJson) ?? new Rating();
        
        set => RatingJson = JsonSerializer.Serialize(value);
    }
    
    
}