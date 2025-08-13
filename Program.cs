using LeadMedixCRM.Data;
using LeadMedixCRM.Interfaces;
using LeadMedixCRM.Middlewares;
using LeadMedixCRM.Models;
using LeadMedixCRM.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("*") // ✅ Angular dev server
              .AllowAnyHeader()
              .AllowAnyMethod();
              //.AllowCredentials(); // Optional if you use cookies
    });
});

// Add services to the container.
// 1. Add DbContext (EF Core)
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Add custom services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<JwtHelper>();
builder.Services.AddScoped<IRoleService, RoleService>();
//For Leads
builder.Services.AddScoped<ILeadSourceService, LeadSourceService>();
builder.Services.AddScoped<ILeadStatusService, LeadStatusService>();
builder.Services.AddScoped<ILeadQualityService, LeadQualityService>();

// 3. Add JWT authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });
// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("Logs/app_log.txt", 
    rollingInterval: RollingInterval.Day, 
    retainedFileCountLimit: 30,
    outputTemplate: "{NewLine}==================== ERROR START ===================={NewLine}{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}{NewLine}==================== ERROR END ===================={NewLine}"
    )
    .WriteTo.Console()
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Host.UseSerilog();

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

app.UseCors("AllowFrontend");

app.UseAuthentication();

// Use Global Exception Middleware
app.UseMiddleware<GlobalExceptionMiddleware>();
// Your token validation middleware
app.UseMiddleware<TokenValidationMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();


