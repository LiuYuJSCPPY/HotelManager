using Microsoft.Owin;
using Owin;
using HotelManager.Data;
using HotelManager.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using HotelManager.Model;

[assembly: OwinStartupAttribute(typeof(HotelManager.Web.Startup))]
namespace HotelManager.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            createRolesandUsers();
            ConfigureAuth(app);
        }
        private void createRolesandUsers()
        {
            HotelManagerContext context = new HotelManagerContext();
           

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<HotelUser>(new UserStore<HotelUser>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User     
            if (!roleManager.RoleExists("超級使用者"))
            {

                // first we create Admin rool    
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "超級使用者";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                   

                var user = new HotelUser();
                user.UserName = "超級使用者";
                user.Email = "UserTest@test.com";

                string userPWD = "A@123456";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin    
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "超級使用者");

                }
            }

            // creating Creating Manager role     
            if (!roleManager.RoleExists("會員"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "會員";
                roleManager.Create(role);

            }

            // creating Creating Employee role     
            if (!roleManager.RoleExists("員工"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "員工";
                roleManager.Create(role);

            }
        }
    }
}
