using CarRepairWorkshops.API.Middlewares;
using CarRepairWorkshops.Application.Extensions;
using CarRepairWorkshops.Infrastructure.Seeders;
using CarRepairWorkshops.Infrastructure.ServiceCollectionExtensions;
using CarRepairWorkshops.API.Extensions;
using Serilog;
using CarRepairWorkshops.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);



builder.AddPresentation();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();





var app = builder.Build();



//seeder
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<ICarRepairWorkshopsSeeder>();

await seeder.Seed();

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<RequestTimeLogginMiddleware>();

app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapIdentityApi<User>();

app.UseAuthorization();

app.MapControllers();

app.Run();


public partial class Program { }