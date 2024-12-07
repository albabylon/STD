using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //По видео
            FileInfo configFile = new FileInfo(@"C:\Users\aveA\Desktop\configTest.txt");
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                DirectoryInfo root = drive.RootDirectory;
                DirectoryInfo[] folders = root.GetDirectories();

                Console.WriteLine($@"Сканиурется диск {drive.Name}...");

                using (StreamWriter sw = configFile.AppendText())
                {
                    WriteDriveInfo(drive, sw);
                    WriteFileInfo(root, sw);
                    WriteFolderInfo(folders, sw);
                }
            }
            Console.WriteLine($@"Завершено");
        }

        static void WriteDriveInfo(DriveInfo drive, StreamWriter sw)
        {
            sw.WriteLine($"Название: {drive.Name}");
            sw.WriteLine($"Тип: {drive.DriveType}");
            if (drive.IsReady)
            {
                sw.WriteLine($"Объем: {drive.TotalSize}");
                sw.WriteLine($"Свободно: {drive.TotalFreeSpace}");
                sw.WriteLine($"Метка: {drive.VolumeLabel}");
            }
        }

        static void WriteFolderInfo(DirectoryInfo[] folders, StreamWriter sw)
        {
            sw.WriteLine();
            sw.WriteLine($"Папки: ");

            foreach (DirectoryInfo folder in folders)
            {
                try
                {
                    long size = DirectoryExtension.DirSize(folder);
                    sw.WriteLine($"{folder.Name} - {size} байт");
                }
                catch (Exception ex)
                {
                    sw.WriteLine(ex.Message);
                }
            }
        }

        static void WriteFileInfo(DirectoryInfo folder, StreamWriter sw)
        {
            FileInfo[] files = folder.GetFiles();

            foreach (FileInfo file in files)
            {
                sw.WriteLine($"{file.Name} - {file.Length} байт");
            }
        }
    }
}
