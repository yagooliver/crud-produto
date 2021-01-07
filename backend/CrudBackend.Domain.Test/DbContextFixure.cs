using CrudBackend.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CrudBackend.Domain.Test
{
    public class DbContextFixure
    {

        protected CrudContext db;
        protected static DbContextOptions<CrudContext> CreateNewContextOptions()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<CrudContext>();
            builder.UseInMemoryDatabase("CrudProdutoTest")
                .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        protected CrudContext GetDbInstance()
        {
            var options = CreateNewContextOptions();
            return new CrudContext(options);
        }
    }

}