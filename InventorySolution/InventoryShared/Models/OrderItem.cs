namespace InventoryShared.Models;

public class OrderItem
{
    public int Id { get; set; }

    public int OrderId { get; set; }
    public Order? Order { get; set; }

    public int ItemId { get; set; }
    public InventoryItem? Item { get; set; }

    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}
