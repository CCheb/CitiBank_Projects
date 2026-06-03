using BankAPI.Services;
using BankAPI.Repositories;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// MongoDB
var username = builder.Configuration["CITI_MONGO_USERNAME"];
var password = builder.Configuration["CITI_MONGO_PASSWORD"];
var mongoConnection = $"mongodb+srv://{username}:{password}@cluster0.ukvh5al.mongodb.net/?appName=Cluster0";

// Services via DI Container
builder.Services.AddScoped<CustomerRepository>();    // Singleton == shared containers per HTTP request
builder.Services.AddScoped<CustomerService>(); 
builder.Services.AddScoped<AccountRepository>();
builder.Services.AddScoped<AccountService>();
builder.Services.AddSingleton<IMongoClient>(new MongoClient(mongoConnection));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger middleware
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
