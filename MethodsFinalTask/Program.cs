using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MethodsFinalTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var userInfo = GetUserInfo();

            ShowInfo(userInfo);

            Console.ReadLine();
        }

        private static (string name, string lastname, int age, bool hasPet, int petCount, string[] petAlias, int favColorsCount, string[] favColors) GetUserInfo ()
        {
            (string name, string lastname, int age, bool hasPet, int petCount, string[] petAlias, int favColorsCount, string[] favColors) userInfo = ("", "", 0, false, 0, new string[] { }, 0, new string[] { });

            Console.WriteLine("Укажите ваше имя:");
            userInfo.name = Console.ReadLine();

            Console.WriteLine("Укажите вашу фамилию:");
            userInfo.lastname = Console.ReadLine();

            Console.WriteLine("Укажите ваш возраст:");
            string inputAge = Console.ReadLine();
            while (!CheckInputData(inputAge, out userInfo.age))
            {
                Console.WriteLine("Неверно введена информация, укажите возраст корректно:");
                inputAge = Console.ReadLine();
            }

            Console.WriteLine("Есть ли у вас питомец (Да/Нет):");
            string hasPetAnswer = Console.ReadLine();
            while (hasPetAnswer != "Да" && hasPetAnswer != "Нет") 
            {
                Console.WriteLine("Неверно введена информация, укажите Да или Нет:");
                hasPetAnswer = Console.ReadLine();
            }
            if (hasPetAnswer == "Да")
            {
                userInfo.hasPet = true;

                Console.WriteLine("Укажите количество питомцев:");
                string inputPetsCount = Console.ReadLine();
                while (!CheckInputData(inputPetsCount, out userInfo.petCount))
                {
                    Console.WriteLine("Неверно введена информация, укажите количество питомцев корректно:");
                    inputPetsCount = Console.ReadLine();
                }

                Console.WriteLine("Перечислите клички ваших питомцев:");
                userInfo.petAlias = GetArrayByInputCount(userInfo.petCount);
            }
            else if (hasPetAnswer == "Нет")
                userInfo.hasPet = false;

            Console.WriteLine("Укажите количество любимых цветов:");
            string inputFavcolorCount = Console.ReadLine();
            while (!CheckInputData(inputFavcolorCount, out userInfo.favColorsCount))
            {
                Console.WriteLine("Неверно введена информация, укажите количество любимых цветов корректно:");
                inputFavcolorCount = Console.ReadLine();
            }

            Console.WriteLine("Перечислите ваши любимые цвета:");
            userInfo.favColors = GetArrayByInputCount(userInfo.favColorsCount);

            return userInfo;
        }

        private static bool CheckInputData(string inputCount, out int outputCount)
        {
            bool isCorrect = int.TryParse(inputCount, out int outputCountParsing);

            if (isCorrect)
            {
                if (outputCountParsing > 0)
                {
                    outputCount = outputCountParsing;
                    return true;
                }
                else
                {
                    outputCount = outputCountParsing;
                    return false;
                }
            }
            else
            {
                outputCount = 0;
                return false;
            }
        }

        private static string[] GetArrayByInputCount(int inputCount)
        {
            string[] array = new string[inputCount];

            for (int i = 0; i < inputCount; i++)
            {
                array[i] = Console.ReadLine();
            }

            return array;
        }

        private static void ShowInfo((string name, string lastname, int age, bool hasPet, int petCount, string[] petAlias, int favColorsCount, string[] favColors) userInfo)
        {
            Console.WriteLine("---------------------------");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("Имя: {0}", userInfo.name);
            Console.WriteLine("Фамилия: {0}", userInfo.lastname);
            Console.WriteLine("Возраст: {0}", userInfo.age);

            string answerHasPet = "Нет";
            if (userInfo.hasPet)
                answerHasPet = "Да";
            Console.WriteLine("Есть ли питомцы: {0}", answerHasPet);

            Console.WriteLine("Количество питомцев: {0}", userInfo.petCount);
            string pets = "";
            for (int i = 0; i < userInfo.petCount; i++)
            {
                pets += userInfo.petAlias[i] + ", ";
            }
            pets = pets.Remove(pets.Length - 2);
            Console.WriteLine("Имена питомцев: {0}", pets);

            Console.WriteLine("Количество любимых цветов: {0}", userInfo.favColorsCount);
            string colors = "";
            for (int i = 0; i < userInfo.favColorsCount; i++)
            {
                colors += userInfo.favColors[i] + ", ";
            }
            colors = colors.Remove(colors.Length - 2);
            Console.WriteLine("Любимые цвета: {0}", colors);
        }
    }
}
