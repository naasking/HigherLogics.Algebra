using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;

namespace HigherLogics.Algebra
{
    /// <summary>
    /// A commutative ring.
    /// </summary>
    /// <typeparam name="T">The underlying representation.</typeparam>
    /// <remarks>
    /// Identities:
    /// <code>
    /// not (isZero b)  ==>  (a * b) / b === a
    /// not (isZero a)  ==>  a * recip a === one
    /// </code>
    /// </remarks>
    public interface IField<T> : IRing<T>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        T Divide(T rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        T Reciprocal();
    }
}
