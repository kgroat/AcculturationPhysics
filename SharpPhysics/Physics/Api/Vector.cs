namespace SharpPhysics.Physics.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Vector
    {
        protected float _X, _Y, _Length;

        public float X
        {
            get
            {
                return _X;
            }
            internal set
            {
                if (_X != value)
                {
                    _X = value;
                    this._Length = (float)Math.Sqrt(this._X * this._X + this._Y * this._Y);
                }
            }
        }

        public float Y
        {
            get
            {
                return _Y;
            }
            internal set
            {
                if (_Y != value)
                {
                    _Y = value;
                    this._Length = (float)Math.Sqrt(this._X * this._X + this._Y * this._Y);
                }
            }
        }

        public float Length
        {
            get { return _Length; }
        }

        public Vector()
        {
            this._X = this._Y = this._Length = 0;
        }

        public Vector(float X, float Y)
        {
            this._X = X;
            this._Y = Y;
            this._Length = (float)Math.Sqrt(this._X * this._X + this._Y * this._Y);
        }

        public virtual float Cross(Vector other)
        {
            return this.X * other.Y - this.Y * other.X;
        }

        public virtual Vector Add(Vector addend)
        {
            return new Vector(X + addend.X, Y + addend.Y);
        }

        public virtual Vector Subtract(Vector subtrahend)
        {
            return new Vector(X - subtrahend.X, Y - subtrahend.Y);
        }

        public virtual float Dot(Vector other)
        {
            return X * other.X + Y * other.Y;
        }

        public virtual Vector Multiply(float multiplicand)
        {
            return new Vector(X * multiplicand, Y * multiplicand);
        }

        public virtual Vector Divide(float dividend)
        {
            return new Vector(X / dividend, Y / dividend);
        }

        public virtual System.Drawing.PointF ToPoint()
        {
            return new System.Drawing.PointF(X, Y);
        }

        public virtual System.Drawing.SizeF ToSize()
        {
            return new System.Drawing.SizeF(X, Y);
        }

        public virtual Vector Normalize()
        {
            return this / _Length;
        }

        public override int GetHashCode()
        {
            return (int)(_X + _Y * 199933);
        }

        public override bool Equals(object obj)
        {
            var other = obj as Vector;
            if (other != null)
            {
                return this.X == other.X && this.Y == other.Y;
            }
            return false;
        }

        public static Vector operator +(Vector addend1, Vector addend2)
        {
            return addend1.Add(addend2);
        }

        public static Vector operator -(Vector minuend, Vector subtrahend)
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

        public static float operator *(Vector multiplicand, Vector multiplier)
        {
            return multiplicand.Dot(multiplier);
        }

        public static Vector operator -(Vector origin)
        {
            return new Vector(-origin._X, -origin._Y);
        }

        public static bool operator ==(Vector origin, Vector other)
        {
            return origin.Equals(other);
        }

        public static bool operator !=(Vector origin, Vector other)
        {
            return !origin.Equals(other);
        }
    }
}
