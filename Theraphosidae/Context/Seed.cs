using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theraphosidae.Areas.Dashboard.Models.Db.Account;

namespace Theraphosidae.Context
{
    public class Seed
    {
        public static async Task SeedData(TheraphosidaeContext context, UserManager<User> userManager)
        {
            // Seed dla podstawowych kont użytkowników
            if (!userManager.Users.Any())
            {

                var users = new List<User>
                {
                    new User
                    {
                        Id = "a",
                        UserName = "admin",
                        Email = "admin@admin.pl",
                    },
                    new User
                    {
                        Id = "u",
                        UserName = "user",
                        Email = "user@user.pl",
                    }
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "haslo");
                }
            }
        }
        }
}
