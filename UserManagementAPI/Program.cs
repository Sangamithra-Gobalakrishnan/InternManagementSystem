using Microsoft.EntityFrameworkCore;
using UserManagementAPI.Interfaces;
using UserManagementAPI.Models;
using UserManagementAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opts =>
{
    opts.AddPolicy("AngularCORS", options =>
    {
        options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});


//User defined Services
builder.Services.AddDbContext<UserContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("UserCon"));
});
builder.Services.AddScoped<IRepo<User, int>, UserRepo>();
builder.Services.AddScoped<IRepo<Intern, int>, InternRepo>();
builder.Services.AddScoped<IGeneratePassword, GeneratePasswordService>();
builder.Services.AddScoped<IGenerateToken, GenerateTokenService>();
builder.Services.AddScoped<IManageUser, ManageUserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AngularCORS");
app.UseAuthorization();

app.MapControllers();

app.Run();
