using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;

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
    }

    /// <summary>
    /// An interface describing an arithmetic over <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type being operated on</typeparam>
    /// <remarks>
    /// This defines the core arithmetic kernel for all operations.
    /// </remarks>
    public interface IFloating<TBase, T> : IFloating<T>
        where TBase : struct
    {
        /// <summary>
        /// Lift a double to a <typeparamref name="T"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        T Const(TBase value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        T Add(TBase rhs);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        T Subtract(TBase rhs);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        T SubtractFrom(TBase lhs);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        T Multiply(TBase rhs);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        T Divide(TBase rhs);
    }
}
