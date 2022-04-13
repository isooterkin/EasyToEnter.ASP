using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace EasyToEnter.ASP.Data
{
    public class EasyToEnterDbContextFactory : IDbContextFactory<EasyToEnterDbContext>
    {
        private readonly Action<DbContextOptionsBuilder> _configureDbContext;

        public EasyToEnterDbContextFactory(Action<DbContextOptionsBuilder> configureDbContext)
        {
            _configureDbContext = configureDbContext;
        }

        public EasyToEnterDbContext CreateDbContext()
        {
            DbContextOptionsBuilder<EasyToEnterDbContext> options = new();

            _configureDbContext(options);

            return new EasyToEnterDbContext(options.Options);
        }
    }
}