using Microsoft.EntityFrameworkCore;
using wt_lab5_5razor_antonov.Data; // Твой проект и папка Data

var builder = WebApplication.CreateBuilder(args);

// 1. Получаем строку подключения
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. Регистрируем AppDbContext с PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

// 3. Добавляем Razor Pages
builder.Services.AddRazorPages();

var app = builder.Build();

// 4. Автоматическое применение миграций при запуске
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

// 5. Настройка конвейера
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

// 6. Настройка порта (для Docker / Render)
var port = Environment.GetEnvironmentVariable("PORT") ?? "10000";
app.Run($"http://0.0.0.0:{port}");