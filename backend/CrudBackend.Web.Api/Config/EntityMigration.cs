using CrudBackend.Infra.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace CrudBackend.Web.Api.Config
{
    public static class EntityMigration
    {
        public static void EnsureMigrationOfContext<T>(this IApplicationBuilder app) where T : CrudContext
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<T>();
                dbContext.Database.Migrate();
            }
        }
    }
}
