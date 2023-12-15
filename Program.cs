using Microsoft.EntityFrameworkCore;
using Web_API.Data;
using Web_API.Services;
using Web_API.Services.Iservices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Adding SQL Connection
builder.Services.AddDbContext<Context>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerConnection")));
//Ends here
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Adding Imapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//Register Service for Dependency Injection

builder.Services.AddScoped<Iproducts, ProductServices>();
//builder.Services.AddScoped<ITicket, TicketService>();

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
