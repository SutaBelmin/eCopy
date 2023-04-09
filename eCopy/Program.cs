using eCopy;
using eCopy.Model.Response;
using eCopy.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<eCopyContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("eCopy")));
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IEmployeeService, EmployeeServicee>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IPrintRequestService, PrintRequestService>();
builder.Services.AddScoped<IClientService, ClientService>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddSingleton(typeof(IPasswordHasher<>), typeof(PasswordHasher<>));
builder.Services.AddScoped<IErrorService, ErrorService>();
builder.Services.AddScoped<IReportService, ReportService>();




builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidateAudience = false,
            RequireExpirationTime = false,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidateIssuer = false,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]))
        };
    });
builder.Services.AddAuthorization();

//builder.Services.Configure<JwtBearerOptions>(options => 
//{
//    options.TokenValidationParameters.ValidAudience = builder.Configuration["Jwt:Audience"];
//    options.TokenValidationParameters.ValidIssuer = builder.Configuration["Jwt:Issuer"];
//    options.TokenValidationParameters.ValidateIssuer = true;
//    options.TokenValidationParameters.ValidateLifetime = true;
//    options.Audience = builder.Configuration["Jwt:Audience"];
//    options.ClaimsIssuer = builder.Configuration["Jwt:Issuer"];
//    options.TokenValidationParameters.ValidateIssuerSigningKey = true;
//    options.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]));
//});

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandlerMiddleware();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
