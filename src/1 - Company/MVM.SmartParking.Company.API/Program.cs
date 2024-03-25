using Microsoft.EntityFrameworkCore;
using MVM.SmartParking.Company.API.Data;
using MVM.SmartParking.Company.API.Data.Interfaces;
using MVM.SmartParking.Company.API.Services;
using MVM.SmartParking.Company.API.Services.Notifications;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(opt => 
    opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<DataContext>();
builder.Services.AddTransient<ICompanyService, CompanyService>();
builder.Services.AddTransient<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<INotify, Notify>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();