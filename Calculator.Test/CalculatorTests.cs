namespace Calculator.Test
{
    public class Tests
    {
        [Test]
        public void AdditionalMustReturnCorrectValue()
        {
            var calc = new Practices.Calculator();

            var result = calc.Additional(100, 999);

            Assert.That(result == 1099);
        }

        [Test]
        public void SubtractionMustReturnCorrectValue()
        {
            var calc = new Practices.Calculator();

            var result = calc.Subtraction(1000, 1);

            Assert.True(result == 999);
        }

        [Test]
        public void MiltiplicationMustReturnCorrectValue()
        {
            var calc = new Practices.Calculator();

            var result = calc.Miltiplication(122, 2);

            Assert.That(result, Is.EqualTo(244));
        }

        [Test]
        public void DivisionMustReturnCorrectValue()
        {
            var calc = new Practices.Calculator();

            int result = calc.Division(444, 111);

            Assert.That(result, Is.EqualTo(4));
        }
    }
}