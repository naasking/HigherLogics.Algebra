using System;
using System.Collections.Generic;
using System.Text;

namespace HigherLogics.Algebra
{
    /// <summary>
    /// Trig functions.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ITrigonometric<T>
    {
        T Sin();
        T SinDeg();
        T Cos();
        T CosDeg();
        T Exp();
        T Log();
    }
}
