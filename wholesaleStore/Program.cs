
using Microsoft.EntityFrameworkCore;
using TicketBookingPlatform.Storage;
using wholesaleStore.Core.Interfaces;
using wholesaleStore.Core.Services;
using wholesaleStore.Storage;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<wholesaleStoreDBContext>(options =>
    options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("Local")));

builder.Services.AddTransient<IAddressesService, AddressesService>();
builder.Services.AddTransient<IOrdersService, OrdersService>();
builder.Services.AddTransient<IGoodsService, GoodsService>();
builder.Services.AddTransient<IUsersService, UsersService>();
builder.Services.AddTransient<IFieldActivityService, FieldActivityService>();
builder.Services.AddTransient<IAdministratorService, AdministratorService>();
builder.Services.AddTransient<IEnterpriceService, EnterpriceService>();
builder.Services.AddTransient<ICartService, CartService>();
builder.Services.AddScoped<IRepository, Repository>();

// Додаємо підтримку сесій
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Таймаут сесії
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
