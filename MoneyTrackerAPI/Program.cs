using Microsoft.EntityFrameworkCore;
using MoneyTrackerAPI.Context;
using Microsoft.AspNetCore.StaticFiles;
using System.Reflection;
using MoneyTrackerAPI.Services.AccountServices;
using MoneyTrackerAPI.Services.CategoryServices;
using MoneyTrackerAPI.Services.OperationServices;
using MoneyTrackerAPI.Services.CategoryTypeServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson()
.AddXmlDataContractSerializerFormatters();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

    options.IncludeXmlComments(xmlCommentsFullPath);
});

builder.Services.AddSingleton<FileExtensionContentTypeProvider>();

builder.Services.AddScoped<IAccountRepository, AccountService>();
builder.Services.AddScoped<ICategoryRepository, CategoryService>();
builder.Services.AddScoped<IOperationRepository, OperationService>();
builder.Services.AddScoped<ICategoryTypeRepository, CategoryTypeService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<MoneyTrackerContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("PostgreConnection"));
    //opt.UseSqlServer(builder.Configuration.GetConnectionString("MSSQLConnection"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
