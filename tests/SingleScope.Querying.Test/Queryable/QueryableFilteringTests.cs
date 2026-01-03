using SingleScope.Querying.Execution.Queryable;
using SingleScope.Querying.Filtering;
using SingleScope.Querying.Test.Data;
using SingleScope.Querying.Test.TestModels;

namespace SingleScope.Querying.Test.Queryable
{
    public class QueryableFilteringTests
    {
        //[Fact]
        //public void EF_Filter_Equals_Works()
        //{
        //    var options = new DbContextOptionsBuilder<TestDbContext>()
        //        .UseInMemoryDatabase(Guid.NewGuid().ToString())
        //        .Options;

        //    using var ctx = new TestDbContext(options);
        //    ctx.Items.AddRange(TestDataFactory.CreateItems());
        //    ctx.SaveChanges();

        //    var query = new Query
        //    {
        //        Filters = new FilterOptions(new[]
        //        {
        //        new FilterDescriptor("Score", FilterOperator.Equals, 30)
        //    })
        //    };

        //    var result = new QueryableQueryExecutor<TestItem>()
        //        .Execute(query, ctx.Items);

        //    Assert.Single(result.Items);
        //    Assert.Equal(30, result.Items[0].Score);
        //}
    }
}
