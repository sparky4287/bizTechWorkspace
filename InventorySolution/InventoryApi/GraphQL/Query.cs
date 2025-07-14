using InventoryShared.Models;
using InventoryApi.Data;

namespace InventoryApi.GraphQL;

public class Query
{
    // Simple sample query
    public IQueryable<Customer> GetCustomers([Service] AppDbContext context) =>
        context.Customers;
}
