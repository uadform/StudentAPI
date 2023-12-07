using DbUp;
using Npgsql;
using Serilog;
using StudentAPI.Interfaces;
using StudentAPI.Repositories;
using StudentAPI.Services;
using System.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IStudentService, StudentService>();
builder.Services.AddTransient<IStudentRepository, StudentRepository>();


builder.Services.AddTransient<ILectureService, LectureService>();
builder.Services.AddTransient<ILectureRepository, LectureRepository>();

builder.Services.AddTransient<IDepartmentService, DepartmentService>();
builder.Services.AddTransient<IDepartmentRepository, DepartmentRepository>();

builder.Services.AddTransient<IDepartmentLectureService, DepartmentLectureService>();
builder.Services.AddTransient<IDepartmentLectureRepository, DepartmentLectureRepository>();

string dbConnectionString = builder.Configuration.GetConnectionString("PostgreConnection");

builder.Services.AddTransient<IDbConnection>(sp => new NpgsqlConnection(dbConnectionString));
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

var upgrader =
        DeployChanges.To
            .PostgresqlDatabase(dbConnectionString)
            .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
            .LogToNowhere()
            .Build();

var result = upgrader.PerformUpgrade();

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
