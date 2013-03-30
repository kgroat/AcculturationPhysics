namespace SharpPhysics.Api.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class Line : ILine
    {
        private Vector _Start, _End, _Self;

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

        internal Line(Vector Start, Vector End)
        {
            this._Start = Start;
            this._End = End;
            this._Self = this._End - this._Start;
        }

        public bool Intersects(Line intersector)
        {
            var P = new Vector(-this.Y, this.X);
            var h = ((Start - intersector.Start) * P) / (intersector._Self * P);
            return h > 0 && h < 1;
        }

        public Vector PointOfIntersection(Line intersector)
        {
            var P = new Vector(-this.Y, this.X);
            var h = ((this.Start - intersector.Start) * P) / (intersector._Self * P);
            return intersector.Start + intersector._Self * h;
        }

        Vector Add(Vector addend)
        {
            return this._Self.Add(addend);
        }

        Vector Subtract(Vector addend)
        {
            return this._Self.Subtract(addend);
        }

        float Dot(Vector addend)
        {
            return this._Self.Dot(addend);
        }

        Vector Multiply(float addend)
        {
            return this._Self.Multiply(addend);
        }

        Vector Divide(float addend)
        {
            return this._Self.Divide(addend);
        }

        Vector Normalize()
        {
            return this._Self.Normalize();
        }

        bool ILine.Intersects(ILine intersector)
        {
            return this.Intersects((Line)intersector);
        }

        IVector ILine.PointOfIntersection(ILine intersector)
        {
            return this.PointOfIntersection((Line)intersector);
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
    }
}
