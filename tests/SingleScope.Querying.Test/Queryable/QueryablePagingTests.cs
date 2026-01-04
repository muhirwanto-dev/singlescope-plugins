using Microsoft.EntityFrameworkCore;
using SingleScope.Querying.Execution.Queryable;
using SingleScope.Querying.Paging;
using SingleScope.Querying.Test.Data;
using SingleScope.Querying.Test.TestModels;

namespace SingleScope.Querying.Test.Queryable
{
    public class QueryablePagingTests
    {
        [Fact]
        public void EF_OffsetPaging_Works()
        {
            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using var ctx = new TestDbContext(options);
            ctx.Items.AddRange(TestDataFactory.CreateItems());
            ctx.SaveChanges();

            var query = new Query(null, new OffsetPaginationOptions(2, 4));

            var result = new QueryableQueryExecutor<TestItem>()
                .Execute(query, ctx.Items);

            Assert.Equal(4, result.Items.Count);
            Assert.Equal(5, result.Items.First().Id);
        }
    }
}
