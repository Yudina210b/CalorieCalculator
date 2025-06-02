using Microsoft.EntityFrameworkCore;
using Infrastructure.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// �������� ������������
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true);

// ����������� DbContext
builder.Services.AddDbContext<CalorieCalculatorDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// ���������� ������������
builder.Services.AddControllers();

var app = builder.Build();

// �������������� ���������� �������� � Development
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