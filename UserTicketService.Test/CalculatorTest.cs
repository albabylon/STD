namespace UserTicketService.TestNUnit
{
    [TestFixture]
    public class CalculatorTest
    {
        [Test]
        public void DivisionMustThrowException()
        {
            var calc = new Calculator();

            Assert.Throws<DivideByZeroException>(() => calc.Division(10, 0));
        }
    }
}
