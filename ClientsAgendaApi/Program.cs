using ClientsAgenda.Database;
using ClientsAgenda.Repositories;
using ClientsAgenda.Services;
using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();

builder.Services.AddSingleton<IDbConnectionFactory>(_ =>
    new SqliteConnectionFactory(connectionString: builder.Configuration.GetValue<string>("Database:ConnectionString")));
builder.Services.AddSingleton<DbInitializer>();

builder.Services.AddSingleton<IClientRepository, ClientRepository>();
builder.Services.AddSingleton<IClientService, ClientService>();

var app = builder.Build();

app.UseFastEndpoints();

app.UseOpenApi();
app.UseSwaggerUi3(s => s.ConfigureDefaults());

var databaseInitializer = app.Services.GetRequiredService<DbInitializer>();
await databaseInitializer.InitializeAsync();

app.Run();