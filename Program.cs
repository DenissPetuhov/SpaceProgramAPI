using Microsoft.EntityFrameworkCore;
using SpaceProgram.EFCore;
using SpaceProgram.Model;
using SpaceProgram.Model.Interfaces;
using SpaceProgram.Model.Repositories;
using SpaceProgram.Service.Implementations;
using SpaceProgram.Service.Intarface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EF_DataContext>(
    o=> o.UseNpgsql(builder.Configuration.GetConnectionString("Ef_postgres_Db"))
    );

builder.Services.AddScoped<ISpaceObjetcRepository, SpaceObjectRepository>();

builder.Services.AddScoped<IBaseRepository<SpaceSystemModel>, SpaceSystemRepository>();

builder.Services.AddScoped<ISpaceObjectService, SpaceObjectService>();

builder.Services.AddScoped<ISpaceService<SpaceSystemModel>, SpaceSystemService>();




builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
