using System;
using System.Collections.Generic;
using System.Text;

namespace HigherLogics.Algebra
{
    /// <summary>
    /// Math operator.
    /// </summary>
    public enum MathOp
    {
        //FIXME: add tan, asin/acos/atan, sinh/cosh/tanh, asinh/acosh/atanh, sqrt?
        Var = 0,
        Const,
        Neg,
        Sign,
        Add,
        Sub,
        Mul,
        Div,
        Pow,
        Exp,
        Log,
        Abs,
        Sin,
        SinDeg,
        Cos,
        CosDeg,
    }
}
