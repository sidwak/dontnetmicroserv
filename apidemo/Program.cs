using apidemo.DBContexts;
using apidemo.Repository;
using Microsoft.EntityFrameworkCore; 

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddDbContext<ProductContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("ProductDB")));
builder.Services.AddTransient<IProductRepository, ProductRepository>(); 
builder.Services.AddTransient<IOrderRepository, OrderRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
