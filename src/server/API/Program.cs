// --------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Modules.EmployeeManagement.Extensions;
using Modules.Identity.Extensions;
using Shared.Core.Extensions;
using Shared.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);
  
  var config = builder.Configuration;
builder.Services
                .AddDistributedMemoryCache()
                .AddSerialization(builder.Configuration)
                .AddSharedInfrastructure(builder.Configuration)
                .AddIdentityModule(builder.Configuration)
                .AddEmployeeManagementModule(builder.Configuration)
                .AddSharedApplication(builder.Configuration);

var app = builder.Build();

app.UseSharedInfrastructure();

app.Run();