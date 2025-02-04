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
                new User() {Name = "�����"},
                new User() {Name = "����"},
                new User() {Name = "�������"},
            };

            var mockUserRepos = new Mock<IUserRepository>();
            mockUserRepos.Setup(x => x.FindAll()).Returns(users);

            Assert.That(mockUserRepos.Object.FindAll().Any(x => x.Name == "�����"));
            Assert.That(mockUserRepos.Object.FindAll().Any(x => x.Name == "����"));
            Assert.That(mockUserRepos.Object.FindAll().Any(x => x.Name == "�������"));
        }
    }
}