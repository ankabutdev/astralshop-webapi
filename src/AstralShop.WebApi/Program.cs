using AstralShop.DataAccess.Contexts;
using AstralShop.WebApi.Extensions;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ->
builder.Services.AddDbContext<AstralShopDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

//builder.Configuration["Serilog:WriteTo:0:Args:path"] = AppSettingHelper.GetLogFilePath();

//var logger = new LoggerConfiguration()
//        .ReadFrom.Configuration(builder.Configuration)
//        .Enrich.FromLogContext()
//        .CreateLogger();

//builder.Logging.ClearProviders();
//builder.Logging.AddSerilog(logger);

builder.Services.AddCustomerService();
// ->

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();