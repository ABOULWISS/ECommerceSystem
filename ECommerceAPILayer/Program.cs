

using ECommerceUseCaseLair;
using ECommerceInfraStructureLair;
using ECommerceAPILayer;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;



var builder = WebApplication.CreateBuilder(args);

const string CorsPolicyName = "UseCors";




builder.Services.AddECommerceInfrastructure(builder.Configuration);

builder.Services.AddECommerceUseCase();






   builder.Services
       .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
       .AddJwtBearer(options =>
       {
           var jwt = builder.Configuration.GetSection("Jwt");
           options.TokenValidationParameters = new TokenValidationParameters
           {
               ValidateIssuer = true,
               ValidIssuer = jwt["Issuer"],
               ValidateAudience = true,
               ValidAudience = jwt["Audience"],
               ValidateIssuerSigningKey = true,
               IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Key"]!)),
               ValidateLifetime = true,
               ClockSkew = TimeSpan.FromMinutes(1),
               NameClaimType = ClaimTypes.NameIdentifier,
               RoleClaimType = ClaimTypes.Role
           };
       });




builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UserManage",       p => p.RequireClaim("permission", "Users.Manage"));
    options.AddPolicy("RoleManage",       p => p.RequireClaim("permission", "Roles.Manage"));
    options.AddPolicy("PermissionManage", p => p.RequireClaim("permission", "Permissions.Manage"));

    options.AddPolicy("Orders.Refund",    p => p.RequireClaim("permission", "Orders.Refund"));
    options.AddPolicy("Products.Create",  p => p.RequireClaim("permission", "Products.Create"));
    options.AddPolicy("Categories.Delete",p => p.RequireClaim("permission", "Categories.Delete"));
});



builder.Services.AddExceptionHandler<ApiExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddScoped<IRoleUseCaseFacade, RoleUseCaseFacade>();




// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(CorsPolicyName, policy =>
    {
        policy.WithOrigins("https://your-frontend-domain.com")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});









builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();





var app = builder.Build();





// Apply DB creation/migration
app.Services.EnsureECommerceDatabaseCreated();




app.UseExceptionHandler();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseCors(CorsPolicyName);

// Add this if/when you introduce any authentication scheme
// (JWT, cookies, Identity, etc.). UseAuthorization() alone does
// nothing useful without UseAuthentication() populating HttpContext.User first.





app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();