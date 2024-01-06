using Microsoft.EntityFrameworkCore;
using MoneyTrackerAPI.Contexts;
using MoneyTrackerAPI.Interfaces;
using MoneyTrackerAPI.Interfaces.Repositries;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<MoneyTrackerContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddTransient<IBaseRepository, Repository>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
