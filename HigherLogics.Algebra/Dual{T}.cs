using System;
using System.Collections.Generic;
using System.Text;

namespace HigherLogics.Algebra
{
    /// <summary>
    /// A two-dimensional commutative unital associative algebra.
    /// </summary>
    /// <remarks>
    /// https://en.wikipedia.org/wiki/Dual_number
    /// </remarks>
    public readonly struct Dual<T> : IFloating<Dual>
        where T : IFloating<T>
    {
        public readonly double Magnitude;
        public readonly T Epsilon;

        public Dual(double m, T d)
        {
            this.Magnitude = m;
            this.Epsilon = d;
        }

        public Dual<T> One => Const(1);

        public Dual<T> Const(double x) => new Dual<T>(x, default);

        public Dual<T> Const(int x) => new Dual<T>(x, default);

        public int Sign() => Magnitude < 0 ? -1 : 1;

        public Dual<T> Add(Dual<T> rhs) =>
            new Dual<T>(Magnitude + rhs.Magnitude, Epsilon.Add(rhs.Epsilon));

        public Dual<T> Negate() =>
            new Dual<T>(-Magnitude, Epsilon.Negate());

        public Dual<T> Add(double rhs) =>
            new Dual<T>(Magnitude + rhs, Epsilon.Add(1));

        public Dual<T> Divide(double rhs) =>
            new Dual<T>(Magnitude / rhs, Epsilon.Divide(rhs));

        public Dual<T> Divide(Dual<T> rhs) =>
            new Dual<T>(Magnitude / rhs.Magnitude,
                     Epsilon.Multiply(rhs.Magnitude).Subtract(rhs.Epsilon.Multiply(Magnitude)).Divide(rhs.Magnitude * rhs.Magnitude));

        public Dual<T> Reciprocal() =>
            new Dual<T>(1 / Magnitude, Epsilon.Divide(Magnitude * -Magnitude));

        public Dual<T> Multiply(Dual<T> rhs) =>
            new Dual<T>(Magnitude * rhs.Magnitude, Epsilon.Multiply(rhs.Magnitude).Add(rhs.Epsilon.Multiply(Magnitude));

        public Dual<T> Multiply(double rhs) =>
            new Dual<T>(Magnitude * rhs, Epsilon.Multiply(rhs));

        public Dual<T> Subtract(Dual<T> rhs) =>
            new Dual<T>(Magnitude - rhs.Magnitude, Epsilon.Subtract(rhs.Epsilon));

        public Dual<T> Subtract(double rhs) =>
            new Dual<T>(Magnitude - rhs, Epsilon);

        public Dual<T> SubtractFrom(double lhs) =>
            new Dual<T>(lhs - Magnitude, Epsilon.Negate());

        public Dual<T> Sin() =>
            new Dual<T>(Math.Sin(Magnitude), Epsilon.Multiply(Math.Cos(Magnitude)));

        public Dual<T> SinDeg() =>
            new Dual<T>(Math.Sin(Magnitude * Math.PI / 180), Epsilon * Math.Cos(Magnitude * Math.PI / 180));

        public Dual<T> Cos() =>
            new Dual<T>(Math.Cos(Magnitude), Epsilon * -Math.Sin(Magnitude));

        public Dual<T> CosDeg() =>
            new Dual<T>(Math.Cos(Magnitude * Math.PI / 180), Epsilon * -Math.Sin(Magnitude * Math.PI / 180));

        public Dual<T> Pow(int k) =>
            new Dual<T>(Math.Pow(Magnitude, k), k * Math.Pow(Magnitude, k - 1) * Epsilon);

        public Dual<T> Abs() =>
            new Dual<T>(Math.Abs(Magnitude), Magnitude < 0 ? -Epsilon : Epsilon);

        public Dual<T> Exp() =>
            new Dual<T>(Math.Exp(Magnitude), Math.Exp(Magnitude) * Epsilon);

        public Dual<T> Log() =>
            new Dual<T>(Math.Log(Magnitude), Epsilon * (1 / Magnitude));
    }
}
