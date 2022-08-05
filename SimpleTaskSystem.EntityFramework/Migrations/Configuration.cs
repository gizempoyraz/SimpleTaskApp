using System.Data.Entity.Migrations;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using SimpleTaskSystem.Migrations.SeedData;
using EntityFramework.DynamicFilters;
using SimpleTaskSystem.EntityFramework;

namespace SimpleTaskSystem.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<SimpleTaskSystem.EntityFramework.SimpleTaskSystemDbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant { get; set; }

        public Configuration()

        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SimpleTaskSystem";
        }

        protected override void Seed(SimpleTaskSystem.EntityFramework.SimpleTaskSystemDbContext context)
        {
            context.DisableAllFilters();

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantCreator(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();
            }
            else
            { ////You can add seed for tenant databases and use Tenant property...
                 protected override void Seed(SimpleTaskSystemDbContext context)
        {
            context.People.AddOrUpdate(
                p => p.Name,
                new Person { Name = "Gizem" },
                new Person { Name = "Gamze" },
                new Person { Name = "Nuran" },
                new Person { Name = "Mehmet" }
                );
        }
        
    }

            context.SaveChanges();
        }
    }
}
