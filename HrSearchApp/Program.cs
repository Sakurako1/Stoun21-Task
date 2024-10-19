using HrSearchApp.Data;
using HrSearchApp.Interfaces;
using HrSearchApp.Models;
using HrSearchApp.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



 // Add services to the container.
 builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IHrRepository, HrRepository>();
builder.Services.AddTransient<IVacancyRepository, VacancyRepository>();
builder.Services.AddDbContext<DataContext>();
using (var db = new DataContext())
{
    DataSeeder.SeedDatabase(db);
}
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5295); 
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("AllowAll");
app.MapControllers();

app.Run();
