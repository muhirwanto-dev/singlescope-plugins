using SingleScope.Querying.Execution.Enumerable;
using SingleScope.Querying.Paging;
using SingleScope.Querying.Test.Data;
using SingleScope.Querying.Test.TestModels;

namespace SingleScope.Querying.Test.Enumerable
{
    public class EnumerablePagingTests
    {
        [Fact]
        public void OffsetPaging_Works()
        {
            var data = TestDataFactory.CreateItems();

            var query = new Query(
                sort: null,
                offsetPaging: new OffsetPaginationOptions(2, 3)
            );

            var result = new EnumerableQueryExecutor<TestItem>()
                .Execute(query, data);

            Assert.Equal(3, result.Items.Count);
            Assert.Equal(4, result.Items.First().Id);
        }
    }
}
