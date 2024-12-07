using System.IO;

namespace FilesApp
{
    public static class DirectoryExtension
    {
        public static long DirSize(DirectoryInfo dir)
        {
            long size = 0;

            FileInfo[] fileInfos = dir.GetFiles();
            foreach (FileInfo fileInfo in fileInfos)
            {
                size += fileInfo.Length;
            }

            DirectoryInfo[] dirsInDir = dir.GetDirectories();
            foreach (DirectoryInfo dirInDir in dirsInDir)
            {
                size += DirSize(dirInDir);
            }

            return size;
        }
    }
}
