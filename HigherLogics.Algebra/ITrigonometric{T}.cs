using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;

namespace HigherLogics.Algebra
{
    /// <summary>
    /// Trig functions.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ITrigonometric<T>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        T Sin();
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        T SinDeg();
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        T Cos();
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        T CosDeg();
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        T Exp();
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        T Log();
    }
}
