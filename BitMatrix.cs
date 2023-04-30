using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// prostokątna macierz bitów o wymiarach m x n

namespace BitMatrixSpace
{
    public partial class BitMatrix : IEquatable<BitMatrix>, IEnumerable<int>
    {
        private BitArray data;
        public int NumberOfRows { get; }
        public int NumberOfColumns { get; }
        public bool IsReadOnly => false;

        public int this[int i, int j]
        {
            get
            {
                if (i >= NumberOfRows || j >= NumberOfColumns || i<0 || j < 0)
                    throw new IndexOutOfRangeException();

                return BoolToBit( data[i * NumberOfRows + j] );
            }
            set
            {
                if (i >= NumberOfRows || j >= NumberOfColumns || i < 0 || j < 0)
                    throw new IndexOutOfRangeException();

                data[i * NumberOfRows + j] = BitToBool(value);
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < NumberOfRows * NumberOfColumns; i++)
                yield return BoolToBit(data[i]);
        }
        IEnumerator<int> IEnumerable<int>.GetEnumerator() => (IEnumerator<int>)GetEnumerator();

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

        public bool Equals(BitMatrix other)
        {
            if (ReferenceEquals(this, other))
                return true;
            if (ReferenceEquals(other, null))
                return false;
            if (NumberOfColumns != other.NumberOfColumns || NumberOfRows != other.NumberOfRows)
                return false;

            for (int i = 0; i < NumberOfRows * NumberOfColumns; i++)
            {
                if (data[i] != other.data[i])
                    return false;
            }

            return true;
        }

        public override bool Equals(object obj) => Equals(obj as BitMatrix);
        public override int GetHashCode() => data.GetHashCode();
        public static bool operator ==(BitMatrix left, BitMatrix right) => Equals(left, right);
        public static bool operator !=(BitMatrix left, BitMatrix right) => !Equals(left, right);

    }
}
