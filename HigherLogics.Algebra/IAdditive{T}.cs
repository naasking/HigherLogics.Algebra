using System;
using System.Collections.Generic;
using System.Text;

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
        T Add(T rhs);

        T Subtract(T rhs);

        T Negate();
    }
}
