namespace Interfaces
{
    public class NonExplicitImplement
    {
        //неявная реализация - если вдруг метод Solve убрать из интерфейса, то он останется в классе, а по факту он нам не нужен
        interface ICalculator
        {
            void Solve(int number);
            void Solve(int number1, int number2);
        }

        public class Calculator : ICalculator
        {
            public void Solve(int number)
            {

            }

            public void Solve(int number1, int number2)
            {

            }
        }
    }
    public class ExplicitImplement
    {
        //явная реализация интерфейса - теперь если убрать метод Solve из интерфейса, то будет ошибка в классе об этом методе и ее легко будет отыскать и удалить
        interface ICalculator
        {
            void Solve(int number);
            void Solve(int number1, int number2);
        }

        public class Calculator : ICalculator
        {
            void ICalculator.Solve(int number)
            {

            }

            void ICalculator.Solve(int number1, int number2)
            {

            }
        }
    }
}
