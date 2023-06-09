﻿using System;
using System.Collections;
using System.Runtime.CompilerServices;

// prostokątna macierz bitów o wymiarach m x n

namespace BitMatrixSpace
{
    public partial class BitMatrix
    {
        private BitArray data;
        public int NumberOfRows { get; }
        public int NumberOfColumns { get; }
        public bool IsReadOnly => false;

        public bool this[int i, int j]
        {
            get => data[i * NumberOfColumns + j];
            set => data[i * NumberOfColumns + j] = value;
        }

        // tworzy prostokątną macierz bitową wypełnioną `defaultValue`
        public BitMatrix(int numberOfRows, int numberOfColumns, int defaultValue = 0)
        {
            if (numberOfRows < 1 || numberOfColumns < 1)
                throw new ArgumentOutOfRangeException("Incorrect size of matrix");
            data = new BitArray(numberOfRows * numberOfColumns, BitToBool(defaultValue));
            NumberOfRows = numberOfRows;
            NumberOfColumns = numberOfColumns;
        }

        public BitMatrix(int numberOfRows, int numberOfColumns, params int[] bits)
        {
            NumberOfRows = numberOfRows;
            NumberOfColumns = numberOfColumns;
            data = new BitArray(numberOfRows * numberOfColumns, false);

           if( bits is not null && bits.Length > 1)
            {
                for (int i = 0; i < numberOfRows * numberOfColumns; i++)
                {
                    data[i] = i < bits.Length ? BitToBool(bits[i]) : false;
                }
            }
        }

        public BitMatrix(int[,] bits)
        {
            if (bits is null)
                throw new NullReferenceException();
            if (bits.Length <= 0)
                throw new ArgumentOutOfRangeException();

            NumberOfRows = bits.GetLength(0);
            NumberOfColumns = bits.GetLength(1);

            data = new BitArray(NumberOfRows * NumberOfColumns, false);

            int index = 0;
            for (int i = 0; i < NumberOfRows; i++)
            {
                for (int j = 0; j < NumberOfColumns; j++)
                    data[index++] = BitToBool(bits[i, j]);
            }
        }

        public BitMatrix(bool[,] bits)
        {
            if (bits is null)
                throw new NullReferenceException();
            if (bits.Length <= 0)
                throw new ArgumentOutOfRangeException();

            NumberOfRows = bits.GetLength(0);
            NumberOfColumns = bits.GetLength(1);

            data = new BitArray(NumberOfRows * NumberOfColumns, false);

            int index = 0;
            for (int i = 0; i < NumberOfRows; i++)
            {
                for (int j = 0; j < NumberOfColumns; j++)
                    data[index++] = bits[i, j];
            }
        }

        public static int BoolToBit(bool boolValue) => boolValue ? 1 : 0;
        public static bool BitToBool(int bit) => bit != 0;

        // implementacja ToString() wykonana w poprzednim kroku
        public override string ToString()
        {
            string output = "";
            for (int i = 0; i < NumberOfRows; i++)
            {
                for (int j = 0; j < NumberOfColumns; j++)
                {
                    output += BoolToBit(data[i * NumberOfColumns + j]);
                }
                output += "\n";
            }
            return output;
        }
    }
}
