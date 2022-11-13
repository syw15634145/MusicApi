using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RestApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Build connection string
SqlConnectionStringBuilder strbuilder = new SqlConnectionStringBuilder();
strbuilder.DataSource = "localhost";   // update me
strbuilder.UserID = "SA";              // update me
strbuilder.Password = "0626syw.";      // update me
strbuilder.InitialCatalog = "EFSampleDB";
strbuilder.TrustServerCertificate = true;
builder.Services.AddDbContext<ApiDbContext>(option => option.UseSqlServer(strbuilder.ConnectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApiDbContext>();
    // use context
    dbContext.Database.EnsureCreated();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

