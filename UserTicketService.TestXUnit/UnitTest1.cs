namespace UserTicketService.TestXUnit
{
    public class UnitTest1 //отличие от NUnit что не нужно помечать атрибутами класс, что он является тестовым
    {
        [Fact]
        public void Test1()
        {
            Assert.True(100 == 100);
        }
    }
}