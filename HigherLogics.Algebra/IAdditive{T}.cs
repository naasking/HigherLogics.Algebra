using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;

namespace HigherLogics.Algebra
{
    /// <summary>
    /// Interface for additive objects.
    /// </summary>
    /// <typeparam name="T">The underlying representation.</typeparam>
    /// <remarks>
    /// Identities:
    /// <code>
    ///        a + b === b + a
    ///  (a + b) + c === a + (b + c)
    ///     zero + a === a
    /// a + negate a === 0
    /// </code>
    /// </remarks>
    public interface IAdditive<T>
    {
        //FIXME: might not be the best idea to specify inlining on the interface. Since
        //the idea is that most clients should be structs, those will get specialized anyway,
        //so the inlining annotations on the implementations of those methods might be
        //sufficient. More complex types, like large matrices, arguably shouldn't be
        //inlined in this fashion.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        T Add(T rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        T Subtract(T rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        T Negate();
    }
}
