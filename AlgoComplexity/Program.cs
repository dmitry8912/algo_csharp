using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;

namespace AlgoComplexity
{
    class Program
    {
        static void Main(string[] args)
        {
            var st = new Stopwatch();

            int size = 50000;
            
            int[] array = new int[size];

            var rnd = new Random(40);
            
            for (int i = 0; i < size; i++)
            {
                array[i] = rnd.Next(0, 5000);
                if (array[i] % 2 == 0)
                {
                    array[i] += 1;
                }
            }
            
            st.Start();
            for (int i = 0; i < size; i++)
            {
                array[i] += 1;
                
            }
            st.Stop();
            Console.WriteLine($"Not sort = {st.ElapsedTicks}");
            
            st.Reset();
            
            Array.Sort(array);
            
            st.Start();
            for (int i = 0; i < size; i++)
            {
                array[i] += 1;
                
            }
            st.Stop();
            Console.WriteLine($"After sort = {st.ElapsedTicks}");
        }

        public static bool LongCalc()
        {
            Thread.Sleep(2000);
            return false;
        }
        
        
        static void arrayIncrement()
        {
            var st = new Stopwatch();

            int size = 5000;

            int[,] array = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    array[i, j] = i + j;
                }
            }
            
            st.Start();
            
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    array[i, j] += 1;
                }
            }
            
            st.Stop();
            
            Console.WriteLine($"array[i, j] += 1; took {st.ElapsedMilliseconds}ms; {st.ElapsedTicks} ticks");
            
            st.Reset();
            
            st.Start();
            
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    array[j, i] += 1;
                }
            }
            
            st.Stop();
            
            Console.WriteLine($"array[j,i] += 1; took {st.ElapsedMilliseconds}ms; {st.ElapsedTicks} ticks");
        }

        static float CalcFolderSize(string path)
        {
            float result = 0;
            
            List<string> directories = Directory.EnumerateDirectories(path).ToList();

            int i = 0;
            while (i < directories.Count)
            {
                try
                {
                    directories.AddRange(Directory.EnumerateDirectories(directories[i]).ToList());
                    ++i;
                }
                catch (UnauthorizedAccessException ex)
                {
                    
                }
                
            }
            
            foreach (var dir in directories)
            {
                foreach (var file in Directory.EnumerateFiles(dir))
                {
                    try
                    {
                        var info = new FileInfo(file);
                        result += info.Length;
                    }
                    catch (UnauthorizedAccessException ex)
                    {}
                }
            }
            
            return result;
        }
    }
}