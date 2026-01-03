using SingleScope.Querying.Test.TestModels;

namespace SingleScope.Querying.Test.Data
{
    public static class TestDataFactory
    {
        public static List<TestItem> CreateItems(int count = 10)
        {
            return System.Linq.Enumerable.Range(1, count)
                .Select(i => new TestItem
                {
                    Id = i,
                    Name = $"Item {i}",
                    Score = i * 10,
                    CreatedAt = new DateTime(2024, 1, 1).AddDays(i)
                })
                .ToList();
        }
    }
}
