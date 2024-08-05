using System;
using System.IO;

namespace AlgoComplexity
{
    public class FolderTools
    {
        public static float FolderSize(string path)
        {
            float size = 0;
            foreach (var file in Directory.EnumerateFiles(path))
            {
                try
                {
                    var info = new FileInfo(file);
                    size += info.Length;
                }
                catch (UnauthorizedAccessException e)
                {
                    
                }
            }
            
            foreach (var directory in Directory.EnumerateDirectories(path))
            {
                size += FolderSize(directory);
            }

            return size;
        }

        public static void FormatSize(float size)
        {
            string[] prefix = {"b", "kb", "mb", "gb", "tb", "pb", "zb"};
            int regresses = 0;
            while (size > 1024)
            {
                size /= 1024;
                ++regresses;
            }
            Console.WriteLine($"Size of folder is {size} {prefix[regresses]}");
        }
    }
}