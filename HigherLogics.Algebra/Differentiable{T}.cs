using System;
using System.Collections.Generic;
using System.Text;

namespace HigherLogics.Algebra
{
    /// <summary>
    /// Abstract numerical type.
    /// </summary>
    /// <typeparam name="T">The number representation.</typeparam>
    public readonly struct Differentiable<T>
        where T : struct, IFloating<T>
    {
        public readonly T Value;

        internal Differentiable(T value) =>
            this.Value = value;

        /// <summary>
        /// Compute the sin in radians.
        /// </summary>
        /// <returns></returns>
        public Differentiable<T> Sin() =>
            new Differentiable<T>(Value.Sin());

        /// <summary>
        /// Compute the sin in degrees.
        /// </summary>
        public Differentiable<T> SinDeg() =>
            new Differentiable<T>(Value.SinDeg());

        /// <summary>
        /// Compute the cosine in radians.
        /// </summary>
        public Differentiable<T> Cos() =>
            new Differentiable<T>(Value.Cos());

        /// <summary>
        /// Compute the cosine in degrees.
        /// </summary>
        public Differentiable<T> CosDeg() =>
            new Differentiable<T>(Value.CosDeg());

        /// <summary>
        /// Compute the logarithm.
        /// </summary>
        public Differentiable<T> Log() =>
            new Differentiable<T>(Value.Log());

        /// <summary>
        /// Compute an exponentiation.
        /// </summary>
        /// <param name="k">The exponent.</param>
        public Differentiable<T> Pow(int k) =>
            new Differentiable<T>(Value.Pow(k));

        /// <summary>
        /// Compute the absolute value.
        /// </summary>
        public Differentiable<T> Abs() =>
            new Differentiable<T>(Value.Abs());

        /// <summary>
        /// Compute the exponential.
        /// </summary>
        public Differentiable<T> Exp() =>
            new Differentiable<T>(Value.Exp());

        /// <summary>
        /// Add two numbers.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Differentiable<T> operator +(Differentiable<T> lhs, Differentiable<T> rhs) =>
            new Differentiable<T>(lhs.Value.Add(rhs.Value));

        /// <summary>
        /// Subtract two numbers.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Differentiable<T> operator -(Differentiable<T> lhs, Differentiable<T> rhs) =>
            new Differentiable<T>(lhs.Value.Subtract(rhs.Value));

        /// <summary>
        /// Multiply two numbers.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Differentiable<T> operator *(Differentiable<T> lhs, Differentiable<T> rhs) =>
            new Differentiable<T>(lhs.Value.Multiply(rhs.Value));

        /// <summary>
        /// Divide two numbers.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Differentiable<T> operator /(Differentiable<T> lhs, Differentiable<T> rhs) =>
            new Differentiable<T>(lhs.Value.Divide(rhs.Value));

        /// <summary>
        /// Add two numbers.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Differentiable<T> operator +(Differentiable<T> lhs, double rhs) =>
            new Differentiable<T>(lhs.Value.Add(rhs));

        /// <summary>
        /// Subtract two numbers.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Differentiable<T> operator -(Differentiable<T> lhs, double rhs) =>
            new Differentiable<T>(lhs.Value.Subtract(rhs));

        /// <summary>
        /// Multiply two numbers.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Differentiable<T> operator *(Differentiable<T> lhs, double rhs) =>
            new Differentiable<T>(lhs.Value.Multiply(rhs));

        /// <summary>
        /// Divide two numbers.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Differentiable<T> operator /(Differentiable<T> lhs, double rhs) =>
            new Differentiable<T>(lhs.Value.Divide(rhs));

        /// <summary>
        /// Add two numbers.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Differentiable<T> operator +(double lhs, Differentiable<T> rhs) =>
            rhs + lhs;

        /// <summary>
        /// Subtract two numbers.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Differentiable<T> operator -(double lhs, Differentiable<T> rhs) =>
            new Differentiable<T>(rhs.Value.SubtractFrom(lhs));

        /// <summary>
        /// Multiply two numbers.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Differentiable<T> operator *(double lhs, Differentiable<T> rhs) =>
            rhs * lhs;

        /// <summary>
        /// Raise number to an exponent.
        /// </summary>
        public static Differentiable<T> operator ^(Differentiable<T> lhs, int rhs) =>
            lhs.Pow(rhs);

        ///// <summary>
        ///// Divide two numbers.
        ///// </summary>
        ///// <param name="lhs"></param>
        ///// <param name="rhs"></param>
        ///// <returns></returns>
        //public static Number<T> operator /(double lhs, Number<T> rhs) =>
        //    new Number<T>()

        public static implicit operator Differentiable<T>(T value) =>
            new Differentiable<T>(value);
    }
}
