using Moq;
using MoqTestTask;

namespace BookRepository.Test
{
    public class BookRepositoryTests
    {
        [Fact]
        public void FindAllMustReturnCorrectValue()
        {
            var books = new List<Book>() 
            {
                new Book() {Title="Война и мир"},
                new Book() {Title="Человек-невидимка"},
                new Book() {Title="Анна Каренина"}
            };

            var mockBookRepos = new Mock<IBookRepository>();
            mockBookRepos.Setup(x => x.FindAll()).Returns(books);

            Assert.Contains(mockBookRepos.Object.FindAll(), x => x.Title == "Война и мир");
            Assert.Contains(mockBookRepos.Object.FindAll(), x => x.Title == "Человек-невидимка");
            Assert.Contains(mockBookRepos.Object.FindAll(), x => x.Title == "Анна Каренина");
        }
    }
}