namespace SingleScope.Querying.Test.TestModels
{
    public sealed class TestItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Score { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
