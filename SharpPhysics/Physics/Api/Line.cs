namespace SharpPhysics.Physics.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Line : Vector
    {
        protected Vector _Start, _End;

        protected Polygon _Bounds;

        protected Vector _Self
        {
            get
            {
                return this;
            }
            set
            {
                this._X = value.X;
                this._Y = value.Y;
            }
        }

        public Vector Start
        {
            get
            {
                return this._Start;
            }
            internal set
            {
                if (this._Start != value)
                {
                    this._Start = value;
                    this._Self = this._End - this._Start;
                }
            }
        }

        public Vector End
        {
            get
            {
                return this._End;
            }
            internal set
            {
                if (this._End != value)
                {
                    this._End = value;
                    this._Self = this._End - this._Start;
                }
            }
        }

        public Polygon Bounds
        {
            get
            {
                return this._Bounds;
            }
        }

        public Line(Vector Start, Vector End)
        {
            this._Start = Start;
            this._End = End;
            this._Self = this._End - this._Start;
            this._Bounds = new Triangle(this._Start, this._Start, this._End);
        }

        public Line(float startX, float startY, float endX, float endY)
        {
            this._Start = new Vector(startX, startY);
            this._End = new Vector(endX, endY);
            this._Self = this._End - this._Start;
            this._Bounds = new Triangle(this._Start, this._Start, this._End);
        }

        public virtual bool Intersects(Line intersector)
        {
            if (intersector is Bezier3 || intersector is Bezier4)
            {
                return intersector.Intersects(this);
            }
            var P = new Vector(-intersector.Y, intersector.X);
            var h = ((-this.Start + intersector.Start) * P) / (this * P);
            return h >= 0 && h <= 1;
        }

        public virtual Vector PointOfIntersection(Line intersector)
        {
            var P = new Vector(-intersector.Y, intersector.X);
            var h = ((-this.Start + intersector.Start) * P) / (this * P);
            return this.Start + this * h;
        }

        public virtual Vector PointAtSection(float t)
        {
            var u = 1 - t;
            return (this.Start * u) + (this.End * t);
        }

        public virtual Tuple<Line, Line> SplitAt(float t)
        {
            var mid = this.PointAtSection(t);
            return new Tuple<Line, Line>(new Line(Start, mid), new Line(mid, End));
        }

        public override int GetHashCode()
        {
            return (int)(this.Start.GetHashCode() + this.End.GetHashCode() * 199933);
        }

        public override bool Equals(object obj)
        {
            var other = obj as Line;
            if (other != null)
            {
                return this.Start == other.Start && this.End == other.End;
            }
            return base.Equals(obj);
        }

        public static Vector operator +(Line addend1, Vector addend2)
        {
            return addend1._Self.Add(addend2);
        }

        public static Vector operator -(Line minuend, Vector subtrahend)
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

        public static float operator *(Line multiplicand, Vector multiplier)
        {
            return multiplicand._Self.Dot(multiplier);
        }

        public static Vector operator -(Line origin)
        {
            return new Vector(-origin._Self.X, -origin._Self.Y);
        }

        public static bool operator ==(Line origin, Vector other)
        {
            return origin.Equals(other);
        }

        public static bool operator !=(Line origin, Vector other)
        {
            return !origin.Equals(other);
        }
    }
}
