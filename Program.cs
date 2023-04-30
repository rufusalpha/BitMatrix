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
            Console.WriteLine("Hello, World!");

            var m = new BitMatrix(2, 2, new int[] { 1, 0, 0, 1 });
            Console.WriteLine(m);

            m = new BitMatrix(2, 2, 1, 0, 0, 0);
            Console.WriteLine(m);
        }
       
    }
}