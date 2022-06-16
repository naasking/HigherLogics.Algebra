using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;

namespace HigherLogics.Algebra
{
    /// <summary>
    /// A ring supporting absolute value operation.
    /// </summary>
    /// <typeparam name="T">The underlying representation.</typeparam>
    /// <remarks>
    /// Identities:
    /// <code>
    ///                     a * b === b * a
    /// a /= 0  =>  abs(signum a) === 1
    ///          abs a * signum a === a
    /// </code>
    /// </remarks>
    public interface IAbsolute<T> : IRing<T>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        T Abs();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        int Sign();
    }
}
