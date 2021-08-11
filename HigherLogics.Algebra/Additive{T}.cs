using System;
using System.Collections.Generic;
using System.Text;

namespace HigherLogics.Algebra
{
    /// <summary>
    /// Abstract numerical type.
    /// </summary>
    /// <typeparam name="T">The number representation.</typeparam>
    public readonly struct Additive<T>
        where T : struct, IAdditive<T>
    {
        public readonly T Value;

        internal Additive(T value) =>
            this.Value = value;

        /// <summary>
        /// Subtract two numbers.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Additive<T> operator -(Additive<T> x) =>
            new Additive<T>(x.Value.Negate());

        /// <summary>
        /// Add two numbers.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Additive<T> operator +(Additive<T> lhs, Additive<T> rhs) =>
            new Additive<T>(lhs.Value.Add(rhs.Value));

        /// <summary>
        /// Subtract two numbers.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Additive<T> operator -(Additive<T> lhs, Additive<T> rhs) =>
            new Additive<T>(lhs.Value.Subtract(rhs.Value));

        public static implicit operator Additive<T>(T value) =>
            new Additive<T>(value);
    }
}
