using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using static Files.Program;

namespace Files
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //System.IO

            //1.класс DriveInfo
            // получим системные диски
            DriveInfo[] drives = DriveInfo.GetDrives();

            // Пробежимся по дискам и выведем их свойства
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"Название: {drive.Name}");
                Console.WriteLine($"Тип: {drive.DriveType}");
                if (drive.IsReady)
                {
                    Console.WriteLine($"Объем: {drive.TotalSize}");
                    Console.WriteLine($"Свободно: {drive.TotalFreeSpace}");
                    Console.WriteLine($"Метка: {drive.VolumeLabel}");
                }
            }

            //2.классы Directory и DirectoryInfo.
            string dirName = @"C:\";
            string folder1 = @"C:\TestFirstApp\NewFolder";
            string folder2 = @"C:\TestFirstAppNew";
            GetCatalogs(dirName);
            CreateNewFolder(dirName);
            MoveFolder(folder1, folder2);
            DeleteFolder(dirName);
            GetFoldersFilesNumber(dirName);
            MoveToGarbage(@"C:/Users/aveA/Desktop", "testFolder");

            //3.классы File и FileInfo - для общих операций с файлами (не для работы с текстом в файлах, для такого StreamWriter)
            string filePath = @"C:/Users/babylon/source/repos/FirstApp/Files/Program.cs";
            if (File.Exists(filePath))
            {
                FileInfo fileInfo = new FileInfo(filePath);
                using (StreamWriter sw = fileInfo.AppendText())
                {
                    sw.WriteLine($"// Время запуска: {DateTime.Now}");
                }
                using (StreamReader sr = File.OpenText(filePath))
                {
                    //string str = "";
                    while (sr.ReadLine() != null)
                    {
                        Console.WriteLine(sr.ReadLine());
                    }
                }
            }

            //4.классы BinaryWriter и BinaryReader - для записи в файловый поток или чтения
            // сохраняем путь к файлу (допустим, вы его скачали на рабочий стол)
            string filePath4 = @"C:\Users\aveA\Downloads\BinaryFile.bin";

            // при запуске проверим, что файл существует
            if (File.Exists(filePath4))
            {
                //запись в файл инфы
                WriteOSVersion(filePath4);

                // строковая переменная, в которую будем считывать данные
                string stringValue;

                // считываем, после использования высвобождаем задействованный ресурс BinaryReader
                using (BinaryReader reader = new BinaryReader(File.Open(filePath4, FileMode.Open)))
                {
                    stringValue = reader.ReadString();
                }

                // Вывод
                Console.WriteLine("Из файла считано:");
                Console.WriteLine(stringValue);
            }

            var contact = new Contact("Sasha", 8923131313, "dasdad@mail.ru");
            // Сериализация объекта в бинарный файл
            using (FileStream fs = new FileStream(filePath4, FileMode.Create))
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                contact.Serialize(writer);
            }

            // Десериализация объекта из бинарного файла
            Contact deserializedContact;
            using (FileStream fs = new FileStream(filePath4, FileMode.Open))
            using (BinaryReader reader = new BinaryReader(fs))
            {
                deserializedContact = Contact.Deserialize(reader);
            }

            // Вывод десериализованных данных
            Console.WriteLine($"Name: {deserializedContact.Name}, Phone: {deserializedContact.PhoneNumber}, Email: {deserializedContact.Email}");

            SerializeClass(contact);

            Console.ReadKey();
        }

        [Serializable]
        public class Contact
        {
            public string Name { get; set; }
            public long PhoneNumber { get; set; }
            public string Email { get; set; }

            public Contact(string name, long phoneNumber, string email)
            {
                Name = name;
                PhoneNumber = phoneNumber;
                Email = email;
            }

            // Метод для сериализации объекта в бинарный формат
            public void Serialize(BinaryWriter writer)
            {
                writer.Write(Name);
                writer.Write(PhoneNumber);
                writer.Write(Email);
            }

            // Метод для десериализации объекта из бинарного формата
            public static Contact Deserialize(BinaryReader reader)
            {
                string name = reader.ReadString();
                long phoneNumber = reader.ReadInt64();
                string email = reader.ReadString();

                return new Contact(name, phoneNumber, email);
            }
        }

        static void SerializeClass<T>(T obj)
        {           
            JsonSerializerOptions options = new JsonSerializerOptions() 
            {
                WriteIndented = true,
            };
            string jsonSer = JsonSerializer.Serialize<T>(obj, options);

            File.WriteAllText(@"C:\Users\aveA\Downloads\ser.json", jsonSer);

            Console.WriteLine(@"Объект сериализован");
        }

        static void WriteOSVersion(string filePath)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Open)))
            {
                writer.Write($@"{DateTime.Now}, {Environment.OSVersion}");
            }
        }

        static void MoveToGarbage(string dirName, string folderName)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo($@"{dirName}/{folderName}");

            if (directoryInfo.Exists)
                directoryInfo.MoveTo($@"C:\$Recycle.Bin\{folderName}");
        }

        static void MoveFolder(string dirName, string newDirName)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(dirName);

            if (directoryInfo.Exists && !Directory.Exists(newDirName))
                directoryInfo.MoveTo($@"{newDirName}");
        }

        static void DeleteFolder(string dirName)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo($@"{dirName}TestFirstApp\");
            
            if (directoryInfo.Exists)
                directoryInfo.Delete(true);
        }

        static void CreateNewFolder(string dirName)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo($@"{dirName}TestFirstApp\");

            if (!directoryInfo.Exists)
                directoryInfo.Create();

            directoryInfo.CreateSubdirectory("TestFirstAppSubfolder");
        }

        static void GetFoldersFilesNumber(string dirName)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(dirName);
            if (!directoryInfo.Exists)
                Console.WriteLine("Укажите верную директорию");

            try
            {
                DirectoryInfo[] dirs = directoryInfo.GetDirectories();
                Console.WriteLine("Количество папок: {0}", dirs.Length);

                FileInfo[] files = directoryInfo.GetFiles();
                Console.WriteLine("Количество файлов: {0}", files.Length);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void GetCatalogs(string dirName)
        {
            // В dirName прописываем путь к корневой директории MacOS (для Windows скорее всего тут будет "C:\\")
            if (Directory.Exists(dirName)) // Проверим, что директория существует
            {
                Console.WriteLine("Папки:");
                string[] dirs = Directory.GetDirectories(dirName);  // Получим все директории корневого каталога

                foreach (string d in dirs) // Выведем их все
                    Console.WriteLine(d);

                Console.WriteLine();
                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(dirName);// Получим все файлы корневого каталога

                foreach (string s in files)   // Выведем их все
                    Console.WriteLine(s);
            }
        }

        #region Структура диск
        public class Drive
        {
            public string Name { get; }
            public long TotalSpace { get; }
            public long FreeSpace { get; }

            public Drive(string name, long totalSpace, long freeSpace)
            {
                Name = name;
                TotalSpace = totalSpace;
                FreeSpace = freeSpace;
            }
        }

        public class Folder
        {
            public List<string> Files { get; set; } = new List<string>();
        }

        Dictionary<string, Folder> Folders = new Dictionary<string, Folder>();
        public void CreateNew(string name)
        {
            Folders.Add(name, new Folder());
        }
        #endregion
    }
}
// Время запуска: 07.12.2024 18:36:14
