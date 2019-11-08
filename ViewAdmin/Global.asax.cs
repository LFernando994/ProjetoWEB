using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ViewAdmin.Models;

namespace ViewAdmin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<InfraWeb.Context.ContextDB, InfraWeb.Migrations.Configuration>());

            ApplicationDbContext db = new ApplicationDbContext();
            CriarRoles(db);
            CriarSuperUsuario(db);
            AddPermissoesSuperUser(db);
            db.Dispose();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Extensão Mensagem para ActionResult
            ClientDataTypeModelValidatorProvider.ResourceClassKey = "Mensagens";
            DefaultModelBinder.ResourceClassKey = "Mensagens";
        }

        private void AddPermissoesSuperUser(ApplicationDbContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = userManager.FindByName("adm@email.com");
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            if(!userManager.IsInRole(user.Id, "View"))
            {
                userManager.AddToRole(user.Id, "View");
            }
            if (!userManager.IsInRole(user.Id, "Edit"))
            {
                userManager.AddToRole(user.Id, "Edit");
            }
            if (!userManager.IsInRole(user.Id, "Create"))
            {
                userManager.AddToRole(user.Id, "Create");
            }
            if (!userManager.IsInRole(user.Id, "Delete"))
            {
                userManager.AddToRole(user.Id, "Delete");
            }
            if (!userManager.IsInRole(user.Id, "Funcionario"))
            {
                userManager.AddToRole(user.Id, "Funcionario");
            }
            if (!userManager.IsInRole(user.Id, "Cliente"))
            {
                userManager.AddToRole(user.Id, "Cliente");
            }
        }

        private void CriarSuperUsuario(ApplicationDbContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = userManager.FindByName("adm@email.com"); 
            if(user == null)
            {
                user = new ApplicationUser
                {
                    UserName = "adm@email.com",
                    Email = "adm@email.com"
                };
                userManager.Create(user, "1407Lfs!");
            }
        }

        private void CriarRoles(ApplicationDbContext db)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            if(!roleManager.RoleExists("View"))
            {
                roleManager.Create(new IdentityRole("View"));
            }
            if (!roleManager.RoleExists("Edit"))
            {
                roleManager.Create(new IdentityRole("Edit"));
            }
            if (!roleManager.RoleExists("Create"))
            {
                roleManager.Create(new IdentityRole("Create"));
            }
            if (!roleManager.RoleExists("Delete"))
            {
                roleManager.Create(new IdentityRole("Delete"));
            }
            if (!roleManager.RoleExists("Funcionario"))
            {
                roleManager.Create(new IdentityRole("Funcionario"));
            }
            if (!roleManager.RoleExists("Cliente"))
            {
                roleManager.Create(new IdentityRole("Cliente"));
            }
        }
    }
}
