using Car.Data;
using Car.Models; // Car modelinizi kullanmak için
using Microsoft.AspNetCore.Identity; // IdentityUser için
using Microsoft.EntityFrameworkCore; // DbContext uzantıları için

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// ASP.NET Core Identity servislerini ekle
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<CarDbContext>();

// PostgreSQL için CarDbContext'i servis konteynerine ekle (Bu zaten olmalıydı)
builder.Services.AddDbContext<CarDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("CarConnection")));

// ... diğer servisler (örneğin builder.Services.AddControllersWithViews(); varsa)
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles(); // Bu sat�r genelde varsay�lan olarak gelir ve wwwroot klas�r�ndeki statik dosyalar� (CSS, JS) sunmak i�in gereklidir.

app.UseRouting();

app.UseAuthentication(); // Bu satırı ekleyin
app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute( // Eğer Controllers kullanıyorsanız bu satırı ekleyebilirsiniz.
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages(); // Bu tekrar yazılmamalı, tek bir tane yeterli.
                     // Identity scaffolded files'lar için MapRazorPages yeterlidir.

app.Run();