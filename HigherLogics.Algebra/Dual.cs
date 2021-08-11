using System;
using System.Collections.Generic;
using System.Text;

namespace HigherLogics.Algebra
{
    /// <summary>
    /// A dual number, value + derivative.
    /// </summary>
    public readonly struct Dual : IFloating<Dual>
    {
        public readonly double Magnitude;
        public readonly double Derivative;

        public Dual(double m, double d)
        {
            this.Magnitude = m;
            this.Derivative = d;
        }

        public Dual One => Const(1);

        public Dual Const(double x) => new Dual(x, 0);

        public Dual Const(int x) => new Dual(x, 0);

        public int Sign() => Magnitude < 0 ? -1 : 1;

        public Dual Add(Dual rhs) =>
            new Dual(Magnitude + rhs.Magnitude, Derivative + rhs.Derivative);

        public Dual Negate() =>
            new Dual(-Magnitude, -Derivative);

        public Dual Add(double rhs) =>
            new Dual(Magnitude + rhs, 1 + Derivative);

        public Dual Divide(double rhs) =>
            new Dual(Magnitude / rhs, Derivative / rhs);

        public Dual Divide(Dual rhs) =>
            new Dual(Magnitude / rhs.Magnitude,
                     (Derivative * rhs.Magnitude - Magnitude * rhs.Derivative) / (rhs.Magnitude * rhs.Magnitude));

        public Dual Reciprocal() =>
            new Dual(1 / Magnitude, -Derivative / (Magnitude * Magnitude));

        public Dual Multiply(Dual rhs) =>
            new Dual(Magnitude * rhs.Magnitude, Derivative * rhs.Magnitude + rhs.Derivative * Magnitude);

        public Dual Multiply(double rhs) =>
            new Dual(Magnitude * rhs, Derivative * rhs);

        public Dual Subtract(Dual rhs) =>
            new Dual(Magnitude - rhs.Magnitude, Derivative - rhs.Derivative);

        public Dual Subtract(double rhs) =>
            new Dual(Magnitude - rhs, Derivative);

        public Dual SubtractFrom(double lhs) =>
            new Dual(lhs - Magnitude, -Derivative);

        public Dual Sin() =>
            new Dual(Math.Sin(Magnitude), Derivative * Math.Cos(Magnitude));

        public Dual SinDeg() =>
            new Dual(Math.Sin(Magnitude * Math.PI / 180), Derivative * Math.Cos(Magnitude * Math.PI / 180));

        public Dual Cos() =>
            new Dual(Math.Cos(Magnitude), Derivative * -Math.Sin(Magnitude));

        public Dual CosDeg() =>
            new Dual(Math.Cos(Magnitude * Math.PI / 180), Derivative * -Math.Sin(Magnitude * Math.PI / 180));

        public Dual Pow(int k) =>
            new Dual(Math.Pow(Magnitude, k), k * Math.Pow(Magnitude, k - 1) * Derivative);

        public Dual Abs() =>
            new Dual(Math.Abs(Magnitude), Magnitude < 0 ? -Derivative : Derivative);

        public Dual Exp() =>
            new Dual(Math.Exp(Magnitude), Math.Exp(Magnitude) * Derivative);

        public Dual Log() =>
            new Dual(Math.Log(Magnitude), Derivative * (1 / Magnitude));
    }
}
