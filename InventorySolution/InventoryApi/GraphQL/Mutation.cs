using InventoryShared.Models;
using InventoryApi.Data;

namespace InventoryApi.GraphQL;

public class Mutation
{
    public async Task<Customer> AddCustomer(
        string name,
        string? address,
        [Service] AppDbContext context)
    {
        var customer = new Customer
        {
            Name = name,
            Address = address
        };

        context.Customers.Add(customer);
        await context.SaveChangesAsync();
        return customer;
    }
}
