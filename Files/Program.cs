using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }

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
        public void CreateNewFolder(string name)
        {
            Folders.Add(name, new Folder());
        }
    }
}
