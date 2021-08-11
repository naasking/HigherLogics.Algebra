using System;
using System.Collections.Generic;
using System.Text;

namespace HigherLogics.Algebra
{
    /// <summary>
    /// A number accumulating a reverse mode expression.
    /// </summary>
    public readonly struct Tape<T> : IFloating<Tape<T>>
        where T : IFloating<T>
    {
        /// <summary>
        /// The output value.
        /// </summary>
        public readonly T Magnitude;

        /// <summary>
        /// The unique identifier for this node.
        /// </summary>
        internal readonly int Id;

        /// <summary>
        /// The node constructor.
        /// </summary>
        internal readonly CreateNode<T> CreateNode;

        const int IGNORE = 0;
        static T NONE = default(T);

        public Tape(T x, CreateNode<T> dx, int id)
        {
            this.Magnitude = x;
            this.Id = id;
            this.CreateNode = dx;
        }

        public Tape<T> One => new Tape<T>(Magnitude.One, CreateNode, IGNORE);

        public Tape<T> Const(double x) =>
            new Tape<T>(Magnitude.Const(x), CreateNode, IGNORE);

        public Tape<T> Const(int x) =>
            new Tape<T>(Magnitude.Const(x), CreateNode, IGNORE);

        public int Sign() => Magnitude.Sign();

        /// <summary>
        /// Compute the sin in radians.
        /// </summary>
        /// <returns></returns>
        public Tape<T> Sin() =>
            new Tape<T>(Magnitude.Sin(), CreateNode,
                        CreateNode(Id, Magnitude, IGNORE, NONE, MathOp.Sin));

        /// <summary>
        /// Compute the sin in degrees.
        /// </summary>
        public Tape<T> SinDeg() =>
            new Tape<T>(Magnitude.SinDeg(), CreateNode,
                        CreateNode(Id, Magnitude, IGNORE, NONE, MathOp.SinDeg));

        /// <summary>
        /// Compute the cosine in radians.
        /// </summary>
        public Tape<T> Cos() =>
            new Tape<T>(Magnitude.Cos(), CreateNode,
                        CreateNode(Id, Magnitude, IGNORE, NONE, MathOp.Cos));

        /// <summary>
        /// Compute the cosine in degrees.
        /// </summary>
        public Tape<T> CosDeg() =>
            new Tape<T>(Magnitude.CosDeg(), CreateNode,
                        CreateNode(Id, Magnitude, IGNORE, NONE, MathOp.CosDeg));

        /// <summary>
        /// Compute the logarithm.
        /// </summary>
        public Tape<T> Log() =>
            new Tape<T>(Magnitude.Log(), CreateNode,
                        CreateNode(Id, Magnitude, IGNORE, NONE, MathOp.Log));

        /// <summary>
        /// Compute an exponentiation.
        /// </summary>
        /// <param name="k">The exponent.</param>
        public Tape<T> Pow(int k) =>
            new Tape<T>(Magnitude.Pow(k), CreateNode,
                        CreateNode(Id, Magnitude, k, NONE, MathOp.Pow));

        /// <summary>
        /// Compute the absolute value.
        /// </summary>
        public Tape<T> Abs() =>
            new Tape<T>(Magnitude.Abs(), CreateNode,
                        CreateNode(Id, NONE, IGNORE, NONE, MathOp.Abs));

        /// <summary>
        /// Compute the exponential.
        /// </summary>
        public Tape<T> Exp() =>
            new Tape<T>(Magnitude.Exp(), CreateNode,
                        CreateNode(Id, Magnitude, IGNORE, NONE, MathOp.Exp));

        /// <summary>
        /// <inheritdoc cref="IEquatable{T}.Equals(T)"/>
        /// </summary>
        public bool Equals(Tape<T> other) =>
            Id == other.Id;

        ///// <summary>
        ///// <inheritdoc cref="IComparable{T}.CompareTo(T)"/>
        ///// </summary>
        //public int CompareTo(Tape<T> other) =>
        //    Magnitude.CompareTo(other.Magnitude);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override string ToString() => $"{Magnitude} + Xϵ";

        /// <summary>
        /// Negate the Reverse.
        /// </summary>
        public Tape<T> Negate() =>
            new Tape<T>(Magnitude.Negate(), CreateNode, CreateNode(Id, NONE, IGNORE, NONE, MathOp.Neg));

        /// <summary>
        /// Add two Tape<T>s.
        /// </summary>
        public Tape<T> Add(Tape<T> rhs) =>
            new Tape<T>(Magnitude.Add(rhs.Magnitude), CreateNode,
                        CreateNode(Id, NONE, rhs.Id, NONE, MathOp.Add));

        /// <summary>
        /// Add two Tape<T>s.
        /// </summary>
        public Tape<T> Add(double rhs) =>
            new Tape<T>(Magnitude.Add(rhs), CreateNode,
                       CreateNode(Id, NONE, IGNORE, NONE, MathOp.Add));

        /// <summary>
        /// Subtract two Tape<T>s.
        /// </summary>
        public Tape<T> Subtract(Tape<T> rhs) =>
            new Tape<T>(Magnitude.Subtract(rhs.Magnitude), CreateNode,
                        CreateNode(Id, NONE, rhs.Id, NONE, MathOp.Sub));

        /// <summary>
        /// Subtract from a Tape<T>.
        /// </summary>
        public Tape<T> Subtract(double rhs) =>
            new Tape<T>(Magnitude.Subtract(rhs), CreateNode,
                        CreateNode(Id, NONE, IGNORE, NONE, MathOp.Sub));

        /// <summary>
        /// Subtract a Tape<T> from a constant.
        /// </summary>
        public Tape<T> SubtractFrom(double rhs) =>
            new Tape<T>(Magnitude.SubtractFrom(rhs), CreateNode,
                        CreateNode(IGNORE, NONE, Id, NONE, MathOp.Sub));

        /// <summary>
        /// Multiply two Tape<T>s.
        /// </summary>
        public Tape<T> Multiply(Tape<T> rhs) =>
            new Tape<T>(Magnitude.Multiply(rhs.Magnitude), CreateNode,
                        CreateNode(Id, Magnitude, rhs.Id, rhs.Magnitude, MathOp.Mul));

        /// <summary>
        /// Multiply two Tape<T>s.
        /// </summary>
        public Tape<T> Multiply(double rhs) =>
            new Tape<T>(Magnitude.Multiply(rhs), CreateNode,
                        CreateNode(Id, NONE, IGNORE, Magnitude.Const(rhs), MathOp.Mul));

        /// <summary>
        /// Multiply two Tape<T>s.
        /// </summary>
        public Tape<T> Multiply(int rhs) =>
            new Tape<T>(Magnitude.Multiply(rhs), CreateNode,
                        CreateNode(Id, NONE, IGNORE, Magnitude.Const(rhs), MathOp.Mul));

        /// <summary>
        /// Divide two Tape<T>s.
        /// </summary>
        public Tape<T> Divide(Tape<T> rhs) =>
            new Tape<T>(Magnitude.Divide(rhs.Magnitude), CreateNode,
                        CreateNode(Id, Magnitude, rhs.Id, rhs.Magnitude, MathOp.Div));

        /// <summary>
        /// Divide two Tape<T>s.
        /// </summary>
        public Tape<T> Divide(double rhs) =>
            new Tape<T>(Magnitude.Divide(rhs), CreateNode,
                        CreateNode(Id, NONE, IGNORE, Magnitude.Const(rhs), MathOp.Div));

        /// <summary>
        /// Divide two Tape<T>s.
        /// </summary>
        public Tape<T> Divide(int rhs) =>
            new Tape<T>(Magnitude.Divide(rhs), CreateNode,
                        CreateNode(Id, NONE, IGNORE, Magnitude.Const(rhs), MathOp.Div));

        /// <summary>
        /// Take the reciprocal.
        /// </summary>
        /// <returns></returns>
        public Tape<T> Reciprocal() =>
            One.Divide(this);
    }
}
