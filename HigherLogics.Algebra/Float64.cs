using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;

namespace HigherLogics.Algebra
{
    /// <summary>
    /// A native double.
    /// </summary>
    public readonly struct Float64 : IFloating<double, Float64>
    {
        public readonly double Magnitude;

        public Float64(double m) =>
            this.Magnitude = m;

        public Float64 One => Const(1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Float64 Const(double x) => new Float64(x);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Float64 Const(int x) => new Float64(x);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Sign() => Magnitude < 0 ? -1 : 1;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Float64 Negate() => new Float64(-Magnitude);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Float64 Add(Float64 rhs) => Magnitude + rhs.Magnitude;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Float64 Add(double rhs) => Magnitude + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Float64 Divide(double rhs) => Magnitude / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Float64 Divide(Float64 rhs) => Magnitude / rhs.Magnitude;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Float64 Reciprocal() => 1 / Magnitude;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Float64 Multiply(Float64 rhs) => Magnitude * rhs.Magnitude;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Float64 Multiply(double rhs) => Magnitude * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Float64 Subtract(Float64 rhs) => Magnitude - rhs.Magnitude;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Float64 Subtract(double rhs) => Magnitude - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Float64 SubtractFrom(double lhs) =>
            lhs - Magnitude;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Float64 Sin() => Math.Sin(Magnitude);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Float64 SinDeg() => Math.Sin(Magnitude * Math.PI / 180);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Float64 Cos() => Math.Cos(Magnitude);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Float64 CosDeg() => Math.Cos(Magnitude * Math.PI / 180);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Float64 Pow(int k) => Math.Pow(Magnitude, k);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Float64 Abs() => Math.Abs(Magnitude);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Float64 Exp() => Math.Exp(Magnitude);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Float64 Log() => Math.Log(Magnitude);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Float64(double x) =>
            new Float64(x);
    }
}
