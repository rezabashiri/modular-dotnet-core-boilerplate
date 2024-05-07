// --------------------------------------------------------------------------------------------------
// <copyright file="ServiceCollectionExtensions.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using System;
using System.Net;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Modules.Identity.Core.Abstractions;
using Modules.Identity.Core.Entities;
using Modules.Identity.Core.Exceptions;
using Modules.Identity.Core.Settings;
using Modules.Identity.Infrastructure.Permissions;
using Modules.Identity.Infrastructure.Persistence;
using Modules.Identity.Infrastructure.Services;
using Shared.Core.Extensions;
using Shared.Core.Interfaces.Services;
using Shared.Core.Interfaces.Services.Identity;
using Shared.Infrastructure.Extensions;
using Shared.Infrastructure.Persistence;

namespace Modules.Identity.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddIdentityInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services
                .AddHttpContextAccessor()
                .AddScoped<ICurrentUser, CurrentUser>()
                .Configure<JwtSettings>(configuration.GetSection("JwtSettings"))
                .AddTransient<ITokenService, TokenService>()
                .AddTransient<IIdentityService, IdentityService>()
                .AddTransient<IUserService, UserService>()
                .AddTransient<IRoleService, RoleService>()
                .AddTransient<IRoleClaimService, RoleClaimService>()
                .AddDatabaseContext<IdentityDbContext>(configuration)
                .AddScoped<IIdentityDbContext>(provider => provider.GetService<IdentityDbContext>())
                .AddIdentity<BoilerplateUser, BoilerplateRole>(options =>
                {
                    options.Password.RequiredLength = 6;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders();
            services.AddExtendedAttributeDbContextsFromAssembly(typeof(IdentityDbContext), Assembly.GetAssembly(typeof(IIdentityDbContext)));
            services.AddTransient<IDatabaseSeeder, IdentityDbSeeder>();
            services.AddPermissions(configuration);
            services.AddJwtAuthentication(configuration);
            return services;
        }

        public static IServiceCollection AddPermissions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>()
                .AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
            return services;
        }

        internal static IServiceCollection AddJwtAuthentication(
            this IServiceCollection services, IConfiguration config)
        {
            var jwtSettings = services.GetOptions<JwtSettings>(nameof(JwtSettings), config);
            byte[] key = Encoding.ASCII.GetBytes(jwtSettings.Key);
            services
                .AddAuthentication(authentication =>
                {
                    authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(bearer =>
                {
                    bearer.RequireHttpsMetadata = false;
                    bearer.SaveToken = true;
                    bearer.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        RoleClaimType = ClaimTypes.Role,
                        ClockSkew = TimeSpan.Zero
                    };
                    bearer.Events = new JwtBearerEvents
                    {
                        OnChallenge = context =>
                        {
                            context.HandleResponse();
                            if (!context.Response.HasStarted)
                            {
                                throw new IdentityException("You are not Authorized.", statusCode: HttpStatusCode.Unauthorized);
                            }

                            return Task.CompletedTask;
                        },
                        OnForbidden = context =>
                        {
                            throw new IdentityException("You are not authorized to access this resource.", statusCode: HttpStatusCode.Forbidden);
                        },
                    };
                });
            return services;
        }
    }
}