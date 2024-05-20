using DataAccess.DAO;
using DataAccess.DAOImpl;
using DataAccess.DbContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICategory, CategoryImpl>();
builder.Services.AddTransient<ICongDung, CongDungImpl>();   
builder.Services.AddDbContext<StoreDbContext>(options => options.UseSqlServer
(builder.Configuration.GetConnectionString("DocSo")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();// nho them Middleware nay de su dung JWT
app.UseAuthorization();

app.MapControllers();

app.Run();
