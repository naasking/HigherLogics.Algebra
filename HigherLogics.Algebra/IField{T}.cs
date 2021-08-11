using System;
using System.Collections.Generic;
using System.Text;

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
        T Divide(T rhs);

        T Reciprocal();
    }
}
