
using Core.Domain.Services.IRepository;
using Infrastructure.Repository;

using Microsoft.EntityFrameworkCore;
using Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
//builder.Services.AddSwaggerGen(char=>
//{
    
//})

var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<AvansToGoContext>(options => options.UseSqlServer(connectionString));

var userConnectionString = builder.Configuration.GetConnectionString("Security");
builder.Services.AddDbContext<IdentityContext>(options => options.UseSqlServer(userConnectionString));

builder.Services.AddScoped<IPackageRepo, PackageEFRepository>();
builder.Services.AddScoped<IStudentRepo, StudentEFRepository>();
builder.Services.AddScoped<IProductRepo, ProductEFRepository>();
builder.Services.AddScoped<IEmployeeRepo, EmployeeEFRepository>();
builder.Services.AddScoped<ICanteenRepo, CanteenEFRepository>();


builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedEmail = false)
    .AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();

//builder.Services.AddAuthentication().AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,
//    options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidateAudience = false,
//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true,
//            ValidIssuer = builder.Configuration["Jwt:Issuer"],
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
//            ClockSkew = TimeSpan.Zero
//        };
//        options.TokenValidationParameters.IssuerSigningKey =
//            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]));
//    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddGraphQLServer()
//     .AddAuthorization()
//    .AddQueryType<Query>()
//    .AddMutationType<Mutation>()
//    .AddProjections()
//    .AddFiltering().AddSorting();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// app.UseAuthentication();
app.UseAuthorization();

//app.MapGraphQL();
app.MapControllers();

app.Run();