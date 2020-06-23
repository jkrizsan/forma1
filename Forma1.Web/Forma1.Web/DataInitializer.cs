using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forma1.Web
{
    public static class DataInitializer
    {
        public static void SeedUsers(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            var config = configuration.GetSection("UserData");

            if (userManager.FindByEmailAsync(config.GetSection("Email").Value).Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = config.GetSection("UserName").Value,
                    Email = config.GetSection("Email").Value
                };

                IdentityResult result = userManager.CreateAsync(user, config.GetSection("Passworld").Value).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }
    }
    }

