using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManager.Data;

namespace HotelManager.Services
{
    public class HotelRoleManager : RoleManager<IdentityRole>
    {
        public HotelRoleManager(IRoleStore<IdentityRole, string> roleStore) : base(roleStore)
        {
        }
        public static HotelRoleManager Create(IdentityFactoryOptions<HotelRoleManager> options, IOwinContext context)
        {
            return new HotelRoleManager(new RoleStore<IdentityRole>(context.Get<HotelManagerContext>()));
        }
    }
   
}
