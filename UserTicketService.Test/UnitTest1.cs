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
                Assert.True(50 == 100);
                // Assert.False - ���������, ��� ��������� ������� �����
                // Assert.Null - ���������, ��� ��������� ������ ����� �������� null
                // Assert.Zero - ���������, ��� ��������� ����� ����� ����
                // Assert.IsEmpty - ���������, ��� ��������� ������ ������
            }
        }
    }
}