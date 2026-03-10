using SingleScope.Querying.Execution.Enumerable;
using SingleScope.Querying.Filtering;
using SingleScope.Querying.Paging;
using SingleScope.Querying.Sorting;
using SingleScope.Querying.Test.Data;
using SingleScope.Querying.Test.TestModels;

namespace SingleScope.Querying.Test.Enumerable
{
    public class EnumerableCombinedTests
    {
        [Fact]
        public void Filter_Sort_Page_Works_Together()
        {
            var data = TestDataFactory.CreateItems();

            var query = new Query(
                new FilterOptions(
                    [
                        new FilterDescriptor("Score", FilterOperator.GreaterThanOrEqual, 40)
                    ]),
                SortOptions.By("Score"),
                offsetPaging: new OffsetPaginationOptions(1, 2)
            );

            var result = new EnumerableQueryExecutor<TestItem>()
                .Execute(query, data);

            Assert.Equal(2, result.Items.Count);
            Assert.Equal(40, result.Items.First().Score);
        }
    }
}
