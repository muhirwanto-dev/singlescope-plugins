using SingleScope.Querying.Execution.Enumerable;
using SingleScope.Querying.Paging;
using SingleScope.Querying.Sorting;
using SingleScope.Querying.Test.Data;
using SingleScope.Querying.Test.TestModels;

namespace SingleScope.Querying.Test.Cursor
{
    public class CursorPagingTests
    {
        [Fact]
        public void CursorPaging_Returns_Next_Page()
        {
            var data = TestDataFactory.CreateItems();

            var firstQuery = new Query
            (
                SortOptions.By("CreatedAt"),
                cursorPaging: new CursorPaginationOptions(
                    cursorField: "CreatedAt",
                    limit: 3)
            );

            var first = new EnumerableQueryExecutor<TestItem>()
                .Execute(firstQuery, data);

            var secondQuery = new Query
            (
                SortOptions.By("CreatedAt"),
                cursorPaging: new CursorPaginationOptions(
                    cursorField: "CreatedAt",
                    cursor: first.PageInfo!.EndCursor,
                    limit: 3)
            );

            var second = new EnumerableQueryExecutor<TestItem>()
                .Execute(secondQuery, data);

            Assert.Equal(3, second.Items.Count);
            Assert.True(second.Items.First().CreatedAt >
                        first.Items.Last().CreatedAt);
        }
    }
}
