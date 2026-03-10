using SingleScope.Querying.Execution.Enumerable;
using SingleScope.Querying.Sorting;
using SingleScope.Querying.Test.Data;
using SingleScope.Querying.Test.TestModels;

namespace SingleScope.Querying.Test.Enumerable
{
    public class EnumerableSortingTests
    {
        [Fact]
        public void Sort_Descending_Works()
        {
            var data = TestDataFactory.CreateItems();

            var query = new Query(SortOptions.By("Score", SortDirection.Desc));

            var result = new EnumerableQueryExecutor<TestItem>()
                .Execute(query, data);

            Assert.Equal(100, result.Items.First().Score);
        }
    }
}
