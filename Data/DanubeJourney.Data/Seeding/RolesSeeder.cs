﻿namespace DanubeJourney.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using DanubeJourney.Common;
    using DanubeJourney.Data.Models;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    internal class RolesSeeder : ISeeder
    {
        public async Task SeedAsync(DanubeJourneyDbContext dbContext, IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<DanubeJourneyRole>>();

            await SeedRoleAsync(roleManager, GlobalConstants.AdministratorRoleName);

            await SeedRoleAsync(roleManager, GlobalConstants.UserRoleName);

            await SeedRoleAsync(roleManager, GlobalConstants.HumanResourcesRoleName);

            await SeedRoleAsync(roleManager, GlobalConstants.AccountantRoleName);
        }

        private static async Task SeedRoleAsync(RoleManager<DanubeJourneyRole> roleManager, string roleName)
        {
            var role = await roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                var result = await roleManager.CreateAsync(new DanubeJourneyRole(roleName));
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
