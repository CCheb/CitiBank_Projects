using BankAPI.Services;
using BankAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddSingleton<CustomerRepository>();    // Singleton == shared containers per HTTP request
builder.Services.AddScoped<CustomerService>(); 
builder.Services.AddSingleton<AccountRepository>();
builder.Services.AddScoped<AccountService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger middleware
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
