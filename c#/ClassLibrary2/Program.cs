using Microsoft.EntityFrameworkCore;
using CalorieCalculator.Infrastructure.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Загрузка конфигурации
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true);

// Регистрация DbContext
builder.Services.AddDbContext<CalorieCalculatorDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Добавление контроллеров
builder.Services.AddControllers();

var app = builder.Build();

// Автоматическое применение миграций в Development
if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<CalorieCalculatorDbContext>();
    dbContext.Database.Migrate();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();