using InventoryApi.Data;
using InventoryShared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using InventoryApi.GraphQL;

var builder = WebApplication.CreateBuilder(args);

// Configure PostgreSQL connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Setup Identity with default UI and EF Core store
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<AppDbContext>();

// Add controllers (for REST API)
builder.Services.AddControllers();

// Add GraphQL if needed (optional now)
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()  // Define in your GraphQL folder
    .AddMutationType<Mutation>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapGraphQL(); // Optional: GraphQL endpoint

await DbSeeder.SeedAsync(app.Services);

app.Run();
