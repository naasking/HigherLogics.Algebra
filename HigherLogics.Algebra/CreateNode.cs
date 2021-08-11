using System;
using System.Collections.Generic;
using System.Text;

namespace HigherLogics.Algebra
{
    /// <summary>
    /// Record a node in the trace.
    /// </summary>
    /// <returns>The index of the new node.</returns>
    public delegate int CreateNode<T>(int id1, T dx1, int id2, T dx2, MathOp op);
}
