using IdentityServer4.Models;
using Users.Identity;
using Users.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddData(builder.Configuration);

builder.Services.AddIdentityServer()
    .AddInMemoryApiResources(Configuration.ApiResources)
    .AddInMemoryIdentityResources(Configuration.IdentityResources)
    .AddInMemoryApiScopes(Configuration.ApiScopes)
    .AddInMemoryClients(Configuration.Clients)
    .AddDeveloperSigningCredential();

builder.Services.ConfigureApplicationCookie(config => {
    config.Cookie.Name = "UserManagementSystemCocie";
    config.LoginPath = "/Auth/Login";
    config.LogoutPath = "/Auth/Logout";
});


var app = builder.Build();

app.UseIdentityServer();
app.MapGet("/", () => "Hello World!");

app.Run();
