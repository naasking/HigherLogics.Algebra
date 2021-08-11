using System;
using System.Collections.Generic;
using System.Numerics;

namespace HigherLogics.Algebra
{
    /// <summary>
    /// An interface describing an arithmetic over <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type being operated on</typeparam>
    /// <remarks>
    /// This defines the core arithmetic kernel for all operations.
    /// </remarks>
    public interface IFloating<T> : IAdditive<T>, IRing<T>, IField<T>, IAbsolute<T>, ITrigonometric<T>
    {
        /// <summary>
        /// Lift a double to a <typeparamref name="T"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        T Const(double value);
        T Add(double rhs);
        T Subtract(double rhs);
        T SubtractFrom(double lhs);
        T Multiply(double rhs);
        T Divide(double rhs);
    }
}
