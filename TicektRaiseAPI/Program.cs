using Microsoft.EntityFrameworkCore;
using TicektRaiseAPI.Interfaces;
using TicektRaiseAPI.Models;
using TicektRaiseAPI.Models.Context;
using TicektRaiseAPI.Services;

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
builder.Services.AddDbContext<TicketContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("UserCon"));
});
builder.Services.AddScoped<ITicket<Ticket,int>,TicketRepo>();
builder.Services.AddScoped<IService<Ticket, int>, TicketService>();
builder.Services.AddScoped<ISolution<Solution,int> ,SolutionRepo>();
builder.Services.AddScoped<ISolutionService<Solution,int>,SolutionService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AngularCORS");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
