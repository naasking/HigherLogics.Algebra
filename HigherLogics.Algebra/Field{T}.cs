using System;
using System.Collections.Generic;
using System.Text;

namespace HigherLogics.Algebra
{
    /// <summary>
    /// Abstract numerical type.
    /// </summary>
    /// <typeparam name="T">The number representation.</typeparam>
    public readonly struct Field<T>
        where T : struct, IField<T>
    {
        public readonly T Value;

        internal Field(T value) =>
            this.Value = value;

        /// <summary>
        /// Compute an exponentiation.
        /// </summary>
        /// <param name="k">The exponent.</param>
        public Field<T> Pow(int k) =>
            new Field<T>(Value.Pow(k));

        /// <summary>
        /// Subtract two numbers.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Field<T> operator -(Field<T> x) =>
            new Field<T>(x.Value.Negate());

        /// <summary>
        /// Add two numbers.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Field<T> operator +(Field<T> lhs, Field<T> rhs) =>
            new Field<T>(lhs.Value.Add(rhs.Value));

        /// <summary>
        /// Subtract two numbers.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Field<T> operator -(Field<T> lhs, Field<T> rhs) =>
            new Field<T>(lhs.Value.Subtract(rhs.Value));

        /// <summary>
        /// Multiply two numbers.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Field<T> operator *(Field<T> lhs, Field<T> rhs) =>
            new Field<T>(lhs.Value.Multiply(rhs.Value));

        /// <summary>
        /// Divide two numbers.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Field<T> operator /(Field<T> lhs, Field<T> rhs) =>
            new Field<T>(lhs.Value.Divide(rhs.Value));

        /// <summary>
        /// Raise number to an exponent.
        /// </summary>
        public static Field<T> operator ^(Field<T> lhs, int rhs) =>
            lhs.Pow(rhs);

        public static implicit operator Field<T>(int value) =>
            new Field<T>(new T().Const(value));

        public static implicit operator Field<T>(T value) =>
            new Field<T>(value);
    }
}
