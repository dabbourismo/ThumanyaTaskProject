using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Thumanya.DataAccessLayer
{
    public class CMSDbContextFactory : IDesignTimeDbContextFactory<CMSDbContext>
    {
        public CMSDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CMSDbContext>();
            optionsBuilder.UseSqlite("Data Source=CMSSQLite.db");

            return new CMSDbContext(optionsBuilder.Options);
        }
    }
}
