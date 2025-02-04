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

        [Test]
        public void AddAlwaysReturnsExpectedValue()
        {
            var calculatorTest = new Calculator();
            Assert.That(calculatorTest.Add(10, 220), Is.EqualTo(230));
        }
    }
}
