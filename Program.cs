using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Synaptum.Core.Application.Interfaces;
using Synaptum.Core.Infrastructure.Data;
using Synaptum.Core.Infrastructure.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Services
builder.Services.AddScoped<IAuthService, AuthService>();
// JWT Auth
var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]);
builder.Services.AddAuthentication("JwtBearer").AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    //app.MapOpenApi();
//   app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseAuthentication();
//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
