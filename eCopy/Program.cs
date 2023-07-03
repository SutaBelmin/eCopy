using eCopy;
using eCopy.Services;
using eCopy.Services.Database.Seed;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});


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

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetService<eCopyContext>();
    context.Database.EnsureCreated();
    CountriesSeed.Seed(context);
    CitiesSeed.Seed(context);
    AspNetRolesSeed.Seed(context);
    AspNetUsersSeed.Seed(context);
    AspNetUserRolesSeed.Seed(context);
    CompanySeed.Seed(context);
    CopiersSeed.Seed(context);
    PersonsSeed.Seed(context);
    ClientsSeed.Seed(context);
    EmployeesSeed.Seed(context);
    AdministratorsSeed.Seed(context);
    RequestsSeed.Seed(context);
}


app.UseSwagger();
app.UseSwaggerUI();

app.UseExceptionHandlerMiddleware();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
