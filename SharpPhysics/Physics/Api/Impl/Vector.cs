namespace SharpPhysics.Physics.Api.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class Vector : IVector
    {
        private float _X, _Y, _Length;

        internal float X
        {
            get
            {
                return _X;
            }
            set
            {
                if (_X != value)
                {
                    _X = value;
                    this._Length = (float)Math.Sqrt(this._X * this._X + this._Y * this._Y);
                }
            }
        }

        internal float Y
        {
            get
            {
                return _Y;
            }
            set
            {
                if (_Y != value)
                {
                    _Y = value;
                    this._Length = (float)Math.Sqrt(this._X * this._X + this._Y * this._Y);
                }
            }
        }

        float IVector.X
        {
            get { return this._X; }
        }

        float IVector.Y
        {
            get { return this._Y; }
        }

        public float Length
        {
            get { return _Length; }
        }

        internal Vector()
        {
            this._X = this._Y = this._Length = 0;
        }

        internal Vector(float X, float Y)
        {
            this._X = X;
            this._Y = Y;
            this._Length = (float)Math.Sqrt(this._X * this._X + this._Y * this._Y);
        }

        internal float Cross(IVector other)
        {
            return this.X * other.Y - this.Y * other.X;
        }

        public Vector Add(IVector addend)
        {
            return new Vector(X + addend.X, Y + addend.Y);
        }

        public Vector Subtract(IVector subtrahend)
        {
            return new Vector(X - subtrahend.X, Y - subtrahend.Y);
        }

        public float Dot(IVector other)
        {
            return X * other.X + Y * other.Y;
        }

        public Vector Multiply(float multiplicand)
        {
            return new Vector(X * multiplicand, Y * multiplicand);
        }

        public Vector Divide(float dividend)
        {
            return new Vector(X / dividend, Y / dividend);
        }

        public Vector Normalize()
        {
            return this / _Length;
        }

        IVector IVector.Add(IVector addend)
        {
            return this.Add(addend);
        }

        IVector IVector.Subtract(IVector subtrahend)
        {
            return this.Subtract(subtrahend);
        }

        IVector IVector.Multiply(float multiplicand)
        {
            return this.Multiply(multiplicand);
        }

        IVector IVector.Divide(float dividend)
        {
            return this.Divide(dividend);
        }

        IVector IVector.Normalize()
        {
            return this.Normalize();
        }

        public override int GetHashCode()
        {
            return (int)(_X + _Y * 199933);
        }

        public override bool Equals(object obj)
        {
            var other = obj as IVector;
            if (other != null)
            {
                return this.X == other.X && this.Y == other.Y;
            }
            return false;
        }

        public static Vector operator +(Vector addend1, IVector addend2)
        {
            return addend1.Add(addend2);
        }

        public static Vector operator -(Vector minuend, IVector subtrahend)
        {
            return minuend.Subtract(subtrahend);
        }

        public static Vector operator *(Vector multiplicand, float multiplier)
        {
            return multiplicand.Multiply(multiplier);
        }

        public static Vector operator /(Vector dividend, float divisor)
        {
            return dividend.Divide(divisor);
        }

        public static Vector operator *(float multiplicand, Vector multiplier)
        {
            return multiplier.Multiply(multiplicand);
        }

        public static Vector operator /(float dividend, Vector divisor)
        {
            return divisor.Divide(dividend);
        }

        public static float operator *(Vector multiplicand, IVector multiplier)
        {
            return multiplicand.Dot(multiplier);
        }

        public static Vector operator -(Vector origin)
        {
            return new Vector(-origin._X, -origin._Y);
        }

        public static bool operator ==(Vector origin, IVector other)
        {
            return origin.Equals(other);
        }

        public static bool operator !=(Vector origin, IVector other)
        {
            return !origin.Equals(other);
        }


        public System.Drawing.PointF ToPoint()
        {
            return new System.Drawing.PointF(X, Y);
        }


        public System.Drawing.SizeF ToSize()
        {
            return new System.Drawing.SizeF(X, Y);
        }
    }
}
