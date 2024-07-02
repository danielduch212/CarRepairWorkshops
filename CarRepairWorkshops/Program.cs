

using CarRepairWorkshops.API.Middlewares;
using CarRepairWorkshops.Application.Extensions;
using CarRepairWorkshops.Infrastructure.Seeders;
using CarRepairWorkshops.Infrastructure.ServiceCollectionExtensions;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddScoped<ErrorHandlingMiddleware>();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();



//seeder
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<ICarRepairWorkshopsSeeder>();

await seeder.Seed();

app.UseMiddleware<ErrorHandlingMiddleware>();   


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
