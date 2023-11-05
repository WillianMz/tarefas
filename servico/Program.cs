using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tarefas;
using Tarefas.Data;
using Tarefas.Data.Repositorios;
using Tarefas.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//base de dados mySQL/mariadb
string connectionString = $"Server=localhost;";
connectionString += $"Port=3306;";
connectionString += $"Database=tarefas;";
connectionString += $"Uid=root;";
connectionString += $"Pwd=";

var serverVersion = new MySqlServerVersion(new Version(8, 2, 4));

builder.Services.AddDbContext<TarefaContext>(options => 
    options.UseMySql(connectionString, serverVersion)
    .LogTo(Console.WriteLine, LogLevel.Warning)
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors()
);

//dependencias
//interfaces genericas
builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//interfacao nao genericas
builder.Services.AddScoped<ICategoriaRepository, CategoriaRep>();
builder.Services.AddScoped<ITarefaRepository, TarefaRep>();


//automapper
var configMapper = new MapperConfiguration(conf => 
{
    conf.AddProfile(new TarefasMapper());
    conf.AllowNullCollections = true;
});

IMapper mapper = configMapper.CreateMapper();
builder.Services.AddSingleton(mapper);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
