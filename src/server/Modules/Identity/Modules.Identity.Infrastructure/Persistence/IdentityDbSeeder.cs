// --------------------------------------------------------------------------------------------------
// <copyright file="IdentityDbSeeder.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Modules.Identity.Core.Abstractions;
using Modules.Identity.Core.Constants;
using Modules.Identity.Core.Entities;
using Modules.Identity.Core.Helpers;
using Shared.Core.Constants;
using Shared.Core.Interfaces.Services;
using Shared.Infrastructure.Utilities;

namespace Modules.Identity.Infrastructure.Persistence
{
    internal class IdentityDbSeeder : IDatabaseSeeder
    {
        private readonly ILogger<IdentityDbSeeder> _logger;
        private readonly IIdentityDbContext _db;
        private readonly UserManager<BoilerplateUser> _userManager;
        private readonly IStringLocalizer<IdentityDbSeeder> _localizer;
        private readonly RoleManager<BoilerplateRole> _roleManager;

        public IdentityDbSeeder(
            ILogger<IdentityDbSeeder> logger,
            IIdentityDbContext db,
            RoleManager<BoilerplateRole> roleManager,
            UserManager<BoilerplateUser> userManager,
            IStringLocalizer<IdentityDbSeeder> localizer)
        {
            _logger = logger;
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
            _localizer = localizer;
        }

        public void Initialize()
        {
            AddSuperAdmin();
            _db.SaveChanges();
        }

        private void AddSuperAdmin()
        {
            Task.Run(async () =>
            {
                // Check if Role Exists
                var superAdminRole = new BoilerplateRole(RoleConstants.SuperAdmin);
                var superAdminRoleInDb = await _roleManager.FindByNameAsync(RoleConstants.SuperAdmin);
                if (superAdminRoleInDb == null)
                {
                    await _roleManager.CreateAsync(superAdminRole);
                    superAdminRoleInDb = await _roleManager.FindByNameAsync(RoleConstants.SuperAdmin);
                }

                // Check if User Exists
                var superUser = new BoilerplateUser
                {
                    FirstName = "net",
                    LastName = "boilerplate",
                    Email = "superadmin@test.com",
                    UserName = "superadmin",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    IsActive = true
                };
                var superUserInDb = await _userManager.FindByEmailAsync(superUser.Email);
                if (superUserInDb == null)
                {
                    await _userManager.CreateAsync(superUser, UserConstants.DefaultPassword);
                    var result = await _userManager.AddToRoleAsync(superUser, RoleConstants.SuperAdmin);
                    if (result.Succeeded)
                    {
                        _logger.LogInformation(_localizer["Seeded Default SuperAdmin User."]);
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            _logger.LogError(error.Description);
                        }
                    }
                }

                foreach (string permission in typeof(global::Shared.Core.Constants.Permissions).GetNestedClassesStaticStringValues())
                {
                    await _roleManager.AddPermissionClaimAsync(superAdminRoleInDb, permission);
                }
            }).GetAwaiter().GetResult();
        }

    }
}