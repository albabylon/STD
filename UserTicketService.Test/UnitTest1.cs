namespace UserTicketService.Test
{
    public class Tests
    {
        [TestFixture]
        public class Class1
        {
            [Test]
            public void Test1()
            {
                Assert.True(100 == 100);
                // Assert.False - Проверяем, что указанное условие ложно
                // Assert.Null - Проверяем, что указанный объект имеет значение null
                // Assert.Zero - Проверяем, что указанное число равно нулю
                // Assert.IsEmpty - Проверяем, что указанная строка пустая
            }
        }
    }
}