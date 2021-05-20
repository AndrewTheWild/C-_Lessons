using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Laba7
{
    class Program
    {
        static double GeneralSizeDirectory = 0;
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Main";
            FileOnDirectory(@"F:\C#\Labaratory\Laba1");
        }

        static void FileOnDirectory(object obj)
        {
            var path = obj as string;
            var directories = Directory.GetDirectories(path);
            var files = Directory.GetFiles(path);

            if (files.Length > 0)
            {

                foreach (var file in files)
                {
                    var fileInfo = new FileInfo(file);
                    GeneralSizeDirectory += fileInfo.Length;
                }

            }

            if (directories.Length > 0)
            {
                foreach (var directory in directories)
                {
                    var myThread = new Thread(new ParameterizedThreadStart(FileOnDirectory));
                    myThread.Name = $"Thread:{directory}";
                    myThread.Start(directory);
                    myThread.Join();
                }
            }

            Console.WriteLine($"{Thread.CurrentThread.Name}  Size:{GeneralSizeDirectory} byte");
        }
    }
}
