using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;
using UniAPISystem.Interface;
using UniAPISystem.Models;


var builder = WebApplication.CreateBuilder(args);

var key = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32)); // Generates 256 bits
Console.WriteLine(key);


builder.Services.AddDbContext<UniverzitetContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Server=localhost;Database=UniverzitetDb;Trusted_Connection=True;MultipleActiveResultSets=true")));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    var jwtSettings = builder.Configuration.GetSection("JwtSettings");
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Secret"]))
    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDepartmantService,DepartmantService>();
builder.Services.AddScoped<IFinansijeService, FinansijeService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IProfesorService, ProfesorService>();
builder.Services.AddScoped<IPredmetService, PredmetService>();
builder.Services.AddScoped<IUlogaService, UlogaService>();
builder.Services.AddScoped<IKorisnikService, KorisnikService>();
builder.Services.AddAuthorization();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseAuthentication();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



