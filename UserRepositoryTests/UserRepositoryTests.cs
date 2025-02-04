using Moq;
using MoqTestTask;

namespace UserRepositoryTests
{
    public class Tests
    {
        [Test]
        public void FindAllMustReturnCorrectValue()
        {
            List<User> users = new List<User>() 
            {
                new User() {Name = "Антон"},
                new User() {Name = "Иван"},
                new User() {Name = "Алексей"},
            };

            var mockUserRepos = new Mock<IUserRepository>();
            mockUserRepos.Setup(x => x.FindAll()).Returns(users);

            Assert.That(mockUserRepos.Object.FindAll().Any(x => x.Name == "Антон"));
            Assert.That(mockUserRepos.Object.FindAll().Any(x => x.Name == "Иван"));
            Assert.That(mockUserRepos.Object.FindAll().Any(x => x.Name == "Алексей"));
        }
    }
}