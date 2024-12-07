using System;
using System.IO;
using System.Text.Json;

namespace Files
{
    public static class SerializableDeserializable
    {
        //Сериализация - преващение объекта(класса) в поток битов, Десериализация - обратный процесс

        [Serializable] // Атрибут сериализации
        class Person
        {
            // Простая модель класса
            public string Name { get; set; }
            public int Year { get; set; }

            // Метод-конструктор
            public Person(string name, int year)
            {
                Name = name;
                Year = year;
            }
        }

        // Описываем наш класс и помечаем его атрибутом для последующей сериализации
        [Serializable]
        public class Pet
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public Pet(string name, int age)
            {
                Name = name;
                Age = age;
            }
        }

        public static void SerDeser()
        {
            // Объект для сериализации
            var pet = new Pet("Rex", 2);
            Console.WriteLine("Объект создан");
            
            // Сериализация
            var options = new JsonSerializerOptions { WriteIndented = true };
            var jsonString = JsonSerializer.Serialize(pet, options);
            File.WriteAllText("myPets.json", jsonString);
            Console.WriteLine("Объект сериализован");

            // Десериализация
            jsonString = File.ReadAllText("myPets.json");
            var newPet = JsonSerializer.Deserialize<Pet>(jsonString);
            Console.WriteLine("Объект десериализован");

            Console.WriteLine($"Имя: {newPet.Name} --- Возраст: {newPet.Age}");
            Console.ReadLine();
        }
    }
}
