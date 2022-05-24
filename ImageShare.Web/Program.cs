using ImageShare.Core.Models;
using ImageShare.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Azure.Storage;
using Azure.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using ImageShare.Services;

namespace ImageShare.Web;
public static class Program
{

    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder();

        builder.Configuration
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables()
            .AddUserSecrets("aspnet-ImageShare.Web-F8F1D2FE-E04C-4A47-9CC3-2AFAACBB0835");

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddLogging();

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString)
                   .UseLazyLoadingProxies());

        if (builder.Environment.IsDevelopment())
        {
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
        }

        builder.Services.AddAuthentication(o =>
        {
            o.DefaultScheme = IdentityConstants.ApplicationScheme;
            o.DefaultSignInScheme = IdentityConstants.ExternalScheme;
        })
           .AddIdentityCookies(o => { });

        builder.Services.AddIdentityCore<AppUser>(options =>
        {
            options.Password.RequiredLength = 4;
            options.Password.RequireDigit = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
        })
       .AddUserStore<UserOnlyStore<AppUser, ApplicationDbContext, Guid>>()
       .AddUserManager<UserManager<AppUser>>()
       .AddSignInManager<SignInManager<AppUser>>();

        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                policy =>
                {
                    policy.AllowAnyOrigin();
                });
        });

        builder.Services.AddAzureClients(config =>
        {
            config.AddBlobServiceClient(builder.Configuration.GetConnectionString("AzureStorageConnection"));
            config.UseCredential(new DefaultAzureCredential());
        });

        builder.Services.AddControllersWithViews();
       // builder.Services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();
        builder.Services.AddScoped<ImageService>();
        builder.Services.AddScoped<LibraryService>();
        builder.Services.AddScoped<UserService>();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseCors();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapDefaultControllerRoute();

        app.Run();
    }
}