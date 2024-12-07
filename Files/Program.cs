using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Files.Program;

namespace Files
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region System.IO
            ////класс DriveInfo
            //// получим системные диски
            //DriveInfo[] drives = DriveInfo.GetDrives();
            //// Пробежимся по дискам и выведем их свойства
            //foreach (DriveInfo drive in drives)
            //{
            //    WriteDriveInfo(drive);

            //    DirectoryInfo root = drive.RootDirectory;
            //    DirectoryInfo[] folders = root.GetDirectories();
            //    WriteFolderInfo(folders);

            //    Console.WriteLine();
            //    Console.WriteLine();
            //}

            ////классы Directory и DirectoryInfo.
            //string dirName = @"C:\";
            //string folder1 = @"C:\TestFirstApp\NewFolder";
            //string folder2 = @"C:\TestFirstAppNew";
            //GetCatalogs(dirName);
            //CreateNewFolder(dirName);
            //MoveFolder(folder1, folder2);
            //DeleteFolder(dirName);
            //GetFoldersFilesNumber(dirName);
            //MoveToGarbage(@"C:/Users/aveA/Desktop", "testFolder");
            #endregion

            Console.ReadKey();
        }



        static void WriteDriveInfo(DriveInfo drive)
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

        static void WriteFolderInfo(DirectoryInfo[] folders)
        {
            Console.WriteLine();
            Console.WriteLine($"Папки: ");

            foreach (DirectoryInfo folder in folders) 
            { 
                Console.WriteLine(folder.Name);
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
