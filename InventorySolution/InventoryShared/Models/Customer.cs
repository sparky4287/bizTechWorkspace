namespace InventoryShared.Models;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Address { get; set; }

    // Navigation
    public ICollection<Order>? Orders { get; set; }
}
