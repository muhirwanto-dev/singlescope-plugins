using Microsoft.EntityFrameworkCore;

namespace SingleScope.Querying.Test.TestModels
{

    internal sealed class TestDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<TestItem> Items => Set<TestItem>();
    }
}
