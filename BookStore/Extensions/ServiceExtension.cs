using BookStore.Core.Contracts;
using BookStore.Core.Contracts.Admin;
using BookStore.Core.Services;
using BookStore.Core.Services.Admin;
using BookStore.Infrastructure.Common;
using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extension.DependencyInjection
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISellerService, SellerService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IOrderService, OrderService>();
            return services;
        }
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddScoped<IRepository, Repository>();
            services.AddDatabaseDeveloperPageExceptionFilter();
            return services;
        }
        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
        {
            services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = config.GetValue<bool>("Identity:RequireConfirmedAccount");
                options.SignIn.RequireConfirmedEmail = config.GetValue<bool>("Identity:RequireConfirmedEmail");
                options.SignIn.RequireConfirmedPhoneNumber = config.GetValue<bool>("Identity:RequireConfirmedPhoneNumber");
                options.Password.RequiredLength = config.GetValue<int>("Identity:RequiredLength");
                options.Password.RequireNonAlphanumeric = config.GetValue<bool>("Identity:RequireNonAlphanumeric");
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddAuthentication()
                .AddCookie(options =>
                {
                    options.LoginPath = PathString.FromUriComponent("/Identity/Account/Login");
                    options.LogoutPath = PathString.FromUriComponent("/Identity/Account/Logout");

                });

            return services;
        }
    }
}
