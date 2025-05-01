using Moq;
using SingleScope.Persistence.Repository;
using SingleScope.Persistence.UnitTests.DataSource;

namespace SingleScope.Persistence.UnitTests
{
    public class UseSingleScopePersistenceRepositoryTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(int.MaxValue)]
        public void Find_UseKey_ReturnNotNull(int id)
        {
            // Arrange
            var repository = new Mock<IReadOnlyRepository>();

            repository.Setup(m => m.Find<NullEntity>(id))
                .Returns(new NullEntity { Id = id });

            // Act
            var actual = repository.Object.Find<NullEntity>(id);

            // Assert
            Assert.NotNull(actual);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(int.MaxValue)]
        public void Get_WithPredicate_ReturnNotNull(int id)
        {
            // Arrange
            var repository = new Mock<IReadOnlyRepository>();

            repository.Setup(m => m.Get<NullEntity>(e => e.Id == id))
                .Returns(new NullEntity { Id = id });

            // Act
            var actual = repository.Object.Get<NullEntity>(e => e.Id == id);

            // Assert
            Assert.NotNull(actual);
        }
    }
}