// See https://aka.ms/new-console-template for more information
using System;
using System.Collections;
using BitMatrixSpace;

namespace Program
{
    internal class Program
    {
        static void Main()
        {
            // konstruktor BitMatrix(int, int, params int[])
            // macierz 2x2, komplet danych w tablicy
            var m = new BitMatrix(2, 2, new int[] { 1, 0, 0, 1 });
            Console.WriteLine(m);

            m = new BitMatrix(2, 2, 1, 0, 0, 0);
            Console.WriteLine(m);

            // konstruktor BitMatrix(int, int, params int[])
            // macierz 2x2, za dużo danych w tablicy
            m = new BitMatrix(2, 2, 1, 0, 0, 1, 1, 1, 0);
            Console.WriteLine(m);

            // macierz 3x2, za mało danych w tablicy
            m = new BitMatrix(3, 2, 1, 0, 0, 1, 1);
            Console.WriteLine(m);

            // konstruktor BitMatrix(int[,])
            int[,] arr = new int[,] { { 1, 0, 1 }, { 0, 1, 1 } };
            m = new BitMatrix(arr);
            Console.WriteLine(arr.GetLength(0) == m.NumberOfRows);
            Console.WriteLine(arr.GetLength(1) == m.NumberOfColumns);
            Console.Write(m.ToString());
        }
       
    }
}