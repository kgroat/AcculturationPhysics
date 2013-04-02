namespace SharpPhysics.Physics.Api.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class Line : ILine
    {
        protected Vector _Start, _End, _Self;

        protected IPolygon _Bounds;

        internal Vector Start
        {
            get
            {
                return this._Start;
            }
            set
            {
                if (this._Start != value)
                {
                    this._Start = value;
                    this._Self = this._End - this._Start;
                }
            }
        }

        internal Vector End
        {
            get
            {
                return this._End;
            }
            set
            {
                if (this._End != value)
                {
                    this._End = value;
                    this._Self = this._End - this._Start;
                }
            }
        }

        internal IPolygon Bounds
        {
            get
            {
                return this._Bounds;
            }
        }

        IVector ILine.Start
        {
            get { return this._Start; }
        }

        IVector ILine.End
        {
            get { return this._End; }
        }

        public float X
        {
            get { return this._Self.X; }
        }

        public float Y
        {
            get { return this._Self.Y; }
        }

        public float Length
        {
            get { return this._Self.Length; }
        }

        internal Line(Vector Start, Vector End)
        {
            this._Start = Start;
            this._End = End;
            this._Self = this._End - this._Start;
            this._Bounds = new Triangle(this._Start, this._Start, this._End);
        }

        internal Line(float startX, float startY, float endX, float endY)
        {
            this._Start = new Vector(startX, startY);
            this._End = new Vector(endX, endY);
            this._Self = this._End - this._Start;
            this._Bounds = new Triangle(this._Start, this._Start, this._End);
        }

        public virtual bool Intersects(ILine intersector)
        {
            if (intersector is Bezier3 || intersector is Bezier4)
            {
                return intersector.Intersects(this);
            }
            var P = new Vector(-intersector.Y, intersector.X);
            var h = ((-this.Start + intersector.Start) * P) / (this * P);
            return h >= 0 && h <= 1;
        }

        public virtual Vector PointOfIntersection(ILine intersector)
        {
            var P = new Vector(-intersector.Y, intersector.X);
            var h = ((-this.Start + intersector.Start) * P) / (this * P);
            return this.Start + this * h;
        }

        internal virtual Vector PointAtSection(float t)
        {
            var u = 1 - t;
            return (this.Start * u) + (this.End * t);
        }

        internal virtual Line[] SplitAt(float t)
        {
            var mid = this.PointAtSection(t);
            return new Line[] { new Line(Start, mid), new Line(mid, End) };
        }

        internal Vector Add(Vector addend)
        {
            return this._Self.Add(addend);
        }

        internal Vector Subtract(Vector addend)
        {
            return this._Self.Subtract(addend);
        }

        internal float Dot(Vector addend)
        {
            return this._Self.Dot(addend);
        }

        internal Vector Multiply(float addend)
        {
            return this._Self.Multiply(addend);
        }

        internal Vector Divide(float addend)
        {
            return this._Self.Divide(addend);
        }

        internal Vector Normalize()
        {
            return this._Self.Normalize();
        }

        bool ILine.Intersects(ILine intersector)
        {
            return this.Intersects(intersector);
        }

        IVector ILine.PointOfIntersection(ILine intersector)
        {
            return this.PointOfIntersection(intersector);
        }

        IVector ILine.PointAtSection(float t)
        {
            return this.PointAtSection(t);
        }

        ILine[] ILine.SplitAt(float t)
        {
            return this.SplitAt(t);
        }

        IVector IVector.Add(IVector addend)
        {
            return this._Self.Add(addend);
        }

        IVector IVector.Subtract(IVector subtrahend)
        {
            return this._Self.Subtract(subtrahend);
        }

        float IVector.Dot(IVector other)
        {
            return this._Self.Dot(other);
        }

        IVector IVector.Multiply(float multiplicand)
        {
            return this._Self.Multiply(multiplicand);
        }

        IVector IVector.Divide(float dividend)
        {
            return this._Self.Divide(dividend);
        }

        IVector IVector.Normalize()
        {
            return this._Self.Normalize();
        }

        public static Vector operator +(Line addend1, IVector addend2)
        {
            return addend1._Self.Add(addend2);
        }

        public static Vector operator -(Line minuend, IVector subtrahend)
        {
            return minuend._Self.Subtract(subtrahend);
        }

        public static Vector operator *(Line multiplicand, float multiplier)
        {
            return multiplicand.Multiply(multiplier);
        }

        public static Vector operator /(Line dividend, float divisor)
        {
            return dividend.Divide(divisor);
        }

        public static float operator *(Line multiplicand, IVector multiplier)
        {
            return multiplicand._Self.Dot(multiplier);
        }

        public static Vector operator -(Line origin)
        {
            return new Vector(-origin._Self.X, -origin._Self.Y);
        }

        public static bool operator ==(Line origin, IVector other)
        {
            return origin.Equals(other);
        }

        public static bool operator !=(Line origin, IVector other)
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
