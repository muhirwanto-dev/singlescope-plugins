using SingleScope.Querying.Execution.Queryable;
using SingleScope.Querying.Sorting;
using SingleScope.Querying.Test.Data;
using SingleScope.Querying.Test.TestModels;

namespace SingleScope.Querying.Test.Queryable
{
    //public class QueryableSortingTests
    //{
    //    [Fact]
    //    public void EF_Sort_Descending_Works()
    //    {
    //        var options = new DbContextOptionsBuilder<TestDbContext>()
    //            .UseInMemoryDatabase(Guid.NewGuid().ToString())
    //            .Options;

    //        using var ctx = new TestDbContext(options);
    //        ctx.Items.AddRange(TestDataFactory.CreateItems());
    //        ctx.SaveChanges();

    //        var query = new Query
    //        {
    //            Sort = SortOptions.By("Score", SortDirection.Desc)
    //        };

    //        var result = new QueryableQueryExecutor<TestItem>()
    //            .Execute(query, ctx.Items);

    //        Assert.Equal(100, result.Items.First().Score);
    //    }
    //}
}
