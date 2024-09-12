using CrudWithInterfaces.Data;
using CrudWithInterfaces.Interfaces;
using CrudWithInterfaces.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(ICustomerRepository),typeof(CustomerRepository));
builder.Services.AddScoped(typeof(IOrderRepository),typeof(OrderRepository));
//builder.Services.AddTransient(typeof(ICustomerRepository), typeof(CustomerRepository));
//builder.Services.AddSingleton(typeof(ICustomerRepository), typeof(CustomerRepository));


// AddScoped: AddScoped olarak kaydedilen hizmet http isteði boyunca ayný kalýr. 
// AddTransient: Bir hizmet her talep edildiðinde yeniden oluþturulur. Yani bir sýnýfa baðýmlýlýk enjekte edildiðinde yeni bir örnek oluþturur.
// AddSingleton: Bir kez oluþturulur. Uygulama çalýþtýðý sürece bir kez oluþturulan kullanýlýr. Uygulama kapanmadan bellekten silinmez.

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
