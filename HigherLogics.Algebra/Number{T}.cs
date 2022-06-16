using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;

namespace HigherLogics.Algebra
{
    /// <summary>
    /// A general number type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public readonly struct Number<T>
        where T : struct, IAdditive<T>, IRing<T>, IField<T>
    {
        public readonly T Value;

        internal Number(T value) =>
            this.Value = value;

        /// <summary>
        /// Subtract two numbers.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Number<T> operator -(Number<T> x) =>
            new Number<T>(x.Value.Negate());

        /// <summary>
        /// Add two numbers.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Number<T> operator +(Number<T> lhs, Number<T> rhs) =>
            new Number<T>(lhs.Value.Add(rhs.Value));

        /// <summary>
        /// Add two numbers.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Number<T> operator *(Number<T> lhs, Number<T> rhs) =>
            new Number<T>(lhs.Value.Multiply(rhs.Value));

        /// <summary>
        /// Add two numbers.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Number<T> operator /(Number<T> lhs, Number<T> rhs) =>
            new Number<T>(lhs.Value.Divide(rhs.Value));

        /// <summary>
        /// Subtract two numbers.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Number<T> operator -(Number<T> lhs, Number<T> rhs) =>
            new Number<T>(lhs.Value.Subtract(rhs.Value));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Number<T>(T value) =>
            new Number<T>(value);
    }
}
