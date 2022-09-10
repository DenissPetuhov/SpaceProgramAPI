using Microsoft.EntityFrameworkCore;
using SpaceProgram.EFCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EF_DataContext>(
    o=> o.UseNpgsql(builder.Configuration.GetConnectionString("Ef_postgres_Db"))
    );


builder.Services.AddControllers();
builder.Services.AddCors(options => options.AddPolicy(name: "SpaceSystemOrigin",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    }));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("SpaceSystemOrigin");
app.UseAuthorization();

app.MapControllers();

app.Run();
