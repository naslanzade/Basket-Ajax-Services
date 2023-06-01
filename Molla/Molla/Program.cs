using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Molla.Data;
using Molla.Services;
using Molla.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<ICustomerInterface, CustomerService>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<IBlogService,BlogService>();
builder.Services.AddScoped<IPopulaBlogService,PopularBlogService>();
builder.Services.AddScoped<ISliderService, SliderService>();
builder.Services.AddScoped<IOtherProductService, OtherProductService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IShopService, ShopService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
name: "areas",
pattern: "{area:exists}/{controller=DashBoard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
