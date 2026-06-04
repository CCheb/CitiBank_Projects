using BankAPI.Services;
using BankAPI.Repositories;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";

builder.WebHost.UseUrls($"http://*:{port}");

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

// Answering CORS policies
builder.Services.AddCors(options =>
{
    options.AddPolicy("BankFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173", "https://citi-bank-vert.vercel.app")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger middleware
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("BankFrontend");

app.MapControllers();

app.Run();
