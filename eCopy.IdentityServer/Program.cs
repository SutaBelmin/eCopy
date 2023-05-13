using eCopy.IdentityServer;
using eCopy.IdentityServer.Config;
using eCopy.Services;
using eCopy.Services.Database;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<eCopyContext>(
    x => x.UseSqlServer(builder.Configuration.GetConnectionString("eCopy")));

// Add identity configuration
builder.Services.AddIdentity<eCopy.Services.Database.IdentityUser, eCopy.Services.Database.IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;

    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail = false;
})
    .AddEntityFrameworkStores<eCopyContext>()
    .AddDefaultTokenProviders();


var settings = builder.Configuration.GetSection("Identity").Get<Settings>();

builder.Services.AddIdentityServer()
    .AddAspNetIdentity <eCopy.Services.Database.IdentityUser> ()
    .AddInMemoryIdentityResources(Config.GetIdentityResources())
    .AddInMemoryApiResources(Config.GetApis())
    .AddInMemoryClients(Config.GetClients())
    .AddDeveloperSigningCredential();

// Add authorization
builder.Services.AddAuthorization();

// Add authentication
builder.Services.AddAuthentication();
builder.Services.AddTransient<ITokenCreationService, TokenCreationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseIdentityServer();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
