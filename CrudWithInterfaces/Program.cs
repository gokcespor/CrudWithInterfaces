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


// AddScoped: AddScoped olarak kaydedilen hizmet http iste�i boyunca ayn� kal�r. 
// AddTransient: Bir hizmet her talep edildi�inde yeniden olu�turulur. Yani bir s�n�fa ba��ml�l�k enjekte edildi�inde yeni bir �rnek olu�turur.
// AddSingleton: Bir kez olu�turulur. Uygulama �al��t��� s�rece bir kez olu�turulan kullan�l�r. Uygulama kapanmadan bellekten silinmez.

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
