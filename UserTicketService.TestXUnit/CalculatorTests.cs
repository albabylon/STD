namespace UserTicketService.TestXUnit
{
    public class CalculatorTests // Имя должно быть: [Класс для теста]Tests
    {
        [Fact]
        public void MultiplicationMustReturnNotNullValue() // Имя должно быть: [Имя метода][Должно][Что вернуть]
        {
            var calc = new Calculator();
            int result = calc.Multiplication(2, 4);

            Assert.Equal(8, result);
        }

        [Fact]
        public void SubtractionMustReturnCorrectValue()
        {
            var calc = new Calculator();
            int result = calc.Subtraction(222, 2);

            Assert.Equal(220, result);
        }

        [Fact]
        public void DivisionMustReturnCorrectValue()
        {
            var calc = new Calculator();
            int result = calc.Division(100, 10);

            Assert.Equal(10, result);
        }
    }
}
