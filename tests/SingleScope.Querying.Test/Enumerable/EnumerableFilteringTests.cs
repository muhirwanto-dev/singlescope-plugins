using SingleScope.Querying.Execution.Enumerable;
using SingleScope.Querying.Filtering;
using SingleScope.Querying.Test.Data;
using SingleScope.Querying.Test.TestModels;

namespace SingleScope.Querying.Test.Enumerable
{
    public class EnumerableFilteringTests
    {
        [Fact]
        public void Filter_Equals_Works()
        {
            var data = TestDataFactory.CreateItems();

            var query = new Query(
                new FilterOptions(
                [
                    new FilterDescriptor("Score", FilterOperator.Equals, 50)
                ]),
                null
                );

            var result = new EnumerableQueryExecutor<TestItem>()
                .Execute(query, data);

            Assert.Single(result.Items);
            Assert.Equal(50, result.Items[0].Score);
        }
    }
}
