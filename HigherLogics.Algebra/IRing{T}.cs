using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;

namespace HigherLogics.Algebra
{
    /// <summary>
    /// A ring algebra.
    /// </summary>
    /// <typeparam name="T">The underlying representation.</typeparam>
    /// <remarks>
    /// Identities:
    /// <code>
    ///   a * (b * c) === (a * b) * c
    ///        one* a === a
    ///        a* one === a
    ///    a* (b + c) === a* b + a* c
    /// </code>
    /// </remarks>
    public interface IRing<T> : IAdditive<T>
    {
        T One { get; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        T Const(int value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        T Multiply(T rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        T Pow(int k);

        //FIXME: add square?
    }
}
