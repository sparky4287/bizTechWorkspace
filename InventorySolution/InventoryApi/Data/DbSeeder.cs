using InventoryApi.Data;
using InventoryShared.Models;
using Microsoft.AspNetCore.Identity;

public class DbSeeder
{
    public static async Task SeedAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var roleMgr = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        context.Database.EnsureCreated();

        string[] roles = new[] { "Admin", "Manager", "Employee" };
        foreach (var role in roles)
            if (!await roleMgr.RoleExistsAsync(role))
                await roleMgr.CreateAsync(new IdentityRole(role));

        var admin = new ApplicationUser { UserName = "admin@company.com", Email = "admin@company.com" };
        if (await userMgr.FindByEmailAsync(admin.Email) == null)
        {
            await userMgr.CreateAsync(admin, "P@ssword123");
            await userMgr.AddToRoleAsync(admin, "Admin");
        }

        // Seed customers
        if (!context.Customers.Any())
        {
            context.Customers.AddRange(
                new Customer { Name = "Acme Corp", Address = "123 Main St, NY" },
                new Customer { Name = "Globex Inc.", Address = "456 Oak Ave, CA" });
        }

        // Seed products
        if (!context.InventoryItems.Any())
        {
            context.InventoryItems.AddRange(
                new InventoryItem { Name = "Widget A", Description = "Standard widget", QuantityInStock = 150, Price = 9.99M },
                new InventoryItem { Name = "Widget B", Description = "Deluxe widget", QuantityInStock = 75, Price = 14.99M },
                new InventoryItem { Name = "Gadget Pro", Description = "Advanced gadget", QuantityInStock = 30, Price = 29.95M },
                new InventoryItem { Name = "Gizmo X", Description = "Utility gizmo", QuantityInStock = 100, Price = 19.95M });
        }

        // Add one order with items
        if (!context.Orders.Any())
        {
            var customer = context.Customers.First();
            var product1 = context.InventoryItems.First();
            var product2 = context.InventoryItems.Skip(1).First();

            var order = new Order
            {
                Customer = customer,
                OrderDate = DateTime.UtcNow.AddDays(-7),
                OrderItems = new List<OrderItem>
                {
                    new OrderItem { Item = product1, Quantity = 10, UnitPrice = product1.Price },
                    new OrderItem { Item = product2, Quantity = 5, UnitPrice = product2.Price }
                }
            };

            context.Orders.Add(order);
        }

        await context.SaveChangesAsync();
    }
}
