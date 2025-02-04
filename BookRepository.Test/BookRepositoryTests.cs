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
                new Book() {Title="����� � ���"},
                new Book() {Title="�������-���������"},
                new Book() {Title="���� ��������"}
            };

            var mockBookRepos = new Mock<IBookRepository>();
            mockBookRepos.Setup(x => x.FindAll()).Returns(books);

            Assert.Contains(mockBookRepos.Object.FindAll(), x => x.Title == "����� � ���");
            Assert.Contains(mockBookRepos.Object.FindAll(), x => x.Title == "�������-���������");
            Assert.Contains(mockBookRepos.Object.FindAll(), x => x.Title == "���� ��������");
        }
    }
}