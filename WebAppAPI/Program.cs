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
builder.Services.AddTransient<IUser, UserImpl>();   
//builder.Services.AddDbContext<StoreDbContext>(options => options.UseSqlServer
//(builder.Configuration.GetConnectionString("DocSo")));
builder.Services.AddDbContext<StoreDbContext>(options => options.UseSqlServer
(builder.Configuration.GetConnectionString("Store")));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:ValidIssuer"],
        ValidAudience = builder.Configuration["Jwt:ValidAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]))
    };
});


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
