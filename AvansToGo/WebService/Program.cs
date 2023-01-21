
using Core.Domain.Services.IRepository;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using WebService.GraphQL;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<AvansToGoContext>(options => options.UseSqlServer(connectionString));

var userConnectionString = builder.Configuration.GetConnectionString("Security");
builder.Services.AddDbContext<IdentityContext>(options => options.UseSqlServer(userConnectionString));

builder.Services.AddScoped<IPackageRepo, PackageEFRepository>();
builder.Services.AddScoped<IStudentRepo, StudentEFRepository>();
builder.Services.AddScoped<IProductRepo, ProductEFRepository>();
builder.Services.AddScoped<IEmployeeRepo, EmployeeEFRepository>();
builder.Services.AddScoped<ICanteenRepo, CanteenEFRepository>();

builder.Services.AddScoped<Query>();
builder.Services.AddScoped<Mutation>();
builder.Services.AddGraphQL(c => SchemaBuilder.New().AddServices(c).AddType<GraphQLTypes>()
                                                            .AddQueryType<Query>()
                                                            .AddMutationType<Mutation>()
                                                            .Create());

//builder.Services.AddGraphQLServer()
//    .AddQueryType<Query>()
//    .AddMutationType<Mutation>()
//    .AddQueryType<GraphQLTypes>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedEmail = false)
    .AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();

builder.Services.AddAuthentication().AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,
    options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        };
    });
builder.Services.AddControllers();
builder.Services.AddMvc();
builder.Services.AddRazorPages();

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();

//app.UseGraphQL("/api");
app.UseRouting();

//    app.UseHttpsRedirection();
//    app.UseAuthentication();
//    app.UseAuthorization();



//}
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UsePlayground(new PlaygroundOptions
{
    QueryPath = "/api",
    Path = "/playground"
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/playground", async context =>
    {
        await context.Response.WriteAsync("Hello World!");
    });
    endpoints.MapGraphQL();
});
//app.MapGraphQL();
app.MapControllers();

app.Run();