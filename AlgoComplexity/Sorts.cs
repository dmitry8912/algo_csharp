using System;
using System.Diagnostics;

namespace AlgoComplexity
{
    public class Sorts
    {
        public static void Bubble(int length = 10)
        {
            //int length = 10;
            int[] array = new int[length];
            var random = new Random();
            for (int i = 0; i < length; i++)
            {
                array[i] = random.Next(0,100);
            }
            
            Console.WriteLine($"Bubble Source: {String.Join(',', array)}");

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (array[i] > array[j])
                    {
                        var tmp = array[i];
                        array[i] = array[j];
                        array[j] = tmp;
                    }
                }
            }
            
            Console.WriteLine($"Bubble Sorted: {String.Join(',', array)}");
            
        }
        
        public static void Insertion(int length = 10)
        {
            //int length = 10;
            int[] array = new int[length];
            var random = new Random();
            for (int i = 0; i < length; i++)
            {
                array[i] = random.Next(0,10);
            }
            
            // Console.WriteLine($"Insertion Source: {String.Join(',', array)}");

            for (int i = 1; i < length; i++)
            {
                var key = array[i];
                var flag = 0;
                for (int j = i - 1; j >= 0 && flag != 1;)
                {
                    if (key < array[j])
                    {
                        array[j + 1] = array[j];
                        j--;
                        array[j + 1] = key;
                    }
                    else flag = 1;
                }
            }
            
            // Console.WriteLine($"Insertion Sorted: {String.Join(',', array)}");
            
        }

        public static void Quick(int length = 10)
        {
            // int length = 5;
            int[] array = new int[length];
            var random = new Random(42);
            for (int i = 0; i < length; i++)
            {
                array[i] = random.Next(0,10);
            }
            
            //Console.WriteLine($"Quick Source: {String.Join(',', array)}");

            Sorts.QuickSortRecursive(array, 0, array.Length - 1);
            
            //Console.WriteLine($"Quick Sorted: {String.Join(',', array)}");
        }
        
        public static int[] QuickSortRecursive(int[] array, int leftIndex, int rightIndex)
        {
            // Console.WriteLine($"Source array: {String.Join(',', array)} LeftIndex:{leftIndex} RightIndex:{rightIndex}");
            var i = leftIndex;
            var j = rightIndex;
            var pivot = array[leftIndex];
            while (i <= j)
            {
                while (array[i] < pivot)
                {
                    i++;
                }
        
                while (array[j] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }

            // Console.WriteLine($"Source array after pivot ordering: {String.Join(',', array)}");
            // Console.WriteLine(Environment.NewLine);
            if (leftIndex < j)
                Sorts.QuickSortRecursive(array, leftIndex, j);
            if (i < rightIndex)
                Sorts.QuickSortRecursive(array, i, rightIndex);
            return array;
        }
    }
}