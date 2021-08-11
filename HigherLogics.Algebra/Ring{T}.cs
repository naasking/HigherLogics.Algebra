using System;
using System.Collections.Generic;
using System.Text;

namespace HigherLogics.Algebra
{
    /// <summary>
    /// Abstract numerical type.
    /// </summary>
    /// <typeparam name="T">The number representation.</typeparam>
    public readonly struct Ring<T>
        where T : struct, IRing<T>
    {
        public readonly T Value;

        internal Ring(T value) =>
            this.Value = value;

        /// <summary>
        /// Compute an exponentiation.
        /// </summary>
        /// <param name="k">The exponent.</param>
        public Ring<T> Pow(int k) =>
            new Ring<T>(Value.Pow(k));

        /// <summary>
        /// Subtract two numbers.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Ring<T> operator -(Ring<T> x) =>
            new Ring<T>(x.Value.Negate());

        /// <summary>
        /// Add two numbers.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Ring<T> operator +(Ring<T> lhs, Ring<T> rhs) =>
            new Ring<T>(lhs.Value.Add(rhs.Value));

        /// <summary>
        /// Subtract two numbers.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Ring<T> operator -(Ring<T> lhs, Ring<T> rhs) =>
            new Ring<T>(lhs.Value.Subtract(rhs.Value));

        /// <summary>
        /// Multiply two numbers.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Ring<T> operator *(Ring<T> lhs, Ring<T> rhs) =>
            new Ring<T>(lhs.Value.Multiply(rhs.Value));

        /// <summary>
        /// Raise number to an exponent.
        /// </summary>
        public static Ring<T> operator ^(Ring<T> lhs, int rhs) =>
            lhs.Pow(rhs);

        public static implicit operator Ring<T>(int value)=>
            new Ring<T>(new T().Const(value));

        public static implicit operator Ring<T>(T value) =>
            new Ring<T>(value);
    }
}
