using Microsoft.EntityFrameworkCore;
using MoneyTrackerAPI.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<MoneyTrackerContext>(opt =>
{
    // opt.UseNpgsql(builder.Configuration.GetConnectionString("PostgreConnection"));
    opt.UseSqlServer(builder.Configuration.GetConnectionString("MSSQLConnection"));
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
