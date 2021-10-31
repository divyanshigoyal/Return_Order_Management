using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager){
            if(!userManager.Users.Any()){

                var user = new AppUser{
                    DisplayName = "Supreme Kai",
                    Email = "SupremeKai@Dbz.com",
                    UserName = "SupremeKai@Dbz.com",

                    Address = new Address{
                        FirstName = "Supreme",
                        LastName = "Kai",
                        AddressDetails = "Planet namek"
                    }
                };

                await userManager.CreateAsync(user, "supremekai1@A");
            }

        }
    }
}