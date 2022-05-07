using Aetly.Controllers;
using Aetly.Data;
using Aetly.MOD;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.

 

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
 

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins, builder =>
    {
        builder.AllowAnyMethod()
                     .SetIsOriginAllowed(_ => true)
                     .AllowAnyHeader()
                     .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors(MyAllowSpecificOrigins);//∆Ù”√øÁ”ÚŒ Ã‚

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
Tkvaluetxt.all();
DataList.homeqqloadtk(builder.Configuration);
DataList.homecsloadtk(builder.Configuration);
DataList.homemkloadtk(builder.Configuration);
DataList.homeloadgm(builder.Configuration);
DataList.errorloadtk(builder.Configuration);
app.Run();
