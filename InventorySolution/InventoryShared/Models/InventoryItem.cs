namespace InventoryShared.Models;

public class InventoryItem
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int QuantityInStock { get; set; }
    public decimal Price { get; set; }

    // Navigation
    public ICollection<OrderItem>? OrderItems { get; set; }
}
