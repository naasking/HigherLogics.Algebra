using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;

namespace HigherLogics.Algebra
{
    /// <summary>
    /// A native float.
    /// </summary>
    public readonly struct Float32 : IFloating<float, Float32>
    {
        public readonly float Magnitude;

        public Float32(float m) =>
            this.Magnitude = m;

        public Float32 One => Const(1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Float32 Const(float x) => new Float32(x);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Float32 Const(int x) => new Float32(x);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Sign() => Magnitude < 0 ? -1 : 1;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Float32 Negate() => new Float32(-Magnitude);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Float32 Add(Float32 rhs) => Magnitude + rhs.Magnitude;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Float32 Add(float rhs) => Magnitude + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Float32 Divide(float rhs) => Magnitude / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Float32 Divide(Float32 rhs) => Magnitude / rhs.Magnitude;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Float32 Reciprocal() => 1 / Magnitude;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Float32 Multiply(Float32 rhs) => Magnitude * rhs.Magnitude;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Float32 Multiply(float rhs) => Magnitude * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Float32 Subtract(Float32 rhs) => Magnitude - rhs.Magnitude;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Float32 Subtract(float rhs) => Magnitude - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Float32 SubtractFrom(float lhs) =>
            lhs - Magnitude;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Float32 Sin() => (float)Math.Sin(Magnitude);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Float32 SinDeg() => (float)Math.Sin(Magnitude * Math.PI / 180);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Float32 Cos() => (float)Math.Cos(Magnitude);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Float32 CosDeg() => (float)Math.Cos(Magnitude * Math.PI / 180);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Float32 Pow(int k) => (float)Math.Pow(Magnitude, k);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Float32 Abs() => Math.Abs(Magnitude);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Float32 Exp() => (float)Math.Exp(Magnitude);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Float32 Log() => (float)Math.Log(Magnitude);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Float32(float x) =>
            new Float32(x);
    }
}