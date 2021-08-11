using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;

namespace HigherLogics.Algebra
{
    public struct DenseRowMatrix<T>
        where T : IFloating<T>
    {
        public readonly int Rows;
        public readonly int Columns;
        internal readonly T[] items;

        public DenseRowMatrix(int rows, int columns, T[] items)
        {
            this.Rows = rows;
            this.Columns = columns;
            this.items = items;
        }

        public T this[int row, int column] =>
            items[Index(row, column)];

        int Index(int row, int column) =>
            Index(row, column, Rows); // row-major

        static int Index(int row, int column, int rows) =>
            column + row * rows; // row-major
            //row + column * Columns; // column-major

        public static DenseRowMatrix<T> operator +(DenseRowMatrix<T> lhs, DenseRowMatrix<T> rhs)
        {
            var x = new T[lhs.items.Length];
            for (int i = 0; i < x.Length; ++i)
            {
                x[i] = lhs.items[i].Add(rhs.items[i]);
            }
            return new DenseRowMatrix<T>(lhs.Rows, lhs.Columns, x);
        }

        public static DenseRowMatrix<T> operator *(DenseRowMatrix<T> lhs, DenseRowMatrix<T> rhs)
        {
            var m = new T[lhs.Rows * rhs.Columns];
            //for (int k = 0; k < m.Length; k += lhs.Columns)
            //{
            //    for (int i = 0; i < lhs.Rows; ++i)
            //    {
            //        T cell = default;
            //        for (int j = 0; j < lhs.Columns; ++j)
            //        {
            //            //cell = cell.Add(lhs[i, j].Multiply(rhs[j, i]));
            //            cell = cell.Add(lhs.items[i * lhs.Rows + j].Multiply(rhs.items[j * lhs.Rows + i]));
            //        }
            //        m[i + k] = cell;
            //    }
            //}
            // i := ranges over [0..lhs.length]
            // j := ranges over [0..rhs.length]
            // k := ranges over [0..m.length]
            //FIXME: validate this
            for (int i = 0, k = 0; i < m.Length; ++i)
            {
                var cell = lhs.items[0].Multiply(rhs.items[k]);
                for (int j = 0; j < lhs.items.Length; ++j, k += lhs.Columns)
                    cell = cell.Add(lhs.items[j].Multiply(rhs.items[k]));
                m[i] = cell;
                k = 0;
            }
            return new DenseRowMatrix<T>(lhs.Rows, rhs.Columns, m);
        }

        public DenseRowMatrix<T> Transpose()
        {
            var m = new T[items.Length];

            return new DenseRowMatrix<T>(Columns, Rows, m);
        }
    }
}
