// EKLENDİ: AppDbContext (Data klasörü) ve Entity Framework Core'u kullanabilmek için
using KitchenDiary.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// EKLENDİ: Veritabanı bağlantısı. AppDbContext'i uygulamaya kaydeder, controller'lar
// ihtiyaç duyduğunda hazır alabilir. Bağlantı adresi appsettings.json içindeki
// "ConnectionStrings" bölümünün "DefaultConnection" satırından okunur.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Uygulama açılırken veritabanı boşsa başlangıç verilerini ekle
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    DbSeeder.Seed(db);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();