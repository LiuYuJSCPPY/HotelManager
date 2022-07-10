using HotelManager.Model;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HotelManager.Services;

namespace HotelManager.Services
{
    public class HotelManagerSingInManager : SignInManager<HotelUser, string>
    {
        public HotelManagerSingInManager(HotelManagerUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(HotelUser user)
        {
            return user.GenerateUserIdentityAsync((HotelManagerUserManager)UserManager);
        }

        public static HotelManagerSingInManager Create(IdentityFactoryOptions<HotelManagerSingInManager> options, IOwinContext context)
        {
            return new HotelManagerSingInManager(context.GetUserManager<HotelManagerUserManager>(), context.Authentication);
        }
    }
}
