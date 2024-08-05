using System;
using System.Diagnostics;

namespace AlgoComplexity
{
    public class ArraysInteraction
    {
        public static void DoWork()
        {
            Stopwatch st = new Stopwatch();
            
            int dimension = 10000;
            var random = new Random();
            int[,] array = new int[dimension, dimension];

            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    array[i, j] = random.Next();
                }
            }
            
            st.Start();
            
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    var el = array[i, j];
                }
            }
            
            st.Stop();
            
            Console.WriteLine($"ArraysInteraction.DoWork [i,j] ms:{st.ElapsedMilliseconds} ticks:{st.ElapsedTicks}");
            
            st.Reset();
            
            st.Start();
            
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    var el = array[j, i];
                }
            }
            
            st.Stop();
            
            Console.WriteLine($"ArraysInteraction.DoWork [j,i] ms:{st.ElapsedMilliseconds} ticks:{st.ElapsedTicks}");

        }
    }
}