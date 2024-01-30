using AdamsHospitalAPI.Data;
using AdamsHospitalAPI.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AdamsDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("APIConnection")));

builder.Services.AddIdentityCore<IdentityUser>().AddEntityFrameworkStores<AdamsDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication();

builder.Services.AddTransient<IAuthService, AuthService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
