namespace FirstApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int k = 0;
            while (k < 3)
            {
                (string Name, string LastName, string Login, int LoginLength, bool HasPet, double Age, string[] FavColor) User;

                Console.WriteLine("Введите имя");
                User.Name = Console.ReadLine();

                Console.WriteLine("Введите фамилию");
                User.LastName = Console.ReadLine();

                Console.WriteLine("Введите логин");
                User.Login = Console.ReadLine();

                User.LoginLength = User.Login.Length;

                Console.WriteLine("Есть ли у вас животные? Да или Нет");
                User.HasPet = false;
                if (Console.ReadLine() == "Да")
                    User.HasPet = true;

                Console.WriteLine("Введите возраст пользователя");
                if (double.TryParse(Console.ReadLine(), out double age))
                    User.Age = age;

                User.FavColor = new string[3];
                Console.WriteLine("Введите три любимых цвета пользователя");
                for (int i = 0; i < User.FavColor.Length; i++)
                {
                    User.FavColor[i] = Console.ReadLine();
                }

                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("                                                       ");
                Console.BackgroundColor = ConsoleColor.Black;
                k++;
            }

            Console.ReadLine();

        }
    }
}