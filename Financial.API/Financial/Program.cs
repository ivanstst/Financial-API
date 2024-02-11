using Financial.Data;
using Financial.Services;
using Financial.Services.Interfaces;
using Financial.Web.Filters;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IAuthorizationHandler, AccessAuthorizationHandler>();
builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();
builder.Services.AddHttpClient<IBinanceService>();
builder.Services.AddTransient<IBinanceService, BinanceService>();
builder.Services.AddTransient<IDatabaseInitializer, DatabaseInitializer>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ISymbolService, SymbolService>();
builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddDbContext<FinancialDbContext>();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Access", policy =>
        policy.Requirements.Add(new Access()));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

using (var serviceScope = app.Services.CreateScope())
{
    var dbInitializer = serviceScope.ServiceProvider.GetService<IDatabaseInitializer>();
    await dbInitializer.Initialize();
}

app.Run();



